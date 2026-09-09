using UnityEngine;

//This is important for Input System Usage
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //This is important for Input System Usage
    PlayerInput playerInput;
    InputAction moveAction;

    //Health Functions  
    private Health health;


    [SerializeField] float speed = 5;

    void Start()
    {
    //Health Functions
        health = GetComponent<Health>();

    //Input Functions
        playerInput = GetComponent<PlayerInput>();
        
        //Searching witin the InputActionSystem for the Action Labeled -Move-
        moveAction = playerInput.actions.FindAction("Move");
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //Reading the Vector from the InputActionSystem 
        Vector2 direction = moveAction.ReadValue<Vector2>();

        //Moves the player position when the vector is recieved from the input system
        transform.position += new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;
    }

    //Health Functions
    public void TakeDamage(float damage)
    {
        health.TakeDamage(damage);
    }
}
