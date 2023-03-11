using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When player gets damage -> DestroyerScript will control duration time and other setup
/// 
/// 
/// </summary>


public class UU_AnimScript : MonoBehaviour
{
    //public Animation anim;
    public Animator animator;
    private GameObject Stats;
    private GameObject PlayerControl;
    public float RunLevel; //private
    float BaseSpeed;

    public bool Jump = false;
    bool JumpingATM;

    public int GetDamage = 0;

    private bool PlayerDies = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerDies = false;

        Stats = GameObject.Find("Stats");
        PlayerControl = GameObject.Find("PlayerControl");

        Jump = false;
        JumpingATM = false;
        BaseSpeed = 0.5f;
        //RunLevel = 1;
        animator.SetTrigger("Run1Trigger");


    }

    // Update is called once per frame
    void Update()
    {
        //RunLevel = GameObject.Find("Spawner").GetComponent<SpawnerScript>().Level;

        if (PlayerDies == false)
        {

            RunLevel = Stats.GetComponent<StatsScript>().Speed;
            animator.speed = BaseSpeed + (RunLevel / 10);
        }

        if (RunLevel < 11f)
        {
            BaseSpeed = 0.5f;

            if (GetDamage == 0)
            {
                animator.SetTrigger("Run1Trigger");
            }
        }
        else if (RunLevel < 17f)
        {
            BaseSpeed = 0.2f;

            if (GetDamage == 0)
            {
                animator.SetTrigger("Run2Trigger");
            }
        }
        else
        {
            BaseSpeed = 0.1f;

            if (GetDamage == 0)
            {
                animator.SetTrigger("Run3Trigger");
            }
        }

        ////////////////
        /*
        if (GetDamage == 1)
        {
            BaseSpeed = 0.5f;
            animator.SetTrigger("DamageTrigger");


        }
        else if (GetDamage == 2)
        {
            animator.SetTrigger("CooldownEndTrigger");

        }
        */
        if (Jump == true)
        {
            Jump = false;
            animator.SetTrigger("JumpTrigger");
            

        }

    }

    public void StartCooldown()
    {
        BaseSpeed = 0.5f;
        animator.SetTrigger("DamageTrigger");


    }
    public void EndCooldown()
    {
        if (PlayerDies == false)
        {
            animator.SetTrigger("CooldownEndTrigger");
        }
    }

    public void JumpButton()
    {

        if (JumpingATM == false)
        {
            Jump = true;
        }
    }


    public void JumpAnimEnd()
    {
        PlayerControl.GetComponent<PlayerController>().JumpStart = false;
        animator.SetTrigger("JumpEndTrigger");
        JumpingATM = false;
    }

    public void PlayerDiesAnim()
    {
        PlayerDies = true;
        animator.SetTrigger("DeathTrigger");
        animator.speed = 1f;

    }

}
