using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro

public class ReactionsScript : MonoBehaviour
{
    public GameObject Stats;
    public Image Bad;
    public Image Nice;
    public Image Awe;
    public Image Miss;

    public int Hitbox;

    bool startReact = false;
    bool missReaction = false;

    float time = 1f;
    public float elapsedTime;

    bool timerStart = false;

    public TMP_Text AddScoreTxt;
    public int AddScore;
    public float scoreTime;
    public float elapsedScoreTime;
    bool startScoreTime = false;

    void Start()
    {
        Stats = GameObject.Find("Stats");

        missReaction = false;
        Awe.enabled = false;
        Nice.enabled = false;
        Bad.enabled = false;
        Miss.enabled = false;

        AddScoreTxt.text = " ";
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (startReact)
        {
            startReact = false;

            Awe.enabled = false;
            Nice.enabled = false;
            Bad.enabled = false;
            Miss.enabled = false;

            time = (1f + elapsedTime);

            GetReactions();
            
            timerStart = true;

        }

        if (timerStart && time < elapsedTime)
        {
            timerStart = false;
            Awe.enabled = false;
            Nice.enabled = false;
            Bad.enabled = false;
            Miss.enabled = false;

        }

        //SCORE
        if (startScoreTime == true)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > scoreTime)
            {
                startScoreTime = false;
                AddScoreTxt.text = " ";
            }


        }

    }

    public void StartReactions(bool Success)
    {
        if (Success)
        {
            startReact = true;
            missReaction = false;
        }
        else
        {
            startReact = true;
            missReaction = true;
        }

    }

    void GetReactions()
    {
        int HitboxCheck = Hitbox;

        if (!missReaction)
        {
            if (HitboxCheck == 1) // Awesome hit
            {
                Stats.GetComponent<StatsScript>().ScoreControl(1);
                Awe.enabled = true;

            }
            else if (HitboxCheck == 2) // Nice hit
            {
                Stats.GetComponent<StatsScript>().ScoreControl(2);
                Nice.enabled = true;

            }
            else if (HitboxCheck == 3) // OK hit
            {
                Stats.GetComponent<StatsScript>().ScoreControl(3);
                Bad.enabled = true;

            }
            else //When Dragon gets damage ->
            {
                Stats.GetComponent<StatsScript>().ScoreControl(1);
                Awe.enabled = true;

            }
        }
        else
        {
            Miss.enabled = true;

        }

    }

    public void ShowAddScore(int addScore)
    {
        AddScore = addScore;
        float ScoreTimerDuration = 2f;

        AddScoreTxt.text = AddScore.ToString();
        AddScoreTxt.text = "+ " + AddScoreTxt.text;

        scoreTime = elapsedTime + ScoreTimerDuration;
        startScoreTime = true;

    }




}
