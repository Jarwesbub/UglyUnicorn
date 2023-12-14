using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro

public class HighScoreMenuControl : MonoBehaviour
{
    public TMP_Text Easy, Normal, Hard;
    private int easyScore, normalScore, hardScore;


    void Start()
    {
        easyScore = PlayerPrefs.GetInt("HighScore1_Dif1"); ////
        normalScore = PlayerPrefs.GetInt("HighScore1_Dif2"); ////
        hardScore = PlayerPrefs.GetInt("HighScore1_Dif3"); ////

        if (easyScore == 0)
        {
            Easy.text = "- ";
        }
        else
        {
            Easy.text = easyScore.ToString();

        }

        if (normalScore == 0)
        {
            Normal.text = "- ";
        }
        else
        {
            Normal.text = normalScore.ToString();

        }

        if (hardScore == 0)
        {
            Hard.text = "- ";
        }
        else
        {
            Hard.text = hardScore.ToString();
        }

    }

}
