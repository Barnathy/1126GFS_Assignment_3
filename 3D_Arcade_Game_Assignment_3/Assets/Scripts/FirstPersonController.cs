using UnityEngine;
using UnityEngine.InputSystem;
using Unity.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5f; // stores walking movement speed
    public float mouseSensitivity = 3f;
    //public float gravity = -10f; //keeps player from moving up when coliding with objects - used NavMeshAgent instead


    public int minHealth = 0; // minimum health value
    public int maxHealth = 100; // maximum health value
    public int currentHealth;

    public Transform cameraTransform;
    public Slider healthBar; //reference to the UI Slider component that represents the player's health bar


    //private Vector3 velocity
    private float xRotation = 0f;
    private int collisionCount = 0; // counter for the number of collisions with enemies
    private CharacterController controller;
    private UnityEngine.AI.NavMeshAgent agent;
    
    

    void Start() // Start is called before the first frame update
    {   
        // sets the current health to the maximum health at the start of the game
        currentHealth = maxHealth;
        healthBar.value = currentHealth;

        // below line is used to get the CharacterController component attached to the player object
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
          
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        //healthBar = GetComponent<Slider>();
        //Debug.Log(agent.isOnNavMesh); //checking if the player is on the navmesh, returns true
    }

    
    void Update()// Update is called once per frame
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
    
    void Look() // handles the player's camera rotation based on mouse movement
    {
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * mouseSensitivity *Time.deltaTime;
        float mouseY = mouseDelta.y * mouseSensitivity *Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }
        private void OnTriggerEnter(Collider other) //when the player collides with an enemy, this function is called
    {
        if (other.CompareTag("Enemy"))
        {
            currentHealth -= 10; // reduce player's health by 10 when colliding with an enemy
            collisionCount++;
            Debug.Log("Current Health: " + currentHealth); // log the player's current health
            healthBar.value = currentHealth;
            if (currentHealth <= minHealth)
            {
                Debug.Log("Game Over!"); // log game over message
                SceneManager.LoadScene("GameOver"); // load the GameOver scene
            }
        }
    }

}
