using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubmitScoreButton : MonoBehaviour
{
    public PlayerNameManager playerNameManager;
    public int score;
    public void SubmitScore()
    {
        StartCoroutine(SubmitScoreRoutine());
    }

    IEnumerator SubmitScoreRoutine()
    {
        yield return playerNameManager.SubmitScoreRoutine(score);
    }
}
