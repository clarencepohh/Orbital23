using System.Collections;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerNameManager : MonoBehaviour
{
    public TMP_InputField playerNameInputField;
    string leaderboardKey = "globalHighscore"; // Not a magic string, this is the key for the leaderboard on the LootLocker dashboard

    // Begin login coroutine on starting the game over screen
    private void Start() 
    {
        StartCoroutine(LoginRoutine());
    }

    IEnumerator LoginRoutine()
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
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputField.text, (response) => 
        {
            if (response.success) // if player name is set successfully
            {
                Debug.Log("Successfully set player name");
            } 
            else // if player name is not set successfully, display error message
            {
                Debug.Log("Could not set player name" + response.Error);
            }
        });
    }

    // Submit score to leaderboard
    public IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerId");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardKey, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Score was submitted");
                done = true;
            } 
            else 
            {
                Debug.Log("Could not submit score");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
