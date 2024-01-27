using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController playerController;

    public float mouseSensitvity = 25f;
    public Transform body;
    float mouseX, mouseY;
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = playerController.input.Player.MouseX.ReadValue<float>() * mouseSensitvity * Time.deltaTime;
        mouseY = playerController.input.Player.MouseY.ReadValue<float>() * mouseSensitvity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * mouseX);
    }
}
