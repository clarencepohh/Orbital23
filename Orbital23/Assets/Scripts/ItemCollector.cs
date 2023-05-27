using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//Script for item interactions, set as different prefabs, added to Shuttlecock

public class ItemCollector : MonoBehaviour
{
    private int score = 0;
    private int lives = 1;
    private Vector3 initialPosition;
    private Rigidbody2D rb;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI livesUI;

   private void Start()
   {
    initialPosition = transform.position;  // get original position of shuttlecock
    rb = GetComponent<Rigidbody2D>();
   }
    
    /*
    Item interactions when collide with shuttlecock
    coin : adds 1 to player score, update game UI
    heart: adds 1 to player lives, update game UI
    ground: triggers game over if player lives is 0 else reset shuttlecock to original position
    smash: destroys all obstacles
    */

    private void OnTriggerEnter2D(Collider2D collison)
    {
        
       if (collison.gameObject.CompareTag("Coin"))
       {
        Destroy(collison.gameObject);
        score++;
        scoreUI.text = "Score: " + score;
       }

       if (collison.gameObject.CompareTag("Heart"))
       {
        Destroy(collison.gameObject);
        lives++;
        livesUI.text = "Lives: " + lives;
       }

       if (collison.gameObject.CompareTag("Ground"))
       {
        lives--;
        livesUI.text = "Lives: " + lives;
        if (lives == 0)
        {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else 
        {
            transform.position = initialPosition;
            rb.velocity = new Vector3 (0, 0, 0);
        }
       } 

       if (collison.gameObject.CompareTag("Smash"))
       {
        Destroy(collison.gameObject);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach(GameObject Obstacle in enemies)
        GameObject.Destroy(Obstacle);
       }
    
    }
}
