using UnityEngine;

[CreateAssetMenu(fileName = "Engine", menuName = "Scriptable Objects/Engine")]
public class Engine : ScriptableObject
{
    [SerializeField] Sprite sprite;
    [SerializeField] float hp;
    [SerializeField] float armor;
    [SerializeField] float weight;
    [SerializeField] float speed;
    [SerializeField] string displayName;

    public float GetHp()
    {
        return hp;
    }
    public float GetArmor()
    {
        return armor;
    }

    public float GetWeight()
    {
        return weight;
    }
    public float GetSpeed()
    {
        return speed;
    }
    public string GetDisplayName()
    {
        return displayName;
    }
    public Sprite GetSprite()
    {
        return sprite;
    }
}
