using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score = 0;

    private void OnTriggerEnter2D(Collider2D collison)
    {
       if (collison.gameObject.CompareTag("Coin"))
       {
        Destroy(collison.gameObject);
        score++;
        scoreText.text = "Score: " + score;
       }

       if (collison.gameObject.CompareTag("Heart"))
       {
        Destroy(collison.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // trigger when game over to restart
       }

       if (collison.gameObject.CompareTag("Smash"))
       {
        Destroy(collison.gameObject);
        // Destroy()
       }
    
    }
}
