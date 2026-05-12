using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    Vector3 moveDir;
    Vector3 move;
    [SerializeField] float speed = 5f;
    [SerializeField] float runSpeed = 8f;
    float currentSpeed;
    public void Move (InputAction.CallbackContext context)
    {
      
        Vector2 movementInput = context.ReadValue<Vector2>();
        moveDir.x = movementInput.x;
        moveDir.z = movementInput.y;
        if (moveDir.magnitude > 1f)
        {
            moveDir.Normalize();
        }
    }
    public void Sprint (InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentSpeed = runSpeed;
        }
        else if (context.canceled)
        {
            currentSpeed = speed;
        }
    }

    public void Jump (InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Player Jumped");
        }
    }

    public void Attack (InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Player Attacked");
        }
    }

    public void Interact (InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Player Interacted");
        }
    }

    public void Look (InputAction.CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>();
        //LookRotaion(lookInput);
        transform.Rotate(Vector3.up, lookInput.x);
    }


    void LookRotaion(Vector2 lookInput)
    {
        float lookSpeed = 5f;
        float lookX = lookInput.x * lookSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, lookX);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {        
        rb.linearVelocity = (transform.forward * moveDir.z + transform.right * moveDir.x) * currentSpeed + Vector3.up * rb.linearVelocity.y;
    }


}
