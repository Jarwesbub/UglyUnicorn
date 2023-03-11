using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Destroyer;
    public GameObject Stats;
    private GameObject Spawner;
    private GameObject UU_Sprite;

    public int ButtonPressed;
    public int Contact = 0;

    //ALL PRIVATE DOWN HERE
    ///
    public bool Hit = false;
    public bool BombHit = false;
    public bool GetHit = false;
    float AddSpeed;
    public bool WrongButtonPress = false;
    /// 

    //public BoxCollider2D ColMain;

    //public int Hitbox;
    public bool JumpStart = false;
    public bool ContactLock = false;

    private Collider2D OnTriggerCol;

    void Start()
    {
        UU_Sprite = GameObject.Find("UU_sprite");
        Spawner = GameObject.Find("Spawner");




        ButtonPressed = 0;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        OnTriggerCol = other; //makes accessing "other" possible in any void/script

        if (other.gameObject.tag == "Ball1")
        {
           
            Contact = 1;

        }

        if (other.gameObject.tag == "Ball2")
        {
            Contact = 2;

        }
        /*
        if (other.gameObject.tag == "Bomb") //AUTOMAIC JUMP
        {
            Contact = 3;

            if (JumpStart == false)
            {
                JumpStart = true;
                GameObject.Find("UU_sprite").GetComponent<UU_AnimScript>().Jump = true;
            }
        }
        */
        if (other.gameObject.tag == "Bomb" || other.gameObject.tag == "Obstacle") //Get damage if on collision
        {

            if (other.GetComponent<MoveScript>().DetonateBomb == true)
            {

                if (JumpStart == true)
                {

                }
                else
                {
                    Destroy(other.gameObject);
                    Contact = 0;
                    Destroyer.GetComponent<DestroyerScript>().DamageControl(); // You take damage when
                    Stats.GetComponent<ReactionsScript>().StartReactions(false); //Hit was NOT successful
                    UU_Sprite.GetComponent<UU_AudioScript>().PlayerHitObstacleSound(); // Sound effect
                }
            }
        }

    }
    /*
    void OnTriggerStay2D(Collider2D other)
    {
        OnTriggerCol = other; //makes accessing "other" possible in any void/script


    }
    */
    void CheckObjectCol()
    {
        //if (other.gameObject.layer == 6)//CLONES

        if (OnTriggerCol != null)
        {
            if (OnTriggerCol.gameObject.tag == "Ball1" || OnTriggerCol.gameObject.tag == "Ball2" || OnTriggerCol.gameObject.tag == "Bomb" || OnTriggerCol.gameObject.tag == "Obstacle")
            {

                if (Hit == true && WrongButtonPress == false)
                {
                    Destroy(OnTriggerCol.gameObject);
                    Hit = false;
                    Contact = 0;

                    AddSpeed = Spawner.GetComponent<SpawnerScript>().AddSpeed;
                    Stats.GetComponent<StatsScript>().Speed += AddSpeed;

                    Stats.GetComponent<ReactionsScript>().StartReactions(true); //Hit was successful!
                    UU_Sprite.GetComponent<UU_AudioScript>().PlayerCollectSound(); // Sound effect

                }

                else if (Hit == true && WrongButtonPress == true)
                {
                    Destroy(OnTriggerCol.gameObject);
                    Hit = false;
                    Contact = 0;
                    Destroyer.GetComponent<DestroyerScript>().DamageControl(); // Player gets damage if pressed wrong button
                    WrongButtonPress = false;
                    Stats.GetComponent<ReactionsScript>().StartReactions(false); //Hit was NOT successful
                    UU_Sprite.GetComponent<UU_AudioScript>().PlayerWrongButtonPressSound(); // Sound effect
                }

                if (BombHit == true)
                {
                    Destroy(OnTriggerCol.gameObject);
                    BombHit = false;
                    Contact = 0;
                    Destroyer.GetComponent<DestroyerScript>().DamageControl(); // You take damage when onclick
                    Stats.GetComponent<ReactionsScript>().StartReactions(false); //Hit was NOT successful
                    UU_Sprite.GetComponent<UU_AudioScript>().PlayerHitObstacleSound(); // Sound effect
                }
            }
        }
        else
        {
            Debug.Log("Null Object!");

        }



    }

    


   

    void Update()
    {

        //if (ContactLock == false)
        if (OnTriggerCol != null)
        {
            if (ButtonPressed == 1)
            {
                ContactLock = true;
                PlayerCollision(1);
                ButtonPressed = 0;
            }

            if (ButtonPressed == 2)
            {
                ContactLock = true;
                PlayerCollision(2);
                ButtonPressed = 0;
            }
        }
        else if (ButtonPressed <= 2)
        {
            ButtonPressed = 0;
        }

        if (ButtonPressed == 3) //JUMP
        {
            ButtonPressed = 0;
            JumpStart = true;
            UU_Sprite.GetComponent<UU_AnimScript>().JumpButton();

        }


    }

    void PlayerCollision(int ButtonNumb)
    {
        bool check = false;

        if (check == false)
        {
            if (ButtonNumb == 1 && Contact == 1)
            {
                Hit = true;
                CheckObjectCol();
            }

            else if (ButtonNumb == 2 && Contact == 2)
            {
                Hit = true;
                CheckObjectCol();

            }
            /*
            else if (Contact == 3) // Press button on bomb
            {
                BombHit = true;
                CheckObjectCol();

            }
            */
            check = true;
        }



        if (ButtonNumb == 1 && Contact == 2 || ButtonNumb == 2 && Contact == 1) // If you press wrong button while object is on hit distance
        {
            WrongButtonPress = true;
            Hit = true;
            CheckObjectCol();
        }

        

    }



}
