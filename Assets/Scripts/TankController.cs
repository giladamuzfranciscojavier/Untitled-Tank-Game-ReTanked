using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class TankController : MonoBehaviour
{

    [SerializeField] public GenericModuleController hull;
    [SerializeField] public GenericModuleController armor;
    [SerializeField] public EngineModuleController engine;
    [SerializeField] public GenericModuleController ltrack;
    [SerializeField] public GenericModuleController rtrack;
    [SerializeField] public WeaponController pGun;
    [SerializeField] public WeaponController sGun;

    Rigidbody2D rb;
    TankInput input;

    bool setup;

    public void Setup()
    {
        input = GetComponent<TankInput>();
        rb = GetComponent<Rigidbody2D>();
        rb.mass = hull.getWeight() + armor.getWeight() + engine.getWeight() + ltrack.getWeight() * 2+pGun.getWeight()+sGun.getWeight();
        setup = true;
    }

    private void Update()
    {
        if (!setup || !input.isActiveAndEnabled)
        {
            return;
        }

        Move();
        RotateTank();
        RotateTurret();
        

        if (input.pShoot) {
            PShoot();
        }

        if (input.sShoot) {
            SShoot();
        }

        if (input.exit) {
            ExitTank();
        }
    }

    void Move() {
        rb.AddForce(transform.up * input.movement * GetMoveSpeed()*Time.deltaTime, ForceMode2D.Force);
    }

    void RotateTank() 
    {
        rb.AddTorque(input.rotation * GetMoveSpeed()/2 * Time.deltaTime);
    }

    void RotateTurret() 
    {
        Vector3 look = Camera.main.ScreenToWorldPoint(input.look);
        look.z = 0;
        Vector3 dir = look - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        pGun.RotateTurret(angle);
        sGun.RotateTurret(angle);
    }

    void PShoot() {
        pGun.Shoot();
    }

    void SShoot() {
        sGun.Shoot();
    }

    float GetMoveSpeed() {
        return engine.GetSpeed() * rtrack.relHealth()*ltrack.relHealth();
    }



    void Damage(Collision2D collision) 
    {

        float dmg = 0;
        string tag = collision.gameObject.tag;

        if (tag == "bulletEnemy")
        {
            dmg = collision.gameObject.GetComponent<BulletController>().getDmg();
            Destroy(collision.gameObject);
        }

        else if (tag == "enemy")
        {
            dmg = rb.mass - collision.gameObject.GetComponent<Rigidbody2D>().mass * 10;
        }

        else {
            return;
        }


        Debug.Log(collision.otherCollider.tag);

            switch (collision.otherCollider.tag)
            {
                case "farmor":
                    dmg = armor.Damage(dmg);
                    break;
                case "engine":
                    dmg = engine.Damage(dmg);
                    break;
                case "ltread":
                    dmg = ltrack.Damage(dmg);
                    break;
                case "rtread":
                    dmg = rtrack.Damage(dmg);
                    break;
            }

        dmg = hull.Damage(dmg);
        GameManager.GetInstance().GetPlayer().Damage(dmg);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damage(collision);        
    }


    void ExitTank()
    {
        GameManager.GetInstance().ExitTank();
    }

    public void DisableControls()
    {
        input.enabled = false;
    }

    public void EnableControls()
    {
        input.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("treasure"))
        {
            GameManager.GetInstance().AddScore(collision.gameObject.GetComponent<TreasureController>().points);
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "nLevel")
        {
            GameManager.GetInstance().GameOver();
        }
    }

}
