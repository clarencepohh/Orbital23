using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using Random = System.Random;

//Script for item interactions, set as different prefabs, added to Shuttlecock

public class LeaderboardTestItemCollector : MonoBehaviour
{
    private Random random = new Random();
    public int score = 0;
    
    private void Start()
    {
        score = random.Next(0, 101);
    }
}
