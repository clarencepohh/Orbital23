using UnityEngine;

public class CentreOfGravity : MonoBehaviour
{
    private Rigidbody2D rb; 
    public Vector2 CG;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CG = rb.centerOfMass;
    }
}
