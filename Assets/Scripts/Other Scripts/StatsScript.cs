using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI; //Health
using TMPro; // TextMeshPro

public class StatsScript : MonoBehaviour
{
    public GameObject EndResultsObj; //UI Object that Enables Results screen (high-score)
    public GameObject PlayerControl;
    public GameObject PlayerDiesScriptObj;

    public float Speed; // Speed float for MoveScript
    public float MinSpeed = 5f;
    public int Damage; // How many balls player misses
    public int GetHP = 0;
    int DifficultyLevel;
    public float EasyMinSpeed, NormalMinSpeed, HardMinSpeed;

    public int health;
    public int numOfHearts;
    public int Score;
    public int AddedScore;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public TMP_Text ScoreTxt;
    public bool PlayerDies;
    float LerpTime;
    public float LerpSlowDownValue; // How fast speed slows when PlayerDies = true (smalled value -> slower change)

    // void Start()
    void Awake()
    {
        PlayerDiesScriptObj.SetActive(false);

        DifficultyLevel = GameObject.Find("Spawner").GetComponent<SpawnerScript>().difficultyLevel;
        
        if (DifficultyLevel == 1)
        {
            MinSpeed = EasyMinSpeed;
        }
        else if(DifficultyLevel == 2)
        {
            MinSpeed = NormalMinSpeed;
        }
        else if(DifficultyLevel == 3)
        {
            MinSpeed = HardMinSpeed;
        }


        //LerpTime = 0.05f;

        PlayerDies = false;
        health = numOfHearts;

        ScoreTxt.text = Score.ToString();
        ScoreTxt.text = "" + ScoreTxt.text;
    }


    void Update()
    {

        if (Speed < MinSpeed && PlayerDies == false)
        {
            Speed = MinSpeed;
        }
        else if (PlayerDies == true)
        {
            if (Speed > 0.5f)
            {
                LerpTime += (LerpSlowDownValue / 1000) * Time.deltaTime;

                Speed = Mathf.Lerp(Speed, 0, LerpTime);

                PlayerDiesScriptObj.SetActive(true);
            }
            else
            {
                Speed = 0;
            }
            
        }

        HPControl();
        //ScoreControl(0);
    }

    public void DecreaseSpeed() // Original location = DestoryerScript public void DamageControl()
    {
        float SlowSpeed;
        SlowSpeed = Speed;

        if (Speed <= 12f)
        {
            SlowSpeed -= 2f;
        }
        else
        {
            SlowSpeed -= 3f;
            //SlowSpeed = 8f;
        }


        Speed = SlowSpeed;
        Damage += 1;
        PlayerControl.GetComponent<PlayerController>().SetPlayerGotHit(true);



    }


    void HPControl()
    {
        if (Damage > 0)
        {
            health = health - Damage;
            Damage = 0;
        }
        if (GetHP > 0)
        {
            health += GetHP;
            GetHP = 0;
        }


        if (health > numOfHearts)
        {
            health = numOfHearts;
        }


        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (health < 1)
        {
            PlayerDies = true;
            EndResultsObj.SetActive(true);
            
        }


    }

    /*Score = (Speed * 2) + HitQuality

    */
    public void ScoreControl(int Value) //Value = HitboxCheck from ReactionsScript (determines how many points you get / hit
    {
        int speed = (int)Speed;

        AddedScore = speed * 2;

        if (Value == 1) //Awesome hit
        {
            AddedScore += 10;

        }
        else if (Value == 2) //Nice hit
        {
            AddedScore += 5;

        }
        else if (Value == 3) //OK hit
        {
            AddedScore += 0;

        }

        Score += AddedScore;

        ScoreTxt.text = Score.ToString();
        ScoreTxt.text = "" + ScoreTxt.text;

        gameObject.GetComponent<ReactionsScript>().ShowAddScore(AddedScore);
    }

    void CheckSpeed(int Value)
    {
        int speed = (int) Speed;

         Value = speed * 10;



    }

}



