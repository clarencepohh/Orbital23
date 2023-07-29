using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to check for item collision to prevent spawn overlap

public class CheckOverlap : MonoBehaviour
{
    public string[] tagsToCheck;
    private bool canDestroy = true;

    private void Start()
    {
        // Allow destruction after a delay
        Invoke("DisableDestruction", 0.1f); //adjust delay as needed
    }

    private void DisableDestruction()
    {
        canDestroy = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has any of the tags specified and is a different instance
        if (canDestroy && CheckCollisionTag(collision.gameObject.tag) && collision.gameObject != gameObject)
        {
            // Destroy the spawned object
            Destroy(gameObject);
        }
    }

    private bool CheckCollisionTag(string tag)
    {
        // Iterate through the tagsToCheck array and check if the provided tag exists
        for (int i = 0; i < tagsToCheck.Length; i++)
        {
            if (tagsToCheck[i] == tag)
            {
                return true; // Tag found in the array
            }
        }
        return false; // Tag not found in the array
    }
}