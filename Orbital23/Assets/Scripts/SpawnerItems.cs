using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerItems : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = 1f;
    public float maxHeight = 5f;
    public float leftBound = -5f;
    public float rightBound = 5f;
    public float count = 0;
    public float limit = 5;
   
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        count = 0;
    }

   

    private void Spawn()
    {
        if (count >= limit)
        {
            return;
        }

        GameObject items = Instantiate(prefab, transform.position, Quaternion.identity);
        items.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        items.transform.position += Vector3.left * Random.Range(leftBound, rightBound);
        count++;
    } 
}
