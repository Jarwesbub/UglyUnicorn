using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //public GameObject HighScoreScreen;

    public void GoToDifficultySelectScene()
    {
        SceneManager.LoadScene("DifficultySelectScene");

    }

    public void GoToHighScoreScene()
    {
        //HighScoreScreen.SetActive(true);


        SceneManager.LoadScene("HighScoreScene");

    }

    public void GoToMainMenu()
    {
        //HighScoreScreen.SetActive(false);

        SceneManager.LoadScene("MainMenuScene");


    }

    public void QuitGameButton()
    {
        Application.Quit();

    }

}
