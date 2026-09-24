using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5f; // stores walking movement speed
    public float mouseSensitivity = 5f;
    //public float gravity = -10f; //keeps player from moving up when coliding with objects

    public Transform cameraTransform;

    //private Vector3 velocity
    private float xRotation = 0f;
    private CharacterController controller;

    void Start()
    {

        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
    }

    void Move()
    {
        Vector2 input = Vector2.zero;

        if(Keyboard.current.wKey.isPressed ||
        Keyboard.current.upArrowKey.isPressed)
        input.y += 1;

        if(Keyboard.current.sKey.isPressed ||
        Keyboard.current.downArrowKey.isPressed)
        input.y -= 1;

        if(Keyboard.current.aKey.isPressed ||
        Keyboard.current.leftArrowKey.isPressed)
        input.x -= 1;

        if(Keyboard.current.dKey.isPressed ||
        Keyboard.current.rightArrowKey.isPressed)
        input.x += 1;
        
        
        Vector3 move =           
        transform.right * input.x + transform.forward * input.y;
        transform.position += move.normalized * moveSpeed * Time.deltaTime;
        
        controller.Move(move.normalized * moveSpeed * Time.deltaTime);
    }
    
    void Look()
    {
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * mouseSensitivity *Time.deltaTime;
        float mouseY = mouseDelta.y * mouseSensitivity *Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }
}
