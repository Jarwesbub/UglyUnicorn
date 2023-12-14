using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombWaitScript : MonoBehaviour
{
    float ElapsedTime;
    float timer;
    public float waitTimeSeconds; // 5

    void OnEnable()
    {
        timer = Time.deltaTime + waitTimeSeconds;

    }

    void Update()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > timer)
        {
            gameObject.GetComponent<BombWaitScript>().enabled = false;

        }
    }

    void OnDisable()
    {
        ElapsedTime = 0f;

        gameObject.GetComponent<SpawnerScript>().bombWaitTimer = false;


    }

}
