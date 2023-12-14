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

    private int volume;
    private int music;

    void Awake()
    {
        volume = PlayerPrefs.GetInt("volume");
        music = PlayerPrefs.GetInt("music");

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
        volume = PlayerPrefs.GetInt("volume");

        if (volume == 1)
        {
            volume = 0;
            AudioListener.volume = volume;
            Vol_Btn.GetComponent<Image>().sprite = Vol_OFF;
            PlayerPrefs.SetInt("volume", volume);
        }
        else
        {
            volume = 1;
            AudioListener.volume = volume;
            Vol_Btn.GetComponent<Image>().sprite = Vol_ON;
            PlayerPrefs.SetInt("volume", volume);
        }

    }

    public void MusicButton()
    {
        music = PlayerPrefs.GetInt("music");

        if (music == 1)
        {
            music = 0;
            Music_Btn.GetComponent<Image>().sprite = Music_OFF;
            PlayerPrefs.SetInt("music", music);
            AudioManager.GetComponent<AudioControlScript>().MuteSoundInGameplay();
        }
        else
        {
            music = 1;
            Music_Btn.GetComponent<Image>().sprite = Music_ON;
            PlayerPrefs.SetInt("music", music);
            AudioManager.GetComponent<AudioControlScript>().PlaySoundInGameplay();
        }

    }

    public void PauseControl()
    {

        if (Time.timeScale == 1) // Time is running
        {
            PauseScreen.SetActive(true);
            PauseGame(0); // Freeze time

        }
        else
        {
            PauseScreen.SetActive(false);
            PauseGame(1); // Time continues running

        }

    }

    void PauseGame(int value)
    {
        Time.timeScale = value;
    }

}
