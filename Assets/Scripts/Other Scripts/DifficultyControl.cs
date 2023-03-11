using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyControl : MonoBehaviour
{
    public GameObject SpawnControl1;
    public GameObject SpawnControl2;
    public GameObject SpawnControl3;


    void Awake()
    {
        //if (PlayerPrefs.GetInt("Difficulty") != null)
        {
            if (PlayerPrefs.GetInt("Difficulty") <= 1)
            {
                SpawnControl1.SetActive(true);
                SpawnControl2.SetActive(false);
                SpawnControl3.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Difficulty") <= 2)
            {
                SpawnControl1.SetActive(false);
                SpawnControl2.SetActive(true);
                SpawnControl3.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Difficulty") <= 3)
            {
                SpawnControl1.SetActive(false);
                SpawnControl2.SetActive(false);
                SpawnControl3.SetActive(true);
            }


        }



    }


}
