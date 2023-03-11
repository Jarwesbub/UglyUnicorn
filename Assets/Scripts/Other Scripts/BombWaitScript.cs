using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombWaitScript : MonoBehaviour
{
    float ElapsedTime;
    float Timer;
    public float WaitTimeSeconds;

    void OnEnable()
    {

        Timer = Time.deltaTime + WaitTimeSeconds;

    }

    void Update()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > Timer)
        {
            gameObject.GetComponent<BombWaitScript>().enabled = false;

        }
    }

    void OnDisable()
    {
        ElapsedTime = 0f;

        gameObject.GetComponent<SpawnerScript>().BombWaitTimer = false;


    }

}
