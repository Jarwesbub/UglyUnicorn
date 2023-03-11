using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn1Controller : MonoBehaviour
{
    private int DifficultyLevel;

    public GameObject Spawner;
    private GameObject Stats;
    public float minTime, maxTime, AddSpeed;
    public int Level = 1;
    int ChooseObj;
    public float AddSpeedBaseValue; // Change base level 1 difficulty add speed values (how much player gets speed/hit)
    float MinSpeed;
    public float SpeedValue = 7f; //Value when SpawnTimer changes spawn times
    public int PlayerGetHPNext = 5; //ORIGINAL = 3 // How many times bomb explodes on dragon -> player gets extra HP
    private float WaitTime;

    int SkipLevel;

    public bool SpawnStart = false;


    void Awake()
    {
        DifficultyLevel = PlayerPrefs.GetInt("Difficulty");
        GameObject.Find("DestroyerControl").GetComponent<DestroyerScript>().PlayerGetHPNext = PlayerGetHPNext;

        if (DifficultyLevel == 0)
        {
            DifficultyLevel = 1;
        }
        Stats = GameObject.Find("Stats");

        Spawner.GetComponent<SpawnerScript>().DifficultyLevel = DifficultyLevel;

        DifficultySetValues();
    }
    void Start()
    {
        // Base stats for AddSpeed float
        if (DifficultyLevel <= 1)
        {
            AddSpeedBaseValue = 0.25f;
        }
        else if (DifficultyLevel == 2)
        {
            AddSpeedBaseValue = 0.28f;
        }
        else if (DifficultyLevel == 3)
        {
            AddSpeedBaseValue = 0.30f;
        }
    }

    void DifficultySetValues()
    {
        float ObstacleWaitTimeSeconds = 6f; // When bomb is spawned -> this time determines when next bomb can be spawned again
        float SpawnActivationTime = 0.6f; // Cooldown time for Spawner to activate again (extra time before this script is activated)

        if (DifficultyLevel == 1) // DIFFICULTY = EASY
        {
        ObstacleWaitTimeSeconds = 6f;
        SpawnActivationTime = 0.3f;// 0.5f ORIGINAL
            MinSpeed = 5f;
        Stats.GetComponent<StatsScript>().EasyMinSpeed = MinSpeed;
        }
        if (DifficultyLevel == 2) // DIFFICULTY = NORMAL
        {
            ObstacleWaitTimeSeconds = 6f;
            SpawnActivationTime = 0.2f;// 0.5f ORIGINAL
            MinSpeed = 7f;
            Stats.GetComponent<StatsScript>().NormalMinSpeed = MinSpeed;
        }
        if (DifficultyLevel == 3) // DIFFICULTY = HARD
        {
            ObstacleWaitTimeSeconds = 4f;
            SpawnActivationTime = 0.1f; // 0.2f ORIGINAL
            MinSpeed = 9f;
            Stats.GetComponent<StatsScript>().HardMinSpeed = MinSpeed;

        }

        Stats.GetComponent<StatsScript>().MinSpeed = MinSpeed;
        Spawner.GetComponent<SpawnerScript>().WaitSpawnerTime = SpawnActivationTime; //How long wait before Spawn1Controller activates again (controlled in SpawnerScript)
        GameObject.Find("Spawner").GetComponent<BombWaitScript>().WaitTimeSeconds = ObstacleWaitTimeSeconds;
    }

    public void GetSpawnTimer()
    {
        GetSpeedLevels(); // Check how fast balls are moving before going SpawnTimer coroutine
    }

    void GetSpeedLevels()
    {
        float SpeedCalc = Stats.GetComponent<StatsScript>().Speed;
        float MaxSpeed = 7f; // Level 1 Speed value
        Level = 1;

        // Adds +3 MaxSpeed value / Level
        if (SpeedCalc > MaxSpeed)
        {
            do
            {
                MaxSpeed += 3;
                Level += 1;
            }
            while (SpeedCalc > MaxSpeed);
        }
        ////
        // Level 1 base values
        int lvl = 1;
        minTime = 3.5f;
        maxTime = 4.1f; //4f original

        AddSpeed = AddSpeedBaseValue;

        if (lvl < Level)
        {
            do
            {
                minTime = minTime - (minTime / 4);
                maxTime = maxTime - (maxTime / 4);
                lvl += 1;
                AddSpeed = AddSpeed - (AddSpeed / 4);


            }
            while (lvl < Level && lvl < 10); // After level 10 -> (humanly impossible)
        }

        StartCoroutine(SpawnTimer1());

    }


    IEnumerator SpawnTimer1() // how long does it take to spawn objects
    {

        WaitTime = 1f; // Resets old value (not necessary but for possible bugs)

        WaitTime = Random.Range(minTime, maxTime);

        yield return new WaitForSeconds(WaitTime);

        //SpawnStart = true;
        Spawner.GetComponent<SpawnerScript>().AddSpeed = AddSpeed;
        Spawner.GetComponent<SpawnerScript>().Level = Level;
        Spawner.GetComponent<SpawnerScript>().SpawnStart = true;
    }


    public void ChooseObject(int lvl) // Choose random object (%)
    {
        int Percent = 0; // 1=2%

        if (lvl == 0 || lvl == 1)
        {
            Percent = Random.Range(1, 51); //50=100%

            if (Percent > 0 && Percent <= 50)
            {
                ChooseObj = Random.Range(1, 3);
            }
            else
            {
                ChooseObj = 3; // Obstacle
            }
        }

        if (lvl == 2)
        {
            Percent = Random.Range(1, 51); //50=100%

            if (Percent > 0 && Percent <= 45)
            {
                ChooseObj = Random.Range(1, 3);
            }
            else
            {
                ChooseObj = 3; // Obstacle
            }
        }

        if (lvl >= 3)
        {
            Percent = Random.Range(1, 51); //50=100%

            if (Percent > 0 && Percent <= 45)
            {
                ChooseObj = Random.Range(1, 3);
            }
            else
            {
                ChooseObj = 3; // Obstacle
            }
        }
        //////////////
        if (ChooseObj == 3) // if nex object is going to be obstacle
        {

            ChooseObj = Random.Range(3, 4 + 1); // Choose between 2 objects (3 or 4)

        }




        Spawner.GetComponent<SpawnerScript>().ChooseObj = ChooseObj;


    }

}

/* OLD VALUES
 * 
if (SpeedCalc < 7f)
{
    Level = 1;
}
else if (SpeedCalc < 10f)
{
    Level = 2;
}
else if (SpeedCalc < 12f)
{
    Level = 3;
}
else if (SpeedCalc < 15f)
{
    Level = 4;
}
else if (SpeedCalc < 19f)
{
    Level = 5;
}
else if (SpeedCalc < 26f)
{
    Level = 6;
}
else if (SpeedCalc > 26f)
{
    Level = 7; // MAX LEVEL
}
*/