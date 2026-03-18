using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{

    [SerializeField]private string Nombre = "NONE";
    [SerializeField] private int Vida = 100;
    [SerializeField] private float Speed = 5f;


    [SerializeField] private InputSystem_Actions input;
    [SerializeField] private Vector2 moveInput;

    private void Awake()
    {
        input = new();

    }
    private void OnEnable()
    {
        input.Enable();

        input.Player.Move.performed += OnMove;
        input.Player.Move.canceled += OnMove;

    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

  
    }
    private void MovementMechanism(Vector2 input)
    {
        transform.position += (Vector3)input * Speed * Time.deltaTime;
    }
    void Start()
    {

    }

    void Update()
    {
        if (moveInput != Vector2.zero)
        {
            MovementMechanism(moveInput);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomba")
        {
            Vida -= 10;
            Destroy(collision.gameObject);
            print("boom");
        }
    }
}