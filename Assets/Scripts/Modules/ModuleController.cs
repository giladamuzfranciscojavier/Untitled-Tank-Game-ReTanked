using UnityEngine;

public class ModuleController : MonoBehaviour
{
    protected float maxHp, maxArmor, weight = 0;


    protected float hp, armor;

    protected SpriteRenderer spriteRenderer;


    //DAMAGE DISTRIBUTION
    //Armor -> half damage
    //HP -> full damage
    //REMAINING DMG (destroyed module) -> carried to hull/player (return)
    public float Damage(float dmg)
    {

        if (dmg / 2 < armor)
        {
            armor -= dmg / 2;
        }

        else
        {
            float remDmg = dmg / 2 - armor;
            armor = 0;

            if (hp < remDmg)
            {
                hp = 0;
                return remDmg - hp;
            }

            hp -= remDmg;
        }

        return 0;
    }


    //health / maxHealth
    //Useful for speed penalties and GUI
    public float relHealth()
    {
        return hp / maxHp;
    }

    //armor / maxArmor
    //Useful for GUI
    public float relArmor()
    {
        return armor / maxArmor;
    }



    public float getHP()
    {
        return hp;
    }

    public float getArmor()
    {
        return armor;
    }

    public float getWeight()
    {
        return weight;
    }    
}
