using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] Sprite sprite;
    [SerializeField] GameObject bullet;
    [SerializeField] float weight, damage, heat, cooldown;
    [SerializeField] bool hasHeat;
    [SerializeField] string displayName;

    public GameObject GetBullet() {
        return bullet;
    }

    public float GetWeight() { return weight; }
    public float GetDamage() { return damage; }
    public float GetHeat() { return heat; }
    public float GetCooldown() { return cooldown; }
    public bool HasHeat() { return hasHeat; }
    public string GetDisplayName() { return displayName; }
}
