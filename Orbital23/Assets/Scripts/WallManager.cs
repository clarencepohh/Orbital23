using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject wallprefab;

    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float wallLength = 10.0f;
    private int amtWalls = 2;

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
        if (playerTransform.position.y > (spawnZ - amtWalls * wallLength))
        {
            SpawnWall();
        }
    }

    private void SpawnWall(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(wallprefab) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.up * spawnZ;
        spawnZ += wallLength;
    }
}
