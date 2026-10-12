using UnityEngine;
using UnityEngine.InputSystem;

public class MoveRacket : MonoBehaviour
{
    // Controls how fast the racket moves.
    public float speed = 5f;
    // Reference to the Input Action that controls vertical movement.
    // This can be assigned in the Unity Inspector.
    public InputActionReference moveAction;
    // Reference to the Rigidbody2D attached to this racket.
    private Rigidbody2D rb;
    void Awake()
    {
        // Get the Rigidbody2D component attached to this GameObject .
        rb = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        // Enable the movement input action when the racket is enabled.
        moveAction.action.Enable();
    }
    void OnDisable()
    {
        // Disable the movement input action when the racket is disabled.
        moveAction.action.Disable();
    }
    void FixedUpdate()
    {
        // Read the vertical input.
        //
        // This will normally give us:
        // 1 = Up
        // 0 = No input
        // - 1 = Down
        Vector2 movement = moveAction.action.ReadValue<Vector2>();
        // Set the Rigidbody2D's linear velocity.
        //
        // X is 0 because the racket should only move vertically.
        // Y is the input multiplied by our movement speed.
        rb.linearVelocity = new Vector2(0f, movement.y * speed);

    }
}
