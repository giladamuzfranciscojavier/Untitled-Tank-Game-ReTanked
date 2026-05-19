using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float health = 50;
    [SerializeField] float speed = 1f;
    [SerializeField] GameObject bullet;

    PlayerInput input;
    Rigidbody rb;
    SpriteRenderer sprite;

    float cooldown = 0;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        sprite = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown < 0) {
            cooldown = 0;
        }
        if(!input.isActiveAndEnabled)
        {            
            return;
        }

        if (input.enter && (GameManager.GetInstance().GetTank().transform.position - transform.position).magnitude<2) {
            EnterTank();
            return;
        }

        Move();
        Look();

        if (input.shoot)
        {
            Shoot();
        }

        if (input.repair) 
        {
            Repair();
        }

    }





    void Shoot() 
    {
        if (cooldown > 0) {
            return;
        }
        Instantiate(bullet, transform.position+transform.up*.1f, transform.rotation);
        cooldown = .25f;
    }

    void Move() 
    {
        Vector2 movement = input.movement;
        transform.position += new Vector3(movement.x, movement.y, 0) * Time.deltaTime * speed;
    }

    void Look() 
    {
        Vector3 look = Camera.main.ScreenToWorldPoint(input.look);
        look.z = 0;
        Vector3 dir = look - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle-90);
    }

    void EnterTank() {
        GameManager.GetInstance().EnterTank();        
    }

    void Repair() 
    { 
        sprite.enabled = !sprite.enabled;
    }


    public void DisableControls()
    {
        input.enabled = false;
        sprite.enabled = false;
    }

    public void EnableControls()
    {
        transform.position = GameManager.GetInstance().GetTank().transform.position+ GameManager.GetInstance().GetTank().transform.right;
        Look();
        input.enabled = true;
        sprite.enabled = true;
    }


    public Boolean isInTank() {
        return !input.enabled;
    }

    public float GetHealth() {
        return health;
    }

    public void Damage(float dmg) { 
        health -= dmg;
        if (health < 0) {
            GameManager.GetInstance().Die();
        }
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
