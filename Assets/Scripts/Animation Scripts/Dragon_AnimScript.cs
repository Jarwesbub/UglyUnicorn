using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_AnimScript : MonoBehaviour
{
    public GameObject DragonFireEffect;
    private GameObject Stats;
    public Animator animator;
    public bool Bite = false;
    public bool GetDamage = false;
    public float PosAdd = 1f;
    public float StartingPosition;
    public bool PlayerGetsHP = false;

    public bool PlayerDies = false;

    public float PosX, NewPosX;
    public bool DragonGetLerp;
    bool DragonMovesForward;

    private float RunLevel, BaseSpeed;

    //TESTING



    // Start is called before the first frame update
    void Start()
    {
        DragonGetLerp = false;
        PlayerDies = false;
        StartingPosition = transform.position.x;

        Stats = GameObject.Find("Stats");

        BaseSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        RunLevel = Stats.GetComponent<StatsScript>().Speed;

        if (Bite == false)
        {
            animator.speed = BaseSpeed + (RunLevel / 50);

        }

        if (Bite == true)
        {
            Bite = false;
            animator.speed = 0.4f;
            animator.SetTrigger("Bite Trigger");
            DragonPosition(true);
        }
        if (GetDamage == true)
        {
            GetDamage = false;

        }
        if (PlayerGetsHP == true)
        {
            PlayerGetsHP = false;
            DragonPosition(false);
        }

        if (DragonGetLerp == true)
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
        //PosX = transform.position.x;
        float Pos = PosAdd / 100;

        PosX = transform.position.x;

        if (DragonMovesForward == true)
        {
            if (PosX < NewPosX)
            {
                gameObject.transform.position += new Vector3(Pos, 0f, 0f);

            }
            else
            {
                PosX = NewPosX;
                DragonGetLerp = false;

            }

        }
        else
        {
            if (PosX > NewPosX)
            {
                gameObject.transform.position -= new Vector3(Pos, 0f, 0f);

            }
            else
            {
                PosX = NewPosX;
                DragonGetLerp = false;

            }


        }


        
       /*
        LerpTime += (LerpSlowDownValue / 1000) * Time.deltaTime;

        Speed = Mathf.Lerp(Speed, 0, LerpTime);
       */
    }




    public void DragonPosition(bool Add)
    {
        PlayerDies = Stats.GetComponent<StatsScript>().PlayerDies;

        PosX = transform.position.x;
       

        if (PlayerDies == false)
        {
            //PosX = transform.position.x;

            if (Add == true) // Dragon Moves forward //Add is called from if (Bite == true)
            {
                if (PosX <= -10f)
                {
                    NewPosX = PosX + PosAdd;
                    DragonMovesForward = true;
                    DragonGetLerp = true;
                    //gameObject.transform.position += new Vector3(PosAdd, 0f, 0f);
                }
            }
            else // Dragon Moves backward // Add is called from SpriteColorControl(void dragondamage()
            {
                if (PosX > StartingPosition)
                {
                    NewPosX = PosX - PosAdd;
                    DragonMovesForward = false;
                    DragonGetLerp = true;
                    //gameObject.transform.position -= new Vector3(PosAdd, 0f, 0f);

                }
            }

            

        }



    }


}
