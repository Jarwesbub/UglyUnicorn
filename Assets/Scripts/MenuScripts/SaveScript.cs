using UnityEngine;

public class SaveScript : MonoBehaviour
{
    //public int highscore;
    
    public void SetIntLvl1(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public int GetintLvl1(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
    
}
