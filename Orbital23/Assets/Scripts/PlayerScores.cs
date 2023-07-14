using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Random = System.Random;
using Proyecto26;
using TMPro;    

public class PlayerScores : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TMP_InputField nameText;
    private Random random = new Random();
    public static int playerScore;
    public static string playerName;
    User user = new User();
    private bool hasData;
    User[] userArray;

    void Start()
    {
        playerScore = random.Next(0, 101);
        scoreText.text = "Score: " + playerScore;
        GetLeaderboard();
    }

    public void OnSubmit()
    {
        playerName = nameText.text;
        PostToDatabase();
    }

    public void GetScore()
    {
        GetFromDatabase();
    }

    private void UpdateScore(bool hasData)
    {
        if (hasData) 
        {
            scoreText.text = "Score: " + user.userScore;
        } 
        else 
        {
            scoreText.text = "No such user";
        }
    }

    private void PostToDatabase()
    {   
        User user = new User();
        RestClient.Put("https://orbital23-coc-default-rtdb.asia-southeast1.firebasedatabase.app/" + playerName + ".json", user);
    }

    private void GetFromDatabase()
    {
        RestClient.Get<User>("https://orbital23-coc-default-rtdb.asia-southeast1.firebasedatabase.app/" + nameText.text + ".json").Then(response => 
        {
            user = response;
            Debug.Log("Found user data");
            hasData = true;
            UpdateScore(hasData);
        })
        
        .Catch(error =>
        {
            Debug.Log("No found data");
            hasData = false;
            UpdateScore(hasData);
        });
    }

    private void GetLeaderboard()
    {
        RestClient.GetArray<User>("https://orbital23-coc-default-rtdb.asia-southeast1.firebasedatabase.app/").Then(allUsers => {
            EditorUtility.DisplayDialog("JSON Array", JsonHelper.ArrayToJsonString<User>(allUsers, true), "Ok");
            userArray = allUsers;
            Debug.Log("Found user data");
            foreach (User user in userArray)
            {
                Debug.Log(user.userName + " | " + user.userScore);
            }
            hasData = true;
        });

        // RestClient.GetArray<User>("https://orbital23-coc-default-rtdb.asia-southeast1.firebasedatabase.app/.json").Then(allUsers => 
        // {
        //     userArray = allUsers;
        //     Debug.Log("Found user data");
        //     foreach (User user in userArray)
        //     {
        //         Debug.Log(user.userName + " | " + user.userScore);
        //     }
        //     hasData = true;
        // })
        
        // .Catch(error =>
        // {
        //     Debug.Log("No found data");
        //     hasData = false;
        // });
    } 

    // steps for the database page

    // 1. read data from the firebase realtime database

    // 2. store as a sorted array

    // 3. display the sorted array on the leaderboard page

    // 4. update the leaderboard page every time it is loaded


}
