using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for items to spawn infinitely based on position of shuttlecock, added to Collectibles

public class SpawnItem : MonoBehaviour
{
    public GameObject prefabCoin, prefabHeart, prefabSmash, prefabMagnet;
    private Transform playerTransform;
    private float spawnY = 0.0f; // position on Y axis to spawn items
    private float length = 5f;   // distance between 2 items
    public int amtobj = 10;     // number of each item on screen 
    public float minHeight = -5f;  // range of where items can spawn, for randomness
    public float maxHeight = 5f;
    public float leftBound = -5f;
    public float rightBound = 5f;

    void Start()
    {
       playerTransform = GameObject.FindGameObjectWithTag("Shuttlecock").transform; 

        for (int i = 0; i < amtobj; i++)
        {
            SpawnCoin();
            SpawnHeart();
            SpawnSmash();
            SpawnMagnet();
        }
    }

    void Update()
    {
        if (playerTransform.position.y > (spawnY - amtobj * length))
        {
            SpawnCoin();
            SpawnHeart();
            SpawnSmash();
            SpawnMagnet();
        }
    }    

    private void SpawnCoin(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(prefabCoin) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.up * spawnY;
        go.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        go.transform.position += Vector3.left * Random.Range(leftBound, rightBound);
        spawnY += length;

    }

    private void SpawnHeart(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(prefabHeart) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.up * spawnY;
        go.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        go.transform.position += Vector3.left * Random.Range(leftBound, rightBound);
        spawnY += length;

    }

    private void SpawnSmash(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(prefabSmash) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.up * spawnY;
        go.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        go.transform.position += Vector3.left * Random.Range(leftBound, rightBound);
        spawnY += length;

    }

    private void SpawnMagnet(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(prefabMagnet) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.up * spawnY;
        go.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        go.transform.position += Vector3.left * Random.Range(leftBound, rightBound);
        spawnY += length;

    }
}
