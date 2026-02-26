using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Vector2 moveInput;
    private Rigidbody2D rBody;
    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveX = moveInput.x * moveSpeed; // Example speed multiplier
         rBody.linearVelocity = new Vector2(moveX, rBody.linearVelocity.y);
    }   
         
   public void OnMove(InputAction.CallbackContext context)
   {
       // Handle player movement

        moveInput = context.ReadValue<Vector2>();
        Debug.Log("Move Input: " + moveInput);

   }
}
