using System.Collections;
using UnityEngine;
using LootLocker.Requests;

public class PlayerManager : MonoBehaviour
{
    public LeaderboardManager leaderboard;
    
    // Begin login coroutine on start
    void Start()
    {
        StartCoroutine(LoginRoutineWithLeaderboard());
    }


    IEnumerator LoginRoutineWithLeaderboard()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success) // if player is logged in 
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerId", response.player_id.ToString());
                done = true;
            } 
            else // if player is not logged in, display error message
            {
                Debug.Log("Could not start session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);

        // then attempt retrieval of scores for the leaderboard
        yield return leaderboard.FetchTopHighscoresRoutine();
    }
}
