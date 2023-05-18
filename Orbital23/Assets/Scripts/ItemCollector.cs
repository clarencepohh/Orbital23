using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int score = 0;

    private void OnTriggerEnter2D(Collider2D collison)
    {
       if (collison.gameObject.CompareTag("Coin"))
       {
        Destroy(collison.gameObject);
        score++;
        Debug.Log("Score: " + score);
       }
    }
}
