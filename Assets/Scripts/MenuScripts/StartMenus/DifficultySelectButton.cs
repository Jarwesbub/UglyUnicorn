using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelectButton : MonoBehaviour
{
    public GameObject MusicMenu;

    public void SelectEasy()
    {

        PlayerPrefs.SetInt("Difficulty", 1);

        SkipChooseMusic();
        //OpenMusicMenu();

    }

    public void SelectNormal()
    {
        PlayerPrefs.SetInt("Difficulty", 2);

        SkipChooseMusic();
        //OpenMusicMenu();
    }

    public void SelectHard()
    {
        PlayerPrefs.SetInt("Difficulty", 3);

        SkipChooseMusic();
        //OpenMusicMenu();
    }

    public void GoToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");

        //OpenMusicMenu();
    }

    public void GetBack()
    {
        SceneManager.LoadScene("DifficultySelectScene");

    }


    private void OpenMusicMenu() //Choose music tracks 0-3!
    {
        MusicMenu.SetActive(true);

    }

    private void SkipChooseMusic() //Skips MusicMenu screen completely and goes to GamePlayScene!
    {
        int song = 1; //Basic song

        PlayerPrefs.SetInt("music1", song);
        SceneManager.LoadScene("GameplayScene");
    } 


}
