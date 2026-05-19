using UnityEditor.PackageManager;
using UnityEngine;

public class GenericModuleController : ModuleController
{

    [SerializeField] GenericModule module;

    public void Setup(GenericModule module)
    {
        hp = maxHp = module.GetHp();
        armor = maxArmor = module.GetArmor();
        weight = module.GetWeight();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = module.GetSprite();
    }

    public string getDisplayName()
    {
        return module.GetDisplayName();
    }
}
