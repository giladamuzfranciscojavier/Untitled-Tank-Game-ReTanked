using Unity.Collections;
using UnityEngine;

public class TankInput : MonoBehaviour
{

    public Vector2 look { get; private set; }
    public float movement { get; private set; }
    public float rotation { get; private set; }
    public bool pShoot { get; private set; }
    public bool sShoot { get; private set; }
    public bool exit { get; private set; }

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
        exit = pShoot = sShoot = false;
    }

    void ReadInput()
    {
        movement = controls.Tank.Move.ReadValue<float>();
        rotation = controls.Tank.Rotate.ReadValue<float>();
        look = controls.Tank.Look.ReadValue<Vector2>();
        pShoot = controls.Tank.PShot.IsPressed();
        sShoot = controls.Tank.SShot.IsPressed();
        exit = controls.Tank.Exit.WasPressedThisDynamicUpdate();
    }
}
