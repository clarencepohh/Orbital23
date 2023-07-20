using System.Collections;
using UnityEngine;
using TMPro;

public class EndScreenManager : MonoBehaviour
{
    private int endScore;
    public TextMeshProUGUI scoreText;
    private AudioSource clickSoundEffect;

    private void Start() 
    {
        endScore = ItemCollector.score;    
        scoreText.text = "Your score is: " + endScore + "\nClick to submit to leaderboard\n";
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
