using UnityEngine;
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

    // Start is called before the first frame update
    void Start()
    {
        playerScore = random.Next(0, 101);
        scoreText.text = "Score: " + playerScore;
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

    private void UpdateScore()
    {
        if (user == null)
        {
            scoreText.text = "No such user";
        } 
        else 
        {
            scoreText.text = "Score: " + user.userScore;
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
            UpdateScore();
        });
    }
}
