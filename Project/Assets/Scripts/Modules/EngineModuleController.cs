using UnityEngine;

public class EngineModuleController : GenericModuleController
{

    [SerializeField] Engine engine;

    float speed;

    public void Setup(Engine engine)
    {

        hp = maxHp = engine.GetHp();
        armor = maxArmor = engine.GetArmor();
        weight = engine.GetWeight();

        speed = engine.GetSpeed();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = engine.GetSprite();
    }

    public float GetSpeed() { 
        return speed;
    }

    public string GetDisplayName() {
        return engine.GetDisplayName();
    }

}
