using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EndScreenManager : MonoBehaviour
{
    private int endScore;
    public TextMeshProUGUI scoreText;
    public Button button;
    public TMP_InputField inputField;
    private AudioSource clickSoundEffect;

    private void Start() 
    {
        endScore = ItemCollector.score;
        if (endScore == 0) // if score is 0, then player cannot submit their score as it will return an error from LootLocker
        {
            scoreText.text = "\nTry harder next time!\nYour score is: " + endScore; // \n for formatting purposes
            // disable the button and input field
            button.gameObject.SetActive(false); 
            inputField.gameObject.SetActive(false);
        }
        else // if score is not 0, enable the button and input field for player to submit their score
        {
            scoreText.text = "Your score is: " + endScore + "\nClick to submit to leaderboard\n\n";
        }    
    }
    public IEnumerator buttonAudioClick() // plays audio when button is clicked
    {   
        bool done = false;
        clickSoundEffect = GetComponent<AudioSource>();
        clickSoundEffect.Play();
        done = true;
        yield return new WaitWhile(() => done == false);
    } 

    public void onPressAudio() // calls buttonAudioClick() when button is pressed
    {
        StartCoroutine(buttonAudioClick());
        new WaitForSeconds(0.1f);
    }
}
