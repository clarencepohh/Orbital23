using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubmitScoreButton : MonoBehaviour
{
    public LeaderboardManager leaderboard;
    public LeaderboardTestItemCollector itemCollector;

    public void SubmitScoreRoutine()
    {
        StartCoroutine(SubmitScore());
    }

    IEnumerator SubmitScore()
    {
        yield return leaderboard.SubmitScoreRoutine(itemCollector.score);
    }
}
