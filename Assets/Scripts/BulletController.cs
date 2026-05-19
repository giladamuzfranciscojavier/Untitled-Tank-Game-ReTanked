using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] float dmg;
    [SerializeField] float lifetime;
    [SerializeField] float speed;

    float t = 0;

    private void Update()
    {
        t += Time.deltaTime;
        transform.position += speed * Time.deltaTime * transform.up;
        if (t > lifetime) {
            Destroy(gameObject);
        }
    }

    public float getDmg()
    {
        return dmg;
    }
}
