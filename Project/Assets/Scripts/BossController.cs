using UnityEngine;

public class BossController : EnemyController
{
    [SerializeField] GameObject barrier;

    protected new void Damage(float damage)
    {
        health = Mathf.Max(0, health - damage);
        if (health == 0)
        {
            Destroy(barrier);
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
