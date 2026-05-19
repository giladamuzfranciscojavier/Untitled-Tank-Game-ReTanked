using UnityEngine;

[CreateAssetMenu(fileName = "GenericModule", menuName = "Scriptable Objects/GenericModule")]
public class GenericModule : ScriptableObject
{
    [SerializeField] Sprite sprite;
    [SerializeField] float hp;
    [SerializeField] float armor;
    [SerializeField] float weight;
    [SerializeField] string displayName;

    public float GetHp() {
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
    public string GetDisplayName()
    {
        return displayName;
    }
    public Sprite GetSprite()
    {
        return sprite;
    }
}
