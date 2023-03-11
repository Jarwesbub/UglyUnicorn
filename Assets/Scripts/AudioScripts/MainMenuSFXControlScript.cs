using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSFXControlScript : MonoBehaviour
{
    public GameObject AudioButtons;

    public AudioSource ArtJumpSound;
    public AudioSource LogoSound;
    private int Volume; //0 = OFF ; 1 = ON

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
    }


    public void ArtSoundEffect()
    {
        if (Volume == 1)
        {
            ArtJumpSound.Play();
        }
    }

    public void LogoSoundEffect()
    {
        if (Volume == 1)
        {
            LogoSound.Play();
        }
    }

    public void ActivateAudioButtons()
    {
        AudioButtons.SetActive(true);

    }
}
