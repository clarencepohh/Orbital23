using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMovingObsLR : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    public int itemLimit;

    private float spawnTime;
    private int spawnedItemsCount;

    void Start()
    {
        spawnTime = Time.time + timeBetweenSpawn;
        spawnedItemsCount = 0;
    }

    void Update()
    {
        if (Time.time > spawnTime && spawnedItemsCount < itemLimit)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
            spawnedItemsCount++;
        }
    }

    void Spawn()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position + new Vector3(x, y, 0), transform.rotation);
    }

    public void DecreaseCounter()
    {
        spawnedItemsCount--;
    }

    public void ResetCounter()
    {
        spawnedItemsCount = 0;
    }
}
