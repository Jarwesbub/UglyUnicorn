using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject Spawner;
    private GameObject Stats;
    private int difficultyLevel;
    private float minTime, maxTime, addSpeed;
    private int currentLevel = 1;
    private int chooseObj;
    [SerializeField] private float AddSpeedBaseValue; // Change base level 1 difficulty add speed values (how much player gets speed/hit)
    private float minSpeed;
    private float waitTime;

    void Awake()
    {
        difficultyLevel = PlayerPrefs.GetInt("Difficulty");

        if (difficultyLevel == 0)
        {
            difficultyLevel = 1;
        }
        Stats = GameObject.Find("Stats");

        Spawner.GetComponent<SpawnerScript>().difficultyLevel = difficultyLevel;

        DifficultySetValues();
    }
    void Start()
    {
        // Base stats for AddSpeed float
        if (difficultyLevel <= 1)
        {
            AddSpeedBaseValue = 0.25f;
        }
        else if (difficultyLevel == 2)
        {
            AddSpeedBaseValue = 0.28f;
        }
        else // Level 3 or more
        {
            AddSpeedBaseValue = 0.30f;
        }
    }

    void DifficultySetValues()
    {
        float obstacleWaitTimeSeconds; // When bomb is spawned -> this time determines when next bomb can be spawned again
        float spawnActivationTime; // Cooldown time for Spawner to activate again (extra time before this script is activated)

        if (difficultyLevel == 1) // DIFFICULTY = EASY
        {
        obstacleWaitTimeSeconds = 6f;
        spawnActivationTime = 0.3f;
            minSpeed = 5f;
        Stats.GetComponent<StatsScript>().EasyMinSpeed = minSpeed;
        }
        else if (difficultyLevel == 2) // DIFFICULTY = NORMAL
        {
            obstacleWaitTimeSeconds = 6f;
            spawnActivationTime = 0.2f;
            minSpeed = 7f;
            Stats.GetComponent<StatsScript>().NormalMinSpeed = minSpeed;
        }
        else // DIFFICULTY = HARD
        {
            obstacleWaitTimeSeconds = 4f;
            spawnActivationTime = 0.1f;
            minSpeed = 9f;
            Stats.GetComponent<StatsScript>().HardMinSpeed = minSpeed;

        }

        Stats.GetComponent<StatsScript>().MinSpeed = minSpeed;
        Spawner.GetComponent<SpawnerScript>().waitSpawnerTime = spawnActivationTime; //How long wait before SpawnController activates again (controlled in SpawnerScript)
        GameObject.Find("Spawner").GetComponent<BombWaitScript>().waitTimeSeconds = obstacleWaitTimeSeconds;
    }

    public void GetSpawnTimer()
    {
        GetSpeedLevels(); // Check how fast balls are moving before going SpawnTimer coroutine
    }

    void GetSpeedLevels()
    {
        float SpeedCalc = Stats.GetComponent<StatsScript>().Speed;
        float MaxSpeed = 7f; // Level 1 Speed value
        currentLevel = 1;

        // Adds +3 MaxSpeed value / Level
        if (SpeedCalc > MaxSpeed)
        {
            do
            {
                MaxSpeed += 3;
                currentLevel += 1;
            }
            while (SpeedCalc > MaxSpeed);
        }

        // Level 1 base values
        int lvl = 1;
        minTime = 3.5f;
        maxTime = 4.1f; //4f original

        addSpeed = AddSpeedBaseValue;

        if (lvl < currentLevel)
        {
            do
            {
                minTime = minTime - (minTime / 4);
                maxTime = maxTime - (maxTime / 4);
                lvl += 1;
                addSpeed = addSpeed - (addSpeed / 4);


            }
            while (lvl < currentLevel && lvl < 10); // After level 10 -> (humanly impossible)
        }

        StartCoroutine(SpawnTimer1());

    }

    IEnumerator SpawnTimer1() // how long does it take to spawn objects
    {

        waitTime = 1f; // Resets old value (not necessary but for possible bugs)

        waitTime = Random.Range(minTime, maxTime);

        yield return new WaitForSeconds(waitTime);

        //SpawnStart = true;
        Spawner.GetComponent<SpawnerScript>().addSpeed = addSpeed;
        Spawner.GetComponent<SpawnerScript>().level = currentLevel;
        Spawner.GetComponent<SpawnerScript>().spawnStart = true;
    }


    public void ChooseObject(int lvl) // Choose a random object based on given level and percent
    {
        int percent;

        if (lvl == 0 || lvl == 1)
        {
            percent = Random.Range(1, 51); //50=100%

            if (percent > 0 && percent <= 50)
            {
                chooseObj = Random.Range(1, 3);
            }
            else
            {
                chooseObj = Random.Range(3, 5); // Choose between 2 objects (3 or 4)
            }
        }
        else if (lvl == 2)
        {
            percent = Random.Range(1, 51); //50=100%

            if (percent > 0 && percent <= 45)
            {
                chooseObj = Random.Range(1, 3);
            }
            else
            {
                chooseObj = Random.Range(3, 5); // Choose between 2 objects (3 or 4)
            }
        }
        else // lvl 3 or more
        {
            percent = Random.Range(1, 51); //50=100%

            if (percent > 0 && percent <= 45)
            {
                chooseObj = Random.Range(1, 3);
            }
            else
            {
                chooseObj = Random.Range(3, 5); // Choose between 2 objects (3 or 4)
            }
        }

        Spawner.GetComponent<SpawnerScript>().chooseObj = chooseObj;

    }

}
