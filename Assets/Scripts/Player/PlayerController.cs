using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public InputMaster input;
    public Rigidbody rigidBody;

    private Vector3 movement;
    public float speed = 1f;
    private float originalSpeed;
    private Vector3 direction;

    public float sprintMulitplier = 1f;

    public float jumpForce = 10f;


    private void Awake()
    {
        input = new InputMaster();
        input.Player.Jump.performed += OnJump;
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);

        originalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (input.Player.Sprint.IsPressed())
        {
            OnSprinting();
        }
        else if (input.Player.Sprint.WasReleasedThisFrame())
        {
            speed = originalSpeed;
        }
        transform.Translate(direction * (speed * Time.deltaTime));
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        direction.z = direction.y;
        direction.y = 0;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void OnSprinting()
    {
        speed = originalSpeed * sprintMulitplier;
    }
}
