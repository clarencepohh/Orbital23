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
        if (endScore == 0)
        {
            scoreText.text = "\nTry harder next time!\nYour score is: " + endScore;
            button.gameObject.SetActive(false);
            inputField.gameObject.SetActive(false);
        }
        else
        {
            scoreText.text = "Your score is: " + endScore + "\nClick to submit to leaderboard\n";
        }    
    }
    public IEnumerator buttonAudioClick()
    {   
        bool done = false;
        clickSoundEffect = GetComponent<AudioSource>();
        clickSoundEffect.Play();
        done = true;
        yield return new WaitWhile(() => done == false);
    } 

    public void onPressAudio()
    {
        StartCoroutine(buttonAudioClick());
        new WaitForSeconds(0.1f);
    }
}
