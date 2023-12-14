using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSFXControlScript : MonoBehaviour
{
    public GameObject AudioButtons;

    public AudioSource ArtJumpSound;
    public AudioSource LogoSound;
    private int volume; //0 = OFF ; 1 = ON

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
    }


    public void ArtSoundEffect()
    {
        if (volume == 1)
        {
            ArtJumpSound.Play();
        }
    }

    public void LogoSoundEffect()
    {
        if (volume == 1)
        {
            LogoSound.Play();
        }
    }

    public void ActivateAudioButtons()
    {
        AudioButtons.SetActive(true);

    }
}
