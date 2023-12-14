using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script updated: More optimized code

public class QuadScrollScript : MonoBehaviour
{
    public GameObject Stats;
    Material material;
    Vector2 offset;
    public float xVelocity, yVelocity;
    public int myBackgroundNumber;
    [SerializeField]private int speedLimiter;
    private float localSpeed;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;

        Stats = GameObject.Find("Stats");
        localSpeed = Stats.GetComponent<StatsScript>().Speed;
        GetMyBackgroundNumber();
    }

    private void Start()
    {
        SetMySpeedLimiter();
    }

    void GetMyBackgroundNumber()
    {
        switch (gameObject.tag)
        {
            case "Background1": // Run platform
                myBackgroundNumber = 1;
                break;
            case "Background2": // Near background
                myBackgroundNumber = 2;
                break;
            case "Background3": // Mountains
                myBackgroundNumber = 3;
                break;
            case "Background4": // Clouds
                myBackgroundNumber = 4;
                break;
            case "Background5": // Fog light
                myBackgroundNumber = 5;
                break;
            case "Background6": // Fog dark
                myBackgroundNumber = 6;
                break;
        }
    }

    void SetMySpeedLimiter()
    {
        switch (myBackgroundNumber)
        {
            case 1: // Run platform
                speedLimiter = 40; // Exactly same speed as balls move
                break;
            case 2: // Near background
                speedLimiter = 400;
                break;
            case 3: // Mountains
                speedLimiter = 4000;
                break;
            case 4: // Clouds
                speedLimiter = 12000;
                break;
            case 5: // Fog light
                speedLimiter = 8000;
                break;
            case 6: // Fog dark
                speedLimiter = -12000;
                break;
        }

    }

    void Update()
    {
        localSpeed = Stats.GetComponent<StatsScript>().Speed;
        xVelocity = localSpeed / speedLimiter;
        offset = new Vector2(xVelocity, yVelocity);
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
