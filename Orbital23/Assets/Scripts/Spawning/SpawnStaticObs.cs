using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStaticObs : MonoBehaviour
{
    public GameObject Object;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float TimeBetweenSpawn;
    private float SpawnTime;

    void Update()
    {
        if(Time.time > SpawnTime)
        {
            Spawn(); //add obj limit
            SpawnTime = Time.time + TimeBetweenSpawn;
        }
    }

    void Spawn()
    {
        float X = Random.Range(minX, maxX);
        float Y = Random.Range(minY, maxY);

        Instantiate(Object, transform.position + new Vector3(X, Y, 0), transform.rotation);
    }
}   