using UnityEngine;
using UnityEngine.Windows;

public class WeaponController : MonoBehaviour
{
    [SerializeField] Weapon weapon;

    float heat, weight, cooldown;
    public bool hasHeat { get; private set; }

    float currentCD = 0;
    float currentHeat = 0;


    public void Setup(Weapon weapon)
    {
        hasHeat = weapon.HasHeat();
        heat = weapon.GetHeat();
        weight = weapon.GetWeight();
        cooldown = weapon.GetCooldown();
    }

    private void Update()
    {
        if (currentCD > 0) {
            currentCD -= Time.deltaTime;
        }

        if (heat - 1 > 0)
        {
            heat -= 1;
        }
        else {
            heat = 0;
        }
    }

    public void RotateTurret(float angle)
    {
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 5);
    }

    public void Shoot() 
    {
        if (currentCD > 0)
        {
            return;
        }
        else if (hasHeat && currentHeat > 100)
        {
            return;
        }
             
        Instantiate(weapon.GetBullet(), transform.position+transform.up*.5f, transform.rotation);

        if (hasHeat)
        {
            currentHeat += heat;
            currentCD = .25f;
        }
        else { 
            currentCD = cooldown;  
        }
                  
    }

    public float getWeight()
    {
        return weight;
    }

    public float getHeat()
    {
        return heat;
    }
    public float getCooldown()
    {
        return cooldown;
    }
}
