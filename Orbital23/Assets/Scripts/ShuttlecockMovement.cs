using UnityEngine;

public class ShuttlecockMovement : MonoBehaviour
{
    private Rigidbody2D rb; 
    public Transform centerOfGravity;
    // public Transform rotationTarget;
    public float rotationSpeed = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (centerOfGravity)
        { 
            rb.centerOfMass = centerOfGravity.localPosition;
        }
    }

    private void Update() {
        // Vector3 targetDirection = rb.velocity;
        // float oneStep = rotationSpeed * Time.deltaTime;
        // Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, oneStep, 0.0f);
        // transform.rotation = Quaternion.LookRotation(newDirection);
        Vector3 targetDirection = rb.velocity;
        // float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        // Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        // rb.rotation = Quaternion.Slerp(rb.rotation, q, Time.deltaTime * rotationSpeed); 
        if (targetDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime * 60);
        }
    }
}
