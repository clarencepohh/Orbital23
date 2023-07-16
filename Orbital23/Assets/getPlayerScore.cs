using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getPlayerScore : MonoBehaviour
{
    public PlayerScores playerScores;
    public static int currentScore; 
    void Start()
    {
        this.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + currentScore;
    }
}
