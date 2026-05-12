using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    PlayerInput playerInput;
    public void Look(InputAction.CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>();
        //look up and down clamped to 45 degrees with look speed
        //LookUpDown(lookInput);
        //transform.Rotate(Vector3.right, -lookInput.y);
    }
    void LookUpDown(Vector2 lookInput)
    {
        float lookSpeed = 5f;
        float lookX = lookInput.x * lookSpeed * Time.deltaTime;
        float lookY = lookInput.y * lookSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, lookX);
        transform.Rotate(Vector3.right, -lookY);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
