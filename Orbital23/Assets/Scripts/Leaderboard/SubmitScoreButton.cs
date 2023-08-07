using System.Collections;
using UnityEngine;

public class SubmitScoreButton : MonoBehaviour
{
    public PlayerNameManager playerNameManager;
    int score;

    // get player's score from the game and starts coroutine to submit score
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
