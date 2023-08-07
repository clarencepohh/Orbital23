using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for Leaderboard screen

public class Leaderboard : MonoBehaviour
{
    private AudioSource clickSoundEffect;
    public IEnumerator buttonAudioClick()
    {   
        bool done = false;
        clickSoundEffect = GetComponent<AudioSource>();
        clickSoundEffect.Play();
        done = true;
        yield return new WaitWhile(() => done == false);
    } 

    public void onBackButtonClick()
    {
        StartCoroutine(BackButtonCoroutine());
    }

    // to play button click audio and load Start Screen
    public IEnumerator BackButtonCoroutine()
    {
        yield return buttonAudioClick();
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Start Screen");
    }
}