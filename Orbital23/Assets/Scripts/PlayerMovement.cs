using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 mousePosition;
    public float rotSpeed = 0.8f; // Speed of shuttlecock rotation
    Rigidbody2D rb;
    Vector2 position = new Vector2(0f, 0f);

    private void Start() {
        // Get Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePosition = Input.mousePosition; // Get current mouse position at this frame
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); // Get Scene coordinates
        position = Vector2.Lerp(transform.position, mousePosition, rotSpeed); // Linearly interpolates from current position to mouse position to simulate shuttlecock movement
    }

    private void FixedUpdate() {
        rb.MovePosition(position); // Placed in FixedUpdate as gameObject is physics simulated
    }

    // private void OnCollisionEnter(Collision col) {
    //     if (col.gameObject.tag == "Shuttlecock")
    //     {
    //         Debug.Log("Hit");
    //         rb = col.gameObject.GetComponent<Rigidbody2D>();
    //         rb.AddForce(rb.velocity * 100, ForceMode2D.Impulse); // Add force to shuttlecock when it collides with player
    //     }
    // }
}
