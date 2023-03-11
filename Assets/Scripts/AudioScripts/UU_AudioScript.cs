using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UU_AudioScript : MonoBehaviour
{
    public AudioSource Jump;
    public AudioSource Collect;
    public AudioSource WrongButtonPress;
    public AudioSource HitObstacle;
    public AudioSource Miss;
    public AudioSource GetHP;
    public AudioSource DragonHitObstacle;
    public AudioSource GrowlDMG;

    private bool SuperJump = false;

    /// <summary>
    /// ///////////////////////////////////   PLAYER
    /// </summary>
    /// 



    public void JumpSound()
    {
        Jump.Play();
    }

    public void SuperJumpSound() // This stops bug: "Play jump sound twice when fast speed" (Control in UU_SuperJump animation)
    {
        if (SuperJump == false)
        {
            SuperJump = true;
            Jump.Play();
        }
        else
        {
            SuperJump = false;
            Jump.Stop();
        }
    }

    public void StopSuperJumpSound() // This stops bug: "Play jump sound twice when fast speed" (Control in UU_run3 animation)
    {
        
        Jump.Stop();
        SuperJump = false;
        
    }

    public void PlayerCollectSound()
    {
        Collect.Play();


    }
    public void PlayerWrongButtonPressSound()
    {
        WrongButtonPress.Play();


    }

    public void PlayerHitObstacleSound()
    {
        HitObstacle.Play();

    }

    public void PlayerMissSound()
    {
        Miss.Play();

    }

    public void PlayerGetHPSound()
    {
        GetHP.Play();

    }

    /// <summary>
    /// ///////////////////////////////////    DRAGON
    /// </summary>

    public void DragonHitObstacleSound()
    {
        HitObstacle.Play();
        GrowlDMG.Play();


    }

    public void PlayerAnimationEndSound()
    {
        HitObstacle.Play();
        
    }

}
