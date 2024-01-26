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
    private Vector3 direction;

    public int maxThrows;
    private int currentThrows;
    public float throwCooldown;
    public float throwForce;
    public float throwUpForce;

    bool canThrow = true;
    private void Awake()
    {
        input = new InputMaster();
    }

    private void OnEnable()
    {
        input.Enable();
        currentThrows = maxThrows;
    }

    private void OnDisable()
    {
        input.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * (speed * Time.deltaTime));
        if (input.Player.Throw.IsPressed() && canThrow == true && currentThrows > 0)
        {

        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        direction.z = direction.y;
        direction.y = 0;
    }
    public void Throw()
    {
        canThrow = false;
    }
}
