using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for Start Screen Scene

public class StartMenu : MonoBehaviour
{
    public float delayForClick = 0.1f;
    private GameObject music;
    private AudioSource clickSoundEffect;

    public IEnumerator LeaderboardCoroutine()
    {
        yield return buttonAudioClick();
        yield return new WaitForSeconds(delayForClick);
        SceneManager.LoadScene("Leaderboard");
    }

    public IEnumerator PlayCoroutine()
    {
        yield return buttonAudioClick();
        music = GameObject.FindWithTag("Music");
        Destroy(music);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator buttonAudioClick()
    {   
        bool done = false;
        clickSoundEffect = GetComponent<AudioSource>();
        clickSoundEffect.Play();
        done = true;
        yield return new WaitWhile(() => done == false);
    } 
    
    public void onLBButtonClick()
    {
        StartCoroutine(LeaderboardCoroutine());
    }

    public void onPlayButtonClick()
    {
        StartCoroutine(PlayCoroutine());
    }
}
