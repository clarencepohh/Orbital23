using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text scoreText;
   // [SerializeField] private Text livesText;
    private int score = 0;
   // private int lives = 1;

    private void OnTriggerEnter2D(Collider2D collison)
    {
        
       if (collison.gameObject.CompareTag("Coin"))
       {
        Destroy(collison.gameObject);
        score++;
        scoreText.text = "Score: " + score;
       }
       
      /* if (collison.gameObject.CompareTag("Ground"))
       {
        lives--;
        livesText.text = "Lives: " + lives;
        if (lives == 0)
        {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            ResetObject(Shuttlecock);
        }
       } 

       if (collison.gameObject.CompareTag("Heart"))
       {
        Destroy(collison.gameObject);
        lives++;
        livesText.text = "Lives: " + lives;
       }*/

       if (collison.gameObject.CompareTag("Smash"))
       {
        Destroy(collison.gameObject);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach(GameObject Obstacle in enemies)
        GameObject.Destroy(Obstacle);
       }
    
    }
}
