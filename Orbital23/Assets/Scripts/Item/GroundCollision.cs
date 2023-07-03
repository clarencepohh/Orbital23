using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to destroy items below the user by checking for collision with ground object and continue spawning new items
// itemCount to track number of items currently spawned

public class GroundCollision : MonoBehaviour
{
    SpawnCoin coinCount;
    SpawnEnlarge enlargeCount;
    SpawnHeart heartCount;
    SpawnMagnet magnetCount;
    SpawnSmash smashCount;
    SpawnStaticObs statobsCount;
    SpawnMovingObsLR LRcount;
    SpawnMovingObsUD UDcount;

    void Start()
    {
        coinCount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnCoin>();
        enlargeCount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnEnlarge>();
        heartCount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnHeart>();
        magnetCount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnMagnet>();
        smashCount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnSmash>();
        statobsCount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnStaticObs>();
        LRcount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnMovingObsLR>();
        UDcount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnMovingObsUD>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            coinCount.DecreaseCounter();
            enlargeCount.DecreaseCounter();
            heartCount.DecreaseCounter();
            magnetCount.DecreaseCounter();
            smashCount.DecreaseCounter();
            statobsCount.DecreaseCounter();
            LRcount.DecreaseCounter();
            UDcount.DecreaseCounter();  
        }
    }
}