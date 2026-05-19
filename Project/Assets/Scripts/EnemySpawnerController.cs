using System.Collections;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] GameObject tank;
    [SerializeField] float cooldown;

    private void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn() {

        float t = 0;

        Instantiate(tank, transform.position, Quaternion.identity);

        while (t < cooldown)
        {
            t += Time.deltaTime;
            yield return null;            
        }
        StartCoroutine("Spawn");
    }
}
