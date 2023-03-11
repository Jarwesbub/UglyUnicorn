using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadScrollScript : MonoBehaviour
{
    public GameObject Stats;

    Material material;
    Vector2 offset;

    float BgSpeed1, BgSpeed2;
    public float xVelocity, yVelocity;

    private int CurrentBg;
    // Start is called before the first frame update

    private void Awake()
    {
        material = GetComponent<Renderer>().material;


    }



    void Start()
    {
        //offset = new Vector2(xVelocity, yVelocity);

        Stats = GameObject.Find("Stats");

        BgSpeed1 = Stats.GetComponent<StatsScript>().Speed;

        if (gameObject.tag == "Background1")
        {
            CurrentBg = 1; // Exactly same speed as balls move
        }

        if (gameObject.tag == "Background2")
        {
            CurrentBg = 2; 
        }

        if (gameObject.tag == "Background3")
        {
            CurrentBg = 3;
        }

        if (gameObject.tag == "Background4")
        {
            CurrentBg = 4;
        }
        if (gameObject.tag == "Background5")
        {
            CurrentBg = 5;
        }
        if (gameObject.tag == "Background6")
        {
            CurrentBg = 6;
        }


    }

    // Update is called once per frame
    void Update()
    {
        BgSpeed1 = Stats.GetComponent<StatsScript>().Speed;

        if (CurrentBg == 1) // Run platform
        {
            xVelocity = BgSpeed1 / 40; // Exactly same speed as balls move
        }

        if (CurrentBg == 2) // Close background
        {
            xVelocity = BgSpeed1 / 400; 
        }

        if (CurrentBg == 3) // Mountains
        {
            xVelocity = BgSpeed1 / 4000;
        }

        if (CurrentBg == 4) // Clouds
        {
            xVelocity = BgSpeed1 / 12000;
        }
        if (CurrentBg == 5) // Fog light
        {
            xVelocity = BgSpeed1 / 8000;
        }
        if (CurrentBg == 6) // Fog dark
        {
            xVelocity = BgSpeed1 / -12000;
        }


        offset = new Vector2(xVelocity, yVelocity);
        material.mainTextureOffset += offset * Time.deltaTime;





    }
}
