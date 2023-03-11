using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioChooseScript : MonoBehaviour
{

    public void ChooseMuteTrack()
    {
        SetBgMusic(0);
    }


    public void ChooseTrack1()
    {
        SetBgMusic(1);
    }

    public void ChooseTrack2()
    {
        SetBgMusic(2);
    }

    public void ChooseTrack3()
    {
        SetBgMusic(3);
    }

    public void SetBgMusic(int song)
    {
        PlayerPrefs.SetInt("music1", song);

        SceneManager.LoadScene("GameplayScene");
    }
}
