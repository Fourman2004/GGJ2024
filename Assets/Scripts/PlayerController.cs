using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public InputMaster input;
    public Rigidbody rigidBody;

    public Vector3 movement;
    public float speed = 1f;
    public Vector3 direction;

    private void Awake()
    {
        input = new InputMaster();
    }
    // Start is called before the first frame update
    void Start()
    {
        
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