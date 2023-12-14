using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void GoToDifficultySelectScene()
    {
        SceneManager.LoadScene("DifficultySelectScene");

    }

    public void GoToHighScoreScene()
    {
        SceneManager.LoadScene("HighScoreScene");

    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");

    }

    public void QuitGameButton()
    {
        Application.Quit();

    }

}
