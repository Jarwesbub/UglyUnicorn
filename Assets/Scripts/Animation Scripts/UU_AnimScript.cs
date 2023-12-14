using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// When player gets damage -> DestroyerScript will control duration time and other setup

public class UU_AnimScript : MonoBehaviour
{
    public Animator animator;
    private GameObject Stats;
    private GameObject PlayerControl;
    public float RunLevel;
    float BaseSpeed;

    public bool Jump = false;
    bool isJumping;
    public int getDamage = 0;
    private bool playerDies = false;

    void Start()
    {
        playerDies = false;
        Stats = GameObject.Find("Stats");
        PlayerControl = GameObject.Find("PlayerControl");

        Jump = false;
        isJumping = false;
        BaseSpeed = 0.5f;
        animator.SetTrigger("Run1Trigger");


    }

    void Update()
    {

        if (!playerDies)
        {
            RunLevel = Stats.GetComponent<StatsScript>().Speed;
            animator.speed = BaseSpeed + (RunLevel / 10);
        }

        if (RunLevel < 11f)
        {
            BaseSpeed = 0.5f;

            if (getDamage == 0)
            {
                animator.SetTrigger("Run1Trigger");
            }
        }
        else if (RunLevel < 17f)
        {
            BaseSpeed = 0.2f;

            if (getDamage == 0)
            {
                animator.SetTrigger("Run2Trigger");
            }
        }
        else
        {
            BaseSpeed = 0.1f;

            if (getDamage == 0)
            {
                animator.SetTrigger("Run3Trigger");
            }
        }

        if (Jump)
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
        if (!playerDies)
        {
            animator.SetTrigger("CooldownEndTrigger");
        }
    }

    public void JumpButton()
    {

        if (!isJumping)
        {
            Jump = true;
        }
    }

    public void JumpAnimEnd()
    {
        PlayerControl.GetComponent<PlayerController>().SetPlayerJumpStart(false);
        animator.SetTrigger("JumpEndTrigger");
        isJumping = false;
    }

    public void PlayerDiesAnim()
    {
        playerDies = true;
        animator.SetTrigger("DeathTrigger");
        animator.speed = 1f;

    }

}
