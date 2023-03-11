using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSpeedsScript : MonoBehaviour
{
    public GameObject Stats;

    public float MainSpeed;
    public float BgSpeed1, BgSpeed2, BgSpeed3, BgSpeed4, BgSpeed5;

    // Start is called before the first frame update
    void Start()
    {
        MainSpeed = Stats.GetComponent<StatsScript>().Speed;

    }

    // Update is called once per frame
    void Update()
    {
        MainSpeed = Stats.GetComponent<StatsScript>().Speed;
        BgSpeed1 = -MainSpeed;



    }
}
