using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    public GameObject prefabCoin, prefabHeart, prefabSmash, prefabObs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float length = 5f;
    private int amtobj = 10;
    public float minHeight = -5f;
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
            SpawnObs();
        }
    }

    void Update()
    {
        if (playerTransform.position.y > (spawnZ - amtobj * length))
        {
            SpawnCoin();
            SpawnHeart();
            SpawnSmash();
            SpawnObs();
        }
    }    

    private void SpawnCoin(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(prefabCoin) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.up * spawnZ;
        go.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        go.transform.position += Vector3.left * Random.Range(leftBound, rightBound);
        spawnZ += length;

    }

    private void SpawnHeart(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(prefabHeart) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.up * spawnZ;
        go.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        go.transform.position += Vector3.left * Random.Range(leftBound, rightBound);
        spawnZ += length;

    }

    private void SpawnSmash(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(prefabSmash) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.up * spawnZ;
        go.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        go.transform.position += Vector3.left * Random.Range(leftBound, rightBound);
        spawnZ += length;

    }

    private void SpawnObs(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(prefabObs) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.up * spawnZ;
        go.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        go.transform.position += Vector3.left * Random.Range(leftBound, rightBound);
        spawnZ += length;

    }
}
