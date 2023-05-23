using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public float speed = 1f;
    private float lowerBound;

    void Start()
    {
        lowerBound = Camera.main.ScreenToWorldPoint(Vector3.zero).y - 1f;
    }

    
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.x < lowerBound)
        {
           Destroy(gameObject);
        }
        
    }
}
