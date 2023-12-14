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

    private bool superJump = false;

    public void JumpSound()
    {
        Jump.Play();
    }

    public void SuperJumpSound() // This stops bug: "Play jump sound twice when fast speed" (Control in UU_SuperJump animation)
    {
        if (superJump)
        {
            superJump = false;
            Jump.Stop();
        }
        else
        {
            superJump = true;
            Jump.Play();
        }
    }

    public void StopSuperJumpSound() // This stops bug: "Play jump sound twice when fast speed" (Control in UU_run3 animation)
    {
        
        Jump.Stop();
        superJump = false;
        
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
