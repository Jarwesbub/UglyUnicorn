using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedLevelScript : MonoBehaviour
{
    private GameObject Stats;
    private GameObject Spawner;


    public Text SpeedLevel;
    public Text SpeedTxt;
    public Text Difficulty;

    public int CurrentSpeedLevel;
    int DifficultyLevel;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        Stats = GameObject.Find("Stats");
        Spawner = GameObject.Find("Spawner");

        DifficultyLevel = Spawner.GetComponent<SpawnerScript>().DifficultyLevel;


        Difficulty.text = DifficultyLevel.ToString();
        Difficulty.text = "Difficulty: " + Difficulty.text;

    }

    // Update is called once per frame
    void Update()
    {
        CurrentSpeedLevel = Spawner.GetComponent<SpawnerScript>().Level;
        SpeedLevel.text = CurrentSpeedLevel.ToString();
        SpeedLevel.text = "Speed Level " + SpeedLevel.text;

        Speed = Stats.GetComponent<StatsScript>().Speed;
        Speed = Mathf.Round(Speed * 100f) / 100f;

        SpeedTxt.text = Speed.ToString();
        
        SpeedTxt.text = "Speed = " + SpeedTxt.text;
        

        if (Input.GetKeyDown(KeyCode.KeypadPlus)) ///TESTING///////////////////////////////////////////////////////////////////
        {
            Stats.GetComponent<StatsScript>().Speed += 1;
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus)) ///TESTING///////////////////////////////////////////////////////////////////
        {
            Stats.GetComponent<StatsScript>().Speed -= 1;
        }
        /*
        if (Input.GetKeyDown(KeyCode.Keypad1)) ///TESTING///////////////////////////////////////////////////////////////////
        {
            GameObject.Find("Stats").GetComponent<StatsScript>().health += 1;
        }
        */


    }



}
