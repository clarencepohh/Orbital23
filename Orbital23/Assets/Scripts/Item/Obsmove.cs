using System.Collections;
using UnityEngine;

// Script for moving obstacles, obstacle moves between 2 points set in prefab

public class Obsmove : MonoBehaviour
{
    public float speed;
    Vector3 targetPos;
    public GameObject ways;
    public Transform[] wayPoints;
    int pointIndex;
    int pointCount;
    int direction = 1;
    public float waitDuration;
    int speedMultiplier = 1;

    private void Awake() // set up for location and number of points
    {
        wayPoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.gameObject.transform.childCount; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i).gameObject.transform;
        }
    }
    
    void Start()
    {
        pointCount = wayPoints.Length;
        pointIndex = 1;
        targetPos = wayPoints[pointIndex].transform.position;
    }

    void Update()
    {
       var step = speedMultiplier * speed * Time.deltaTime;
       transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

       if (transform.position == targetPos)
       {
          NextPoint();
       } 
    }


    void NextPoint() // cycles through points
    {
        if (pointIndex == pointCount - 1)
        {
            direction = -1;
        }

        if (pointIndex == 0)
        {
            direction = 1;
        }

        pointIndex += direction;
        targetPos = wayPoints[pointIndex].transform.position;
        StartCoroutine(WaitNextPoint());
    }

    IEnumerator WaitNextPoint() // adds delay when object reaches a point
    {
        speedMultiplier = 0;
        yield return new WaitForSeconds(waitDuration);
        speedMultiplier = 1;
    }
}
