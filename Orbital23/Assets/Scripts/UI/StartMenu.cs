using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for Start Screen Scene

public class StartMenu : MonoBehaviour
{
    public float delayForClick = 0.1f; // time delay for button click sound to play after clicking button
    private GameObject music;
    private AudioSource clickSoundEffect;

    public IEnumerator LeaderboardCoroutine() // to play button click audio and load Leaderboard
    {
        yield return buttonAudioClick();
        yield return new WaitForSeconds(delayForClick);
        SceneManager.LoadScene("Leaderboard");
    }

    public IEnumerator PlayCoroutine() // to play button click audio and load Main Game
    {
        yield return buttonAudioClick();
        music = GameObject.FindWithTag("Music");
        Destroy(music);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator buttonAudioClick() // to play button click audio
    {   
        bool done = false;
        clickSoundEffect = GetComponent<AudioSource>();
        clickSoundEffect.Play();
        done = true;
        yield return new WaitWhile(() => done == false);
    } 
    
    public void onLBButtonClick() // to load Leaderboard
    {
        StartCoroutine(LeaderboardCoroutine());
    }

    public void onPlayButtonClick() // to load Main Game
    {
        StartCoroutine(PlayCoroutine());
    }

    public void Quit() // quits the game
    {
        Application.Quit();
    }
}
