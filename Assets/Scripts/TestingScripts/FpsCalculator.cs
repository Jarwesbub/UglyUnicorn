using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script calculate the current fps and show it to a text ui.
/// Only used in testing.
/// </summary>
public class FpsCalculator : MonoBehaviour
{
    public Text FPStext;
    public string formatedString = "{value} FPS";

    public float updateRateSeconds = 4.0F;

    int frameCount = 0;
    float dt = 0.0F;
    float fps = 0.0F;

    void Update()
    {
        frameCount++;
        dt += Time.unscaledDeltaTime;
        if (dt > 1.0 / updateRateSeconds)
        {
            fps = frameCount / dt;
            frameCount = 0;
            dt -= 1.0F / updateRateSeconds;
        }

        FPStext.text = "FPS: " + System.Math.Round(fps, 1).ToString();

    }

}