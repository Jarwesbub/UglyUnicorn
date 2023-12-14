using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAudioControlScript : MonoBehaviour
{
    public Sprite Vol_ON;
    public Sprite Vol_OFF;
    public Sprite Music_ON;
    public Sprite Music_OFF;

    public Button Music_Btn;
    public Button Vol_Btn;

    private int volume;
    private int music;

    void Awake()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            volume = PlayerPrefs.GetInt("volume");
        }
        else
        {
            PlayerPrefs.SetInt("volume", 1);
        }

        if (PlayerPrefs.HasKey("music"))
        {
            music = PlayerPrefs.GetInt("music");

        }
        else
        {
            PlayerPrefs.SetInt("music", 1);
        }

        volume = PlayerPrefs.GetInt("volume");
        music = PlayerPrefs.GetInt("music");

    }

    void Start()
    {
        if (volume == 1)
        {
            Vol_Btn.GetComponent<Image>().sprite = Vol_ON;
        }
        else
        {
            Vol_Btn.GetComponent<Image>().sprite = Vol_OFF;
        }

        if (music == 1)
        {
            Music_Btn.GetComponent<Image>().sprite = Music_ON;
        }
        else
        {
            Music_Btn.GetComponent<Image>().sprite = Music_OFF;
        }
    }

    public void VolumeButton()
    {
        if (volume == 1)
        {
            volume = 0;
            Vol_Btn.GetComponent<Image>().sprite = Vol_OFF;
            PlayerPrefs.SetInt("volume", volume);
        }
        else
        {
            volume = 1;
            Vol_Btn.GetComponent<Image>().sprite = Vol_ON;
            PlayerPrefs.SetInt("volume", volume);
        }

    }

    public void MusicButton()
    {
        if (music == 1)
        {
            music = 0;
            Music_Btn.GetComponent<Image>().sprite = Music_OFF;
            PlayerPrefs.SetInt("music", music);

        }
        else
        {
            music = 1;
            Music_Btn.GetComponent<Image>().sprite = Music_ON;
            PlayerPrefs.SetInt("music", music);

        }

    }
}
