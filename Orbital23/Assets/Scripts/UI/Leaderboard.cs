using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for Leaderboard screen

public class Leaderboard : MonoBehaviour
{
    public void Back()
    {
       SceneManager.LoadScene("Start Screen"); 
    }

}