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

    bool StartReact = false;
    bool MissReaction = false;
    //bool Reset = false;

    float time = 1f;
    public float ElapsedTime;
    //private Coroutine RunningTimer;

    bool TimerStart = false;

    public TMP_Text AddScoreTxt;
    public int AddScore;
    public float ScoreTime;
    public float ElapsedScoreTime;
    bool StartScoreTime = false;

    void Start()
    {
        Stats = GameObject.Find("Stats");

        MissReaction = false;

        Awe.enabled = false;
        Nice.enabled = false;
        Bad.enabled = false;
        Miss.enabled = false;

        AddScoreTxt.text = " ";
    }

    void Update()
    {
        ElapsedTime += Time.deltaTime;

        if (StartReact == true)
        {
            StartReact = false;

            Awe.enabled = false;
            Nice.enabled = false;
            Bad.enabled = false;
            Miss.enabled = false;

            time = (1f + ElapsedTime);

            GetReactions();
            
            TimerStart = true;


            /*
            StopCoroutine(ReactionsTimer());
            time = (1f + ElapsedTime);


            RunningTimer = StartCoroutine(ReactionsTimer());
            */

        }

        if (TimerStart == true && time < ElapsedTime)
        {
            TimerStart = false;

            Awe.enabled = false;
            Nice.enabled = false;
            Bad.enabled = false;
            Miss.enabled = false;

        }


        //SCORE
        if (StartScoreTime == true)
        {
            ElapsedTime += Time.deltaTime;

            if (ElapsedTime > ScoreTime)
            {
                StartScoreTime = false;
                AddScoreTxt.text = " ";
            }


        }

    }

    public void StartReactions(bool Success)
    {
        if (Success == true)
        {
            StartReact = true;
            MissReaction = false;
        }
        else
        {
            StartReact = true;
            MissReaction = true;
        }

    }

    void GetReactions()
    {
        int HitboxCheck = Hitbox;

        if (MissReaction == false)
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

        ScoreTime = ElapsedTime + ScoreTimerDuration;
        StartScoreTime = true;

    }




}
