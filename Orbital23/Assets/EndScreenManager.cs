using UnityEngine;
using TMPro;

public class EndScreenManager : MonoBehaviour
{
    private int endScore;
    public TextMeshProUGUI scoreText;

    private void Start() 
    {
        endScore = ItemCollector.score;    
        scoreText.text = "Your score is: " + endScore + "\nClick to submit to leaderboard\n";
    }
}
