using UnityEngine;
// using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector3 mousePosition;
    public float moveSpeed = 0.8f;
    Rigidbody2D rb;
    Vector2 position = new Vector2(0f, 0f);

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePosition = Input.mousePosition; // Get current mouse position at this frame
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); // Get Scene coordinates
        position = Vector2.Lerp(transform.position, mousePosition, moveSpeed); // Linearly interpolates from current position to mouse position 
    }

    private void FixedUpdate() {
        rb.MovePosition(position); // Placed in FixedUpdate as gameObject is physics simulated
    }
}
