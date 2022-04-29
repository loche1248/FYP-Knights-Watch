//Reference - https://www.youtube.com/watch?v=-GWjA6dixV4
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }



    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
