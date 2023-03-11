using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControlScript : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject AudioManager;
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
        /*
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
        */

        Volume = PlayerPrefs.GetInt("volume");
        Music = PlayerPrefs.GetInt("music");

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
        Volume = PlayerPrefs.GetInt("volume");

        if (Volume == 1)
        {
            Volume = 0;
            AudioListener.volume = Volume;
            Vol_Btn.GetComponent<Image>().sprite = Vol_OFF;
            PlayerPrefs.SetInt("volume", Volume);
        }
        else
        {
            Volume = 1;
            AudioListener.volume = Volume;
            Vol_Btn.GetComponent<Image>().sprite = Vol_ON;
            PlayerPrefs.SetInt("volume", Volume);
        }


    }

    public void MusicButton()
    {
        Music = PlayerPrefs.GetInt("music");

        if (Music == 1)
        {
            Music = 0;
            Music_Btn.GetComponent<Image>().sprite = Music_OFF;
            PlayerPrefs.SetInt("music", Music);
            AudioManager.GetComponent<AudioControlScript>().MuteSoundInGameplay();
        }
        else
        {
            Music = 1;
            Music_Btn.GetComponent<Image>().sprite = Music_ON;
            PlayerPrefs.SetInt("music", Music);
            AudioManager.GetComponent<AudioControlScript>().PlaySoundInGameplay();
        }



    }

    public void PauseControl()
    {

        if (Time.timeScale == 1)//Time is running
        {
            PauseScreen.SetActive(true);
            PauseGame(0);//Freeze time

        }
        else
        {
            PauseScreen.SetActive(false);
            PauseGame(1); //Time continues running

        }

    }


    void PauseGame(int value)
    {
        Time.timeScale = value;
    }




}
