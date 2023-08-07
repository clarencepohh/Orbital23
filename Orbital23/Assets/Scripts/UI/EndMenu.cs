using UnityEngine;
using UnityEngine.SceneManagement;

// Script for End Screen Scene

public class EndMenu : MonoBehaviour
{
    public void Quit() // quits the game
    {
        Application.Quit();
    }

    public void Restart() // reload game scene
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Menu() // returns to main menu
    {
        SceneManager.LoadScene("Start Screen");
    }
}
