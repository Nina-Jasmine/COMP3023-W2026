using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private Vector2 movement;
    private Vector2 screenBounds;
    private float playerHalfWidth;
    private float xPosLastFrame;

    private void Start()
    {
        // Convert screen size into world units
        screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector2(Screen.width, Screen.height)
        );

        playerHalfWidth = spriteRenderer.bounds.extents.x;
        xPosLastFrame = transform.position.x;
    }

    private void Update()
    {
        HandleMovement();
        FlipCharacterX();

        // Set animator speed (used for Idle / Walk transitions)
        animator.SetFloat("Speed", Mathf.Abs(movement.x));
    }

    private void LateUpdate()
    {
        ClampMovement();
    }

    private void HandleMovement()
    {
        // input will store a value between -1 and +1
        // GetAxisRaw() takes exactly -1 or +1
        // GetAxis() takes a value between and up to -1 to +1 (useful for acceleration)
        // Getting the axis is mapped to A/D, left/right arrow and joystick left/right
        float input = Input.GetAxis("Horizontal");

        movement.x = input * speed * Time.deltaTime;
        transform.Translate(movement);
        if(input != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void FlipCharacterX()
    {
        if (transform.position.x > xPosLastFrame)
        {
            // We are moving right
            spriteRenderer.flipX = false;
        }
        else if (transform.position.x < xPosLastFrame)
        {
            // We are moving left
            spriteRenderer.flipX = true;
        }

        xPosLastFrame = transform.position.x;
    }

    private void ClampMovement()
    {
        Vector3 position = transform.position;

        position.x = Mathf.Clamp(
            position.x,
            -screenBounds.x + playerHalfWidth,
            screenBounds.x - playerHalfWidth
        );

        transform.position = position;
    }
}
