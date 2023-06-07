using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for obstacles to spawn infinitely based on position of shuttlecock, added to Collectibles

public class SpawnObstacle : MonoBehaviour
{
    public GameObject prefabObs;
    private Transform playerTransform;
    private float spawnY = 0.0f; // position on Y axis to spawn items
    private float length = 5f;   // distance between 2 items
    private int amtobj = 5;     // number of each item on screen 
    public float minHeight = -5f;  // range of where items can spawn, for randomness
    public float maxHeight = 5f;
    public float leftBound = -5f;
    public float rightBound = 5f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Shuttlecock").transform; 

        for (int i = 0; i < amtobj; i++)
        {
            SpawnObs();
        }
        
    }

    void Update()
    {
        if (playerTransform.position.y > (spawnY - amtobj * length))
        {
            SpawnObs();
        }
    }

    private void SpawnObs(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(prefabObs) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.up * spawnY;
        go.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        go.transform.position += Vector3.left * Random.Range(leftBound, rightBound);
        spawnY += length;

    }
}
