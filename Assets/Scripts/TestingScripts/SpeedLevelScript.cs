using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Cheat script for adjusting game speed manually
// This script is only used for testing!

public class SpeedLevelScript : MonoBehaviour
{
    private GameObject Stats;
    private GameObject Spawner;


    public Text SpeedLevel;
    public Text SpeedTxt;
    public Text Difficulty;

    public int currentSpeedLevel;
    int difficultyLevel;
    public float speed;


    void Start()
    {
        Stats = GameObject.Find("Stats");
        Spawner = GameObject.Find("Spawner");

        difficultyLevel = Spawner.GetComponent<SpawnerScript>().difficultyLevel;

        Difficulty.text = difficultyLevel.ToString();
        Difficulty.text = "Difficulty: " + Difficulty.text;

    }

    void Update()
    {
        currentSpeedLevel = Spawner.GetComponent<SpawnerScript>().level;
        SpeedLevel.text = currentSpeedLevel.ToString();
        SpeedLevel.text = "Speed Level " + SpeedLevel.text;

        speed = Stats.GetComponent<StatsScript>().Speed;
        speed = Mathf.Round(speed * 100f) / 100f;

        SpeedTxt.text = speed.ToString();
        
        SpeedTxt.text = "Speed = " + SpeedTxt.text;
        
        // Manipulates local game speed
        if (Input.GetKeyDown(KeyCode.KeypadPlus)) // Testing
        {
            Stats.GetComponent<StatsScript>().Speed += 1;
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus)) // Testing
        {
            Stats.GetComponent<StatsScript>().Speed -= 1;
        }

    }



}
