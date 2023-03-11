using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro

public class HighScoreMenuControl : MonoBehaviour
{
    public TMP_Text Easy, Normal, Hard;
    private int Difficulty, easyScore, normalScore, hardScore;

    // Start is called before the first frame update
    void Start()
    {
        Difficulty = PlayerPrefs.GetInt("Difficulty");

        easyScore = PlayerPrefs.GetInt("HighScore1_Dif1"); ////
        normalScore = PlayerPrefs.GetInt("HighScore1_Dif2"); ////
        hardScore = PlayerPrefs.GetInt("HighScore1_Dif3"); ////

        if (easyScore == 0)
        {
            //Easy.text = "Easy  -  Highest Score :  " + "<None>";
            Easy.text = "- ";
        }
        else
        {
            //Easy.text = "Easy  -  Highest Score :  " + easyScore.ToString();
            Easy.text = easyScore.ToString();

        }

        if (normalScore == 0)
        {
            //Normal.text = "Normal  -  Highest Score :  " + "<None>";
            Normal.text = "- ";
        }
        else
        {
            //Normal.text = "Normal  -  Highest Score :  " + normalScore.ToString();
            Normal.text = normalScore.ToString();

        }

        if (hardScore == 0)
        {
            //Hard.text = "Hard  -  Highest Score :  " + "<None>";
            Hard.text = "- ";
        }
        else
        {
            //Hard.text = "Hard  -  Highest Score :  " + hardScore.ToString();
            Hard.text = hardScore.ToString();
        }

        

    }

}
