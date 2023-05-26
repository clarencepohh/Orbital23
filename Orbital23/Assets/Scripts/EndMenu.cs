using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for End Screen Scene

public class EndMenu : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Start Screen");
    }
}
