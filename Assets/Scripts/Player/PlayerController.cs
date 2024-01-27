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
    public int maxHealth = 150;
    public int currentHealth; // will change this to get / set function later

    [Header("Power up amount")]
    public int whippyCream = 0;

    private void Awake()
    {
        input = new InputMaster();
        maxHealth = currentHealth;
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
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * (speed * Time.deltaTime));
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        direction.z = direction.y;
        direction.y = 0;
    }


}
