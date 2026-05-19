using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float maxHealth = 15;
    [SerializeField] float cooldown = 1;
    [SerializeField] int score = 500;

    float currentCD = 0;
    protected float health;

    NavMeshAgent agent;

    private void Start()
    {
        health = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        currentCD -= Time.deltaTime;
        if (currentCD < 0) { currentCD = 0; }


        Vector3 player = GameManager.GetInstance().PlayerPos();
        if (player.x == -999) {
            return;
        }
        agent.destination = player;
        Vector3 dir = player - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);


        if (dir.magnitude < 5 && currentCD==0) {
            Instantiate(bullet, transform.position+transform.up, transform.rotation);
            currentCD = cooldown;
        }
    }

    protected void Damage(float damage) { 
        health = Mathf.Max(0, health-damage);
        if (health == 0) {
            GameManager.GetInstance().AddScore(score);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            GameObject b = collision.gameObject;
            Damage(b.GetComponent<BulletController>().getDmg());
            Destroy(b);
        }
    }
}
