using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Script for the wall boundaries, set as prefab, added to Environment
Walls to limit play area and spawn infinitely based on position of shuttlecock
*/

public class WallManager : MonoBehaviour
{
    public GameObject wallprefab;
    private Transform playerTransform;
    private float spawnY = 0.0f; // position on Y axis to spawn walls
    private float wallLength = 10.0f; // length of wall to spawn
    private int amtWalls = 2; // number of walls on screen 

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Shuttlecock").transform;

        for (int i = 0; i < amtWalls; i++)
        {
            SpawnWall();
        }
    }

    void Update()
    {
        if (playerTransform.position.y > (spawnY - amtWalls * wallLength))
        {
            SpawnWall();
        }
    }

    private void SpawnWall(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(wallprefab) as GameObject;
        go.transform.SetParent(transform);            // sets all walls to spawn under the Environment tab
        go.transform.position = Vector3.up * spawnY;
        spawnY += wallLength;
    }
}
