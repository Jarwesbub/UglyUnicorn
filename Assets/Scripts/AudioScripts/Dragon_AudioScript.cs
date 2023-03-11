using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_AudioScript : MonoBehaviour
{
    public AudioSource Growl1;
    public AudioSource Growl2;
    public AudioSource GrowlDMG;
    public AudioSource GrowlEnd;
    public AudioSource Fire;
    public AudioSource DragonBite;

    public void PlayCrowlRandom()
    {
        int shuffle;

        shuffle = Random.Range(1, 2+1);

        if (shuffle == 1)
            Growl1.Play();
        else
            Growl2.Play();

    }

    public void PlayCrowlDMG()
    {
        GrowlDMG.Play();

    }


    public void PlayCrowlBeforeFire()
    {
        GrowlEnd.Play();

    }

    public void PlayFireSound()
    {
        Fire.Play();


    }

    public void PlayBiteSound()
    {
        DragonBite.Play();
    }

}
