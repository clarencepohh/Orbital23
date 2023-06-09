using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOverlap : MonoBehaviour
{
    private bool canDestroy = true;

    private void Start()
    {
        // Allow destruction after a delay
        Invoke("DisableDestruction", 0.1f); // Adjust the delay as needed
    }

    private void DisableDestruction()
    {
        canDestroy = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the same tag as the spawned object and is a different instance
        if (canDestroy && collision.gameObject.CompareTag(gameObject.tag) && collision.gameObject != gameObject)
        {
            // Destroy the spawned object
            Destroy(gameObject);
        }
    }
}
