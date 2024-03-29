using UnityEngine;

public class FrameRateSettings : MonoBehaviour
{
    public int VSyncValue; //0-4
    public int MaxFrameRate;

    void Start()
    {
        // Sync framerate to monitors refresh rate
        QualitySettings.vSyncCount = VSyncValue;
        Application.targetFrameRate = MaxFrameRate;
    }
}
