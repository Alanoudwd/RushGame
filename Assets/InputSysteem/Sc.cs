using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Photon.Pun;
using Photon.Pun.Demo.SlotRacer;
using UnityEngine;
using UnityEngine.InputSystem;


public class Sc : MonoBehaviour
{
    Inputsysteem inputsys;
    public PhotonView view;
    public Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float angle_X;
    [SerializeField] float angle_Y;
    [SerializeField] float rotationSpeed;
    float ThrustInput;
    UnityEngine.Vector2 move;


    void Awake()
    {

        inputsys = new Inputsysteem();
        inputsys.Gameplay.Thrust.performed += onThrust;
        inputsys.Gameplay.Thrust.canceled += onThrust;

        inputsys.Gameplay.Move.performed += ctx => move = (ctx.ReadValue<UnityEngine.Vector2>());
        inputsys.Gameplay.Move.canceled += ctx => move = UnityEngine.Vector2.zero;
    }


    void onThrust(InputAction.CallbackContext value)
    {
        ThrustInput = value.ReadValue<float>();
    }


    private void OnEnable()
    {
        inputsys.Gameplay.Enable();
    }

    private void OnDisable()
    {
        inputsys.Gameplay.Disable();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
    }
    
    void FixedUpdate()
    {
        rb.velocity = transform.forward * speed * (Mathf.Max(ThrustInput, .2f));
        Turnship();
    }
    void Turnship()
    {
        transform.Rotate(UnityEngine.Vector3.up, move.x * rotationSpeed * Time.fixedDeltaTime);
        TurnShipvisual();
    }

    void TurnShipvisual()
    {
        transform.localEulerAngles = new UnityEngine.Vector3(move.y * angle_Y, transform.localEulerAngles.y, -move.x * angle_X);
    }

}
