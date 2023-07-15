using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//Script for item interactions, set as different prefabs, added to Shuttlecock

public class ItemCollector : MonoBehaviour
{
    public int score = 0;
    private int lives = 1;
    private Vector3 initialPosition;
    private Rigidbody2D rb;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI livesUI;
    public static bool isMagnet;
    public GameObject respawnPoint;

    SpawnCoin coinCount;
    SpawnEnlarge enlargeCount;
    SpawnHeart heartCount;
    SpawnMagnet magnetCount;
    SpawnSmash smashCount;
    SpawnStaticObs statobsCount;
    SpawnMovingObsLR LRcount;
    SpawnMovingObsUD UDcount;
    Rigidbody2D Stop;

   private void Start()
   {
     isMagnet = false;
     initialPosition = transform.position;  // get original position of shuttlecock
     rb = GetComponent<Rigidbody2D>();

     coinCount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnCoin>();
     enlargeCount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnEnlarge>();
     heartCount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnHeart>();
     magnetCount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnMagnet>();
     smashCount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnSmash>();
     statobsCount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnStaticObs>();
     LRcount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnMovingObsLR>();
     UDcount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnMovingObsUD>();
     // itemCount to track number of items currently spawned
   }
 
    /*
    Item interactions when collide with shuttlecock
    coin : adds 1 to player score, update game UI
    heart: adds 1 to player lives, update game UI
    ground: triggers game over if player lives is 0 else reset shuttlecock to respawn position
    smash: destroys all obstacles
    magnet: moves all coins within radius towards shuttlecock
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       if (collision.gameObject.CompareTag("Coin"))
       {
        Destroy(collision.gameObject);
        score++;
        scoreUI.text = "Score: " + score;
        coinCount.DecreaseCounter();
       }

       if (collision.gameObject.CompareTag("Heart"))
       {
        Destroy(collision.gameObject);
        lives++;
        livesUI.text = "Lives: " + lives;
        heartCount.DecreaseCounter();
       }

       if (collision.gameObject.CompareTag("Ground"))
       {
        lives--;
        livesUI.text = "Lives: " + lives;
        if (lives == 0)
        {
          SceneManager.LoadScene("End Screen");
        }
        else 
        {
          StartCoroutine(newPosition()); 
        }
       } 

       if (collision.gameObject.CompareTag("Smash"))
       {
        Destroy(collision.gameObject);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach(GameObject Obstacle in enemies)
        GameObject.Destroy(Obstacle);
        smashCount.DecreaseCounter();
        StartCoroutine(disableObs());   
       }

       if (collision.gameObject.CompareTag("Magnet"))
       {
         isMagnet = true;
         Destroy(collision.gameObject);
         magnetCount.DecreaseCounter();
         StartCoroutine(disableMagnet());
       }

       if (collision.gameObject.CompareTag("Enlarge"))
       {
        Destroy(collision.gameObject);
        StartCoroutine(disableEnlarge());
       }
    }

    private IEnumerator newPosition()
    {
      transform.position = respawnPoint.transform.position;
      rb.velocity = new Vector3 (0, 0, 0); 
      Stop = GameObject.FindGameObjectWithTag("Shuttlecock").GetComponent<Rigidbody2D>();
      Stop.constraints = RigidbodyConstraints2D.FreezePosition;
      yield return new WaitForSeconds(3);   
      Stop.constraints = RigidbodyConstraints2D.None;
    }

    private IEnumerator disableMagnet()
    {
      yield return new WaitForSeconds(10);
      Debug.Log("magnetend");
      isMagnet = false;
    }

    private IEnumerator disableObs()
    {
      yield return new WaitForSeconds(10);
      Debug.Log("smashend");
      statobsCount.ResetCounter();
      LRcount.ResetCounter();
      UDcount.ResetCounter();
    }

    private IEnumerator disableEnlarge()
    {
      GameObject racket = GameObject.FindGameObjectWithTag("Racket");
      Vector3 increase = new Vector3 (1,1,1);
      racket.transform.localScale += increase;
      yield return new WaitForSeconds(10);
      racket.transform.localScale -= increase;
      Debug.Log("enlargeend");
      enlargeCount.DecreaseCounter();
    }
}
