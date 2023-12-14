//Use this script to fetch the settings and show them as text on the screen.

using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Lvl1PlayerPrefs : MonoBehaviour
{
    public GameObject Stats;
    public GameObject SaveObj;
    public GameObject EndResultsObj;

    public int NewScore;
    public int HighScore;

    string check;

    void OnEnable()
    {
        int DifficultyLVL = PlayerPrefs.GetInt("Difficulty");
        //Fetch the PlayerPref settings

        if (DifficultyLVL == 1) // Easy
        {
            HighScore = PlayerPrefs.GetInt("HighScore1_Dif1");
        }
        if (DifficultyLVL == 2) // Normal
        {
            HighScore = PlayerPrefs.GetInt("HighScore1_Dif2");
        }
        if (DifficultyLVL == 3) // Hard
        {
            HighScore = PlayerPrefs.GetInt("HighScore1_Dif3");
        }
        

        NewScore = Stats.GetComponent<StatsScript>().Score;
        //HighScore = PlayerPrefs.GetInt("highscorelevel1");
        

        if (NewScore > HighScore)
        {
            if (DifficultyLVL == 1) // Easy
            {
                PlayerPrefs.SetInt("HighScore1_Dif1", NewScore);
            }
            if (DifficultyLVL == 2) // Normal
            {
                PlayerPrefs.SetInt("HighScore1_Dif2", NewScore);
            }
            if (DifficultyLVL == 3) // Hard
            {
                PlayerPrefs.SetInt("HighScore1_Dif3", NewScore);
            }

        }

        //HighScore = PlayerPrefs.GetInt("highscorelevel1");

        EndResultsObj.GetComponent<EndResultsScript>().highScore = HighScore;

    }
    // Shows text on the screen with only code
    /* 
    void OnGUI()
    {
        //Fetch the PlayerPrefs settings and output them to the screen using Labels
        GUI.Label(new Rect(50, 100, 200, 30), "Score : " + NewScore);
        GUI.Label(new Rect(50, 130, 200, 30), "High Score : " + HighScore);
    }
    */
}
