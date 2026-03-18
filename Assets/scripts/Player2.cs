using UnityEngine;
using UnityEngine.InputSystem;

public class Player2 : MonoBehaviour
{

    public string Nombre = "NONE";
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

        input.Player2.Move.performed += OnMove;
        input.Player2.Move.canceled += OnMove;

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
        if (Vida <= 0) 
        {
            Debug.LogWarning("HAS MUERTO PLAYER 2 "+Nombre);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomba")
        {
            Vida -= 10;
            Destroy(collision.gameObject);
            print("PLAYER 2  =   -10 <3");
        }
    }
}