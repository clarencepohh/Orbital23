using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShuttlecockMovement : MonoBehaviour
{
    private Rigidbody2D rb; 
    public Transform centerOfGravity;
    public float rotationSpeed = 1.0f;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private int lives = 1;
    [SerializeField] private Text livesText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (centerOfGravity)
        { 
            rb.centerOfMass = centerOfGravity.localPosition;
        }
        initialPosition = transform.position;
        
    }

    private void Update() {
        Vector3 targetDirection = rb.velocity;
        if (targetDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime * 60);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collison)
    { 
        if (collison.gameObject.CompareTag("Heart"))
       {
        Destroy(collison.gameObject);
        lives++;
        livesText.text = "Lives: " + lives;
       }
    
       if (collison.gameObject.CompareTag("Ground"))
       {
        lives--;
        livesText.text = "Lives: " + lives;
        if (lives == 0)
        {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else 
        {
            transform.position = initialPosition;
        }
       } 
    }   
}
