using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    public GameObject Coin, Heart;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float TimebetSpawn;
    private float SpawnTime; 
   // public float amtobj;

    void Update()
    {
        if(Time.time > SpawnTime)
        {
            Spawn();
            SpawnTime = Time.time + TimebetSpawn;
        }
    }

    void Spawn()
    {
        float X = Random.Range(minX, maxX);
        float Y = Random.Range(minY, maxY);

        Instantiate(Coin, transform.position + new Vector3(X, Y, 0), transform.rotation);
        Instantiate(Heart, transform.position + new Vector3(X, Y, 0), transform.rotation);
    }
}
