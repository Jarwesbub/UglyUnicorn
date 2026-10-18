using UnityEngine;

public class AndroidFrameRateSettings : MonoBehaviour
{
    void Awake()
    {
        QualitySettings.vSyncCount = 0;

        int refreshRate = Mathf.RoundToInt(
            (float)Screen.currentResolution.refreshRateRatio.value
        );

        Application.targetFrameRate = refreshRate;
    }
}