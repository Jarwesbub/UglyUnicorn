using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro

public class EndResultsScript : MonoBehaviour
{
    public GameObject ResultsScreenObj;
    public GameObject Player;
    public GameObject Balls;
    public GameObject GameplayUI;
    
    public GameObject NewRecord;
    public GameObject AudioManager;

    public AudioSource EndResultsSound;

    public TMP_Text ScoreTxt;
    public TMP_Text HighScoreTxt;
    public TMP_Text DifficultyTxt;


    int Score;
    public int HighScore;
    bool ShowScores = false;


    void OnEnable()
    {
        StartCoroutine(WaitTime());

    }

    public void RestartButton()
    {
        SceneManager.LoadScene("GameplayScene");

    }
    public void DifficultySelectButton()
    {
        SceneManager.LoadScene("DifficultySelectScene");

    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");

    }
    public void QuitGameButton()
    {
        Application.Quit();

    }

    void Update()
    {
        if (ShowScores == true)
        {
            DrawScore();

        }
    }



    IEnumerator WaitTime()
    {
        AudioManager.GetComponent<AudioControlScript>().EndScreenVolume(); // Lower volume when gets active

        yield return new WaitForSeconds(3.5f); // 2f original

        

        EndResultsSound.Play();

        ResultsScreenObj.SetActive(true);
        Player.SetActive(false);
        Balls.SetActive(false);
        GameplayUI.SetActive(false);
        NewRecord.SetActive(false);

        Score = GameObject.Find("Stats").GetComponent<StatsScript>().Score;

        ShowScores = true;
    }

    public void DrawScore()
    {
        /// Savedata for specific difficulty/level will be saved in Lvl1PlayerScript !
        
        int DifficultyLVL;

        /*
        if (HighScore == 0) // When playing first time -> no new high score text
        {
            HighScore = Score;
        }
        */
        if (Score > HighScore)
        {
            NewRecord.SetActive(true);
            HighScore = Score; ////When plyer makes new high score -> show new high score (not the old one)
        }

        ScoreTxt.text = Score.ToString();
        ScoreTxt.text = "Your Score: " + ScoreTxt.text;

        HighScoreTxt.text = HighScore.ToString();
        HighScoreTxt.text = "High Score: " + HighScoreTxt.text;





        DifficultyLVL = PlayerPrefs.GetInt("Difficulty");
        
        if (DifficultyLVL == 1)
        {
            DifficultyTxt.text = "Difficulty: Easy";

        }
        else if (DifficultyLVL == 2)
        {
            DifficultyTxt.text = "Difficulty: Normal";

        }
        else if (DifficultyLVL == 3)
        {
            DifficultyTxt.text = "Difficulty: Hard";

        }
        else
        {
            DifficultyTxt.text = "Difficulty: Error";
        }



    }

}
