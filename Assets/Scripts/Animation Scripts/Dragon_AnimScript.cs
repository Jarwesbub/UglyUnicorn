using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_AnimScript : MonoBehaviour
{
    public GameObject DragonFireEffect;
    private GameObject Stats;
    public Animator animator;

    private float posAdd = 1f;
    private float startingPosition;
    private float posX, newPosX;
    private float runLevel, baseSpeed;

    private bool dragonMovesForward;
    private bool dragonGetLerp;
    private bool playerGetsHP = false;

    void Start()
    {
        dragonGetLerp = false;
        startingPosition = transform.position.x;

        Stats = GameObject.Find("Stats");

        baseSpeed = 1f;
    }

    public void DragonBites()
    {
        animator.speed = 0.4f;
        animator.SetTrigger("Bite Trigger");
        DragonPosition(true);
    }

    void Update()
    {
        runLevel = Stats.GetComponent<StatsScript>().Speed;
        animator.speed = baseSpeed + (runLevel / 50);

        if (playerGetsHP)
        {
            playerGetsHP = false;
            DragonPosition(false);
        }

        if (dragonGetLerp)
        {
            DragonSmoothPosition();


        }

    }

    public void DragonFireBreath()
    {
        animator.SetTrigger("Fire Trigger");
        animator.speed = 0.2f;
    }

    public void DragonFirePlay()
    {
        DragonFireEffect.GetComponent<ParticleSystem>().Play();

    }

    void DragonSmoothPosition()
    {
        float Pos = posAdd / 100;

        posX = transform.position.x;

        if (dragonMovesForward)
        {
            if (posX < newPosX)
            {
                gameObject.transform.position += new Vector3(Pos, 0f, 0f);

            }
            else
            {
                posX = newPosX;
                dragonGetLerp = false;

            }

        }
        else
        {
            if (posX > newPosX)
            {
                gameObject.transform.position -= new Vector3(Pos, 0f, 0f);

            }
            else
            {
                posX = newPosX;
                dragonGetLerp = false;

            }
        }
    }

    public void DragonPosition(bool Add)
    {
        bool playerDies = Stats.GetComponent<StatsScript>().PlayerDies;
        posX = transform.position.x;
     
        if (!playerDies)
        {
            if (Add) // Dragon Moves forward //Add is called from if (Bite == true)
            {
                if (posX <= -10f)
                {
                    newPosX = posX + posAdd;
                    dragonMovesForward = true;
                    dragonGetLerp = true;
                }
            }
            else // Dragon Moves backward // Add is called from SpriteColorControl(void dragondamage()
            {
                if (posX > startingPosition)
                {
                    newPosX = posX - posAdd;
                    dragonMovesForward = false;
                    dragonGetLerp = true;
                }
            }
        }
    }

}
