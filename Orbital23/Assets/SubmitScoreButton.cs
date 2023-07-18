using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubmitScoreButton : MonoBehaviour
{
    public PlayerNameManager playerNameManager;
    int score;
    public void SubmitScore()
    {
        score = ItemCollector.score;
        StartCoroutine(SubmitScoreRoutine());
    }

    IEnumerator SubmitScoreRoutine()
    {
        yield return playerNameManager.SubmitScoreRoutine(score);
    }
}
