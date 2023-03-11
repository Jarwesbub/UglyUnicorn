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

    private int Volume;
    private int Music;

    void Awake()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            Volume = PlayerPrefs.GetInt("volume");

        }
        else
        {
            PlayerPrefs.SetInt("volume", 1);
        }
        if (PlayerPrefs.HasKey("music"))
        {
            Music = PlayerPrefs.GetInt("music");

        }
        else
        {
            PlayerPrefs.SetInt("music", 1);
        }

        Volume = PlayerPrefs.GetInt("volume");
        Music = PlayerPrefs.GetInt("music");


    }

    void Start()
    {
        if (Volume == 1)
        {
            Vol_Btn.GetComponent<Image>().sprite = Vol_ON;
        }
        else
        {
            Vol_Btn.GetComponent<Image>().sprite = Vol_OFF;
        }

        if (Music == 1)
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

        if (Volume == 1)
        {
            Volume = 0;
            Vol_Btn.GetComponent<Image>().sprite = Vol_OFF;
            PlayerPrefs.SetInt("volume", Volume);
        }
        else
        {
            Volume = 1;
            Vol_Btn.GetComponent<Image>().sprite = Vol_ON;
            PlayerPrefs.SetInt("volume", Volume);
        }


    }

    public void MusicButton()
    {
        if (Music == 1)
        {
            Music = 0;
            Music_Btn.GetComponent<Image>().sprite = Music_OFF;
            PlayerPrefs.SetInt("music", Music);

        }
        else
        {
            Music = 1;
            Music_Btn.GetComponent<Image>().sprite = Music_ON;
            PlayerPrefs.SetInt("music", Music);

        }



    }
}
