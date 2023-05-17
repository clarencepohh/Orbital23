using UnityEngine;

public class ShuttlecockMovement : MonoBehaviour
{
    private Rigidbody2D rb; 
    public Transform centerOfGravity;
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
        Vector3 targetDirection = rb.velocity;
        if (targetDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime * 60);
        }
    }
}
