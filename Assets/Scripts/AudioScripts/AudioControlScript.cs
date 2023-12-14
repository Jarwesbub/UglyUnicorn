using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControlScript : MonoBehaviour
{
    public GameObject BgMusic0; // MUTE
    public GameObject BgMusic1;
    public GameObject BgMusic2;
    public GameObject BgMusic3;

    private AudioSource source;
    private int ChooseMusic;
    private int Music, Volume;

    void Awake()
    {
        Volume = PlayerPrefs.GetInt("volume"); ///
        AudioListener.volume = Volume; /// if volume == 1 -> play sounds ; if volume == 0 -> mute all


        if (PlayerPrefs.HasKey("music"))
        {
            Music = PlayerPrefs.GetInt("music");


        }
        else
        {
            PlayerPrefs.SetInt("music", 1);
            Music = 1;
        }

        ChooseMusic = PlayerPrefs.GetInt("music1");

        BgMusic0.SetActive(true);
        BgMusic1.SetActive(false);
        BgMusic2.SetActive(false);
        BgMusic3.SetActive(false);


        if (Music == 1)
        {
            ChoosePlayingMusic();
        }

    }


    private void ChoosePlayingMusic()
    {
        if (ChooseMusic == 0)
        {
            BgMusic0.SetActive(true);
            BgMusic1.SetActive(false);
            BgMusic2.SetActive(false);
            BgMusic3.SetActive(false);

            source = null;

        }
        if (ChooseMusic == 1)
        {
            BgMusic0.SetActive(false);
            BgMusic1.SetActive(true);
            BgMusic2.SetActive(false);
            BgMusic3.SetActive(false);

            source = BgMusic1.GetComponent<AudioSource>();
        }
        if (ChooseMusic == 2)
        {
            BgMusic0.SetActive(false);
            BgMusic1.SetActive(false);
            BgMusic2.SetActive(true);
            BgMusic3.SetActive(false);

            source = BgMusic2.GetComponent<AudioSource>();
        }
        if (ChooseMusic == 3)
        {
            BgMusic0.SetActive(false);
            BgMusic1.SetActive(false);
            BgMusic2.SetActive(false);
            BgMusic3.SetActive(true);

            source = BgMusic3.GetComponent<AudioSource>();
        }

    }


    public void MuteSoundInGameplay()
    {
        Music = 0;

        BgMusic0.SetActive(true);
        BgMusic1.SetActive(false);
        BgMusic2.SetActive(false);
        BgMusic3.SetActive(false);
    }

    public void PlaySoundInGameplay()
    {
        Music = 1;
        ChoosePlayingMusic();
    }


    public void EndScreenVolume()
    {
        
        if (ChooseMusic != 0)
        StartCoroutine(LowerVolume());


    }

    IEnumerator LowerVolume()
    {
        yield return new WaitForSeconds(1f);

        float StartVolume = 0f;

        if (source != null)
            StartVolume = source.volume;

        if (StartVolume > 0.05)
        {
            do
            {
                StartVolume -= 0.05f;
                source.volume = StartVolume;
                yield return new WaitForSeconds(0.5f);
            }
            while (StartVolume >= 0f);

            yield return new WaitForSeconds(3f);

            source.Stop();
        }

        yield return new WaitForSeconds(0.1f);

    }

}
