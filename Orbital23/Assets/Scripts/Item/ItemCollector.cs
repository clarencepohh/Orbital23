using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//Script for item interactions, set as different prefabs, added to Shuttlecock

public class ItemCollector : MonoBehaviour
{
    public static int score = 0;
    private int lives = 1;
    private Vector3 initialPosition;
    private Rigidbody2D rb;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI livesUI;
    public static bool isMagnet;
    public GameObject respawnPoint;
    private float respawnZ;
    private Vector3 respawnCoordinates;    
    public Material respawnMaterial;
    
    [SerializeField] private AudioSource coinSoundEffect;
    [SerializeField] private AudioSource heartSoundEffect;
    [SerializeField] private AudioSource bombSoundEffect;
    [SerializeField] private AudioSource magnetSoundEffect;
    [SerializeField] private AudioSource enlargeSoundEffect;

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
    score = 0;
    isMagnet = false;
    respawnMaterial.SetFloat("_isRespawn", 0f); // prevent flashing effect at start
    respawnZ = transform.position.z; // get original z position of shuttlecock
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
    enlarge: increases size of racket
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
      if (collision.gameObject.CompareTag("Coin"))
      {
        onPickupEffect("Coin");
        Destroy(collision.gameObject);
        score++;
        scoreUI.text = "Score: " + score;
        coinCount.DecreaseCounter();
      }

      if (collision.gameObject.CompareTag("Heart"))
      {
        onPickupEffect("Heart");
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
        onPickupEffect("Smash");
        Destroy(collision.gameObject);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach(GameObject Obstacle in enemies)
        GameObject.Destroy(Obstacle);
        smashCount.DecreaseCounter();
        StartCoroutine(disableObs());   
      }

      if (collision.gameObject.CompareTag("Magnet"))
      {
        onPickupEffect("Magnet");
        isMagnet = true;
        Destroy(collision.gameObject);
        magnetCount.DecreaseCounter();
        StartCoroutine(disableMagnet());
      }

      if (collision.gameObject.CompareTag("Enlarge"))
      {
        onPickupEffect("Enlarge");
        Destroy(collision.gameObject);
        StartCoroutine(disableEnlarge());
      }
    }

    private IEnumerator newPosition() // respawn position of shuttlecock
    {
      respawnCoordinates = new Vector3 (respawnPoint.transform.position.x, respawnPoint.transform.position.y, respawnZ);
      transform.position = respawnCoordinates;   
      onPickupEffect("Respawn");
      rb.velocity = new Vector3 (0, 0, 0); 
      Stop = GameObject.FindGameObjectWithTag("Shuttlecock").GetComponent<Rigidbody2D>();
      Stop.constraints = RigidbodyConstraints2D.FreezeAll;
      yield return new WaitForSeconds(2);   
      Stop.constraints = RigidbodyConstraints2D.None;
      onPickupEffect("RespawnDone");
    }

    private IEnumerator disableMagnet() // timer for magnet item
    {
      yield return new WaitForSeconds(10);
      Debug.Log("magnetend");
      isMagnet = false;
    }

    private IEnumerator disableObs() // timer for smash item
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

    /*
    Switch cases for effects for different item pickups.
    Gets the item tag and plays the corresponding effect.
    */

    private void onPickupEffect(string tag)
    {
      switch (tag)
      {
        case "Coin":
          coinSoundEffect.Play();
          break;
        
        case "Heart":
          heartSoundEffect.Play();
          break;
        
        case "Smash":
          bombSoundEffect.Play();
          break;
        
        case "Magnet":
          magnetSoundEffect.Play();
          break;
        
        case "Enlarge":
          enlargeSoundEffect.Play();
          break;
        
        case "Respawn":
          respawnMaterial.SetFloat("_isRespawn", 1.1f); // trigger boolean in shader to flash
          break;
        
        case "RespawnDone":
          respawnMaterial.SetFloat("_isRespawn", 0f); // reset boolean in shader to stop flashing
          break;

        default:
          break;
      }
    }
}
