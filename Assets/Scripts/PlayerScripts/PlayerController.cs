using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Destroyer;
    public GameObject Stats;
    private GameObject Spawner;
    private GameObject UU_Sprite;

    private int buttonPressed;
    private int contact = 0;
    private bool playerGotHit = false;
    private bool hit = false;
    private bool bombHit = false;
    private float addSpeed;
    private bool wrongButtonPress = false;

    private bool jumpStart = false;
    public bool contactLock = false;

    private Collider2D OnTriggerCol;

    void Start()
    {
        UU_Sprite = GameObject.Find("UU_sprite");
        Spawner = GameObject.Find("Spawner");
        buttonPressed = 0;
    }

    public void ResetContactValue()
    {
        contact = 0;
    }

    public void SetPlayerJumpStart(bool start)
    {
        jumpStart = start;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        OnTriggerCol = other; //makes accessing "other" possible in any void/script

        if (other.gameObject.tag == "Ball1")
        {
            contact = 1;
        }

        else if (other.gameObject.tag == "Ball2")
        {
            contact = 2;
        }

        else if (other.gameObject.tag == "Bomb" || other.gameObject.tag == "Obstacle") //Get damage if on collision
        {
            if (other.GetComponent<MoveScript>().detonateBomb)
            {
                if (!jumpStart)
                {
                    Destroy(other.gameObject);
                    contact = 0;
                    Destroyer.GetComponent<DestroyerScript>().DamageControl(); // You take damage when
                    Stats.GetComponent<ReactionsScript>().StartReactions(false); //Hit was NOT successful
                    UU_Sprite.GetComponent<UU_AudioScript>().PlayerHitObstacleSound(); // Sound effect
                }
            }
        }

    }

    public void SetPlayerGotHit(bool hit)
    {
        playerGotHit = hit;
    }

    public bool CheckIfPlayerGotHit()
    {
        return playerGotHit;
    }

    public void ButtonIsPressed(int id)
    {
        buttonPressed = id;
    }

    void CheckObjectCol()
    {
        if (OnTriggerCol != null)
        {
            if (OnTriggerCol.gameObject.tag == "Ball1" || OnTriggerCol.gameObject.tag == "Ball2" || OnTriggerCol.gameObject.tag == "Bomb" || OnTriggerCol.gameObject.tag == "Obstacle")
            {

                if (hit && !wrongButtonPress)
                {
                    Destroy(OnTriggerCol.gameObject);
                    hit = false;
                    contact = 0;

                    addSpeed = Spawner.GetComponent<SpawnerScript>().addSpeed;
                    Stats.GetComponent<StatsScript>().Speed += addSpeed;

                    Stats.GetComponent<ReactionsScript>().StartReactions(true); //Hit was successful!
                    UU_Sprite.GetComponent<UU_AudioScript>().PlayerCollectSound(); // Sound effect

                }

                else if (hit && wrongButtonPress)
                {
                    Destroy(OnTriggerCol.gameObject);
                    hit = false;
                    contact = 0;
                    Destroyer.GetComponent<DestroyerScript>().DamageControl(); // Player gets damage if pressed wrong button
                    wrongButtonPress = false;
                    Stats.GetComponent<ReactionsScript>().StartReactions(false); //Hit was NOT successful
                    UU_Sprite.GetComponent<UU_AudioScript>().PlayerWrongButtonPressSound(); // Sound effect
                }

                if (bombHit)
                {
                    Destroy(OnTriggerCol.gameObject);
                    bombHit = false;
                    contact = 0;
                    Destroyer.GetComponent<DestroyerScript>().DamageControl(); // You take damage when onclick
                    Stats.GetComponent<ReactionsScript>().StartReactions(false); //Hit was NOT successful
                    UU_Sprite.GetComponent<UU_AudioScript>().PlayerHitObstacleSound(); // Sound effect
                }
            }
        }

    }


    void Update()
    {

        if (OnTriggerCol != null)
        {
            if (buttonPressed == 1)
            {
                contactLock = true;
                PlayerCollision(1);
                buttonPressed = 0;
            }

            if (buttonPressed == 2)
            {
                contactLock = true;
                PlayerCollision(2);
                buttonPressed = 0;
            }
        }
        else if (buttonPressed <= 2)
        {
            buttonPressed = 0;
        }

        if (buttonPressed == 3) //JUMP
        {
            buttonPressed = 0;
            jumpStart = true;
            UU_Sprite.GetComponent<UU_AnimScript>().JumpButton();

        }


    }

    void PlayerCollision(int ButtonNumb)
    {
        
        if (ButtonNumb == 1 && contact == 1)
        {
            hit = true;
            CheckObjectCol();
        }

        else if (ButtonNumb == 2 && contact == 2)
        {
            hit = true;
            CheckObjectCol();

        }

        if (ButtonNumb == 1 && contact == 2 || ButtonNumb == 2 && contact == 1) // If you press wrong button while object is on hit distance
        {
            wrongButtonPress = true;
            hit = true;
            CheckObjectCol();
        }

    }

}
