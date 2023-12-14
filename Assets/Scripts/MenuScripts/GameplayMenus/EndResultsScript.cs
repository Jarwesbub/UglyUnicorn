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

    int score;
    public int highScore;
    bool showScores = false;


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
        if (showScores)
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

        score = GameObject.Find("Stats").GetComponent<StatsScript>().Score;
        showScores = true;
    }

    public void DrawScore()
    {
        int difficultyLVL;

        if (score > highScore)
        {
            NewRecord.SetActive(true);
            highScore = score; ////When plyer makes new high score -> show new high score (not the old one)
        }

        ScoreTxt.text = score.ToString();
        ScoreTxt.text = "Your Score: " + ScoreTxt.text;

        HighScoreTxt.text = highScore.ToString();
        HighScoreTxt.text = "High Score: " + HighScoreTxt.text;


        difficultyLVL = PlayerPrefs.GetInt("Difficulty");
        
        if (difficultyLVL == 1 )
        {
            DifficultyTxt.text = "Difficulty: Easy";

        }
        else if (difficultyLVL == 2)
        {
            DifficultyTxt.text = "Difficulty: Normal";

        }
        else if (difficultyLVL == 3)
        {
            DifficultyTxt.text = "Difficulty: Hard";

        }
        else
        {
            DifficultyTxt.text = "Difficulty: Error";
        }

    }

}
