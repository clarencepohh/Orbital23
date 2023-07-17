using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public LeaderboardManager leaderboard;
    
    void Start()
    {
        StartCoroutine(LoginRoutineWithLeaderboard());
    }


    IEnumerator LoginRoutineWithLeaderboard()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerId", response.player_id.ToString());
                done = true;
            } 
            else 
            {
                Debug.Log("Could not start session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
        yield return leaderboard.FetchTopHighscoresRoutine();
    }
}
