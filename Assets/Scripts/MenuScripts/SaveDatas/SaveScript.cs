using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public void SetIntLvl1(string keyName, int value)
    {
        PlayerPrefs.SetInt(keyName, value);
    }

    public int GetintLvl1(string keyName)
    {
        return PlayerPrefs.GetInt(keyName);
    }
    
}
