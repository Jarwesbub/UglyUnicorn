using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScoreScript : MonoBehaviour
{
    // NOT IN USE RIGHT NOW -> REACTIONSSCRIPT IS NOW USED
    // This script shows how much you get score
    // Score itself is located in StatsScript

    public Text AddTxt;
    public int AddScore;
    float Time;

    void Start()
    {
        AddTxt.text = "  ";

    }


    public void ShowAddScore(int addScore)
    {
        AddScore = addScore;

        AddTxt.text = AddScore.ToString();
        AddTxt.text = "+ " + AddTxt.text;

        Time += 1f;
        StartCoroutine(ScoreTimer());

    }

    IEnumerator ScoreTimer()
    {
        if (Time > 1f)
        {
            Time = 1f;
        }

        yield return new WaitForSeconds(Time);
        AddTxt.text = "  ";
        
    }

}
