using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 movement { get; private set; }
    public Vector2 look { get; private set; }
    public bool shoot { get; private set; }
    public bool repair { get; private set; }
    public bool enter { get; private set; }

    Controls controls;

    private void Awake()
    {
        controls = new Controls();
    }

    private void Update()
    {
        ReadInput();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
        enter = repair = shoot = false;
    }

    void ReadInput() 
    {
        movement = controls.Player.Move.ReadValue<Vector2>();
        look = controls.Player.Look.ReadValue<Vector2>();
        shoot = controls.Player.Shoot.IsPressed();
        repair = controls.Player.Repair.WasPressedThisDynamicUpdate();
        enter = controls.Player.Enter.WasPressedThisDynamicUpdate();
    }

}
