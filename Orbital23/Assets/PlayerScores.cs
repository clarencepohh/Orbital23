using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
public class PlayerScores : MonoBehaviour
{
    public Text scoreText;
    public InputField nameText;
    private Random random = new Random();
    public int playerScore;
    public string playerName;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = random.Next(0, 101);
        scoreText.text = "Score: " + playerScore;
    }

    public void OnSubmit()
    {
        playerName = nameText.text;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
