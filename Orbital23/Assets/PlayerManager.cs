using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public LeaderboardManager leaderboard;
    public TMP_InputField playerNameInputField;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoginRoutine());
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputField.text, (response) => 
        {
            if (response.success)
            {
                Debug.Log("Successfully set player name");
            } 
            else 
            {
                Debug.Log("Could not set player name" + response.Error);
            }
        });
    }

    IEnumerator LoginRoutine()
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
