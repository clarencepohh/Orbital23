using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for magnet item

public class Magnet : MonoBehaviour
{
    private Transform Player;

    void Start()
    {
        Player = GameObject.Find("Shuttlecock").GetComponent<Transform>();
    }

    void Update()
    {
        if(ItemCollector.isMagnet == true)
        {
            if (Vector3.Distance(transform.position , Player.position) < 3)  // if coin object within magnet radius, move to shuttlecock
            {
              transform.position = Vector3.MoveTowards(transform.position, Player.position, 0.01f);
            }
        }
    }
}
