using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    private GameObject Stats;
    private GameObject PlayerControl;
    private int Hitbox;
    bool Check = false;

    void Start()
    {
        Stats = GameObject.Find("Stats");
        PlayerControl = GameObject.Find("PlayerControl");

        if (Check == false)
        {
            if (gameObject.tag == "HitBox1")
            {
                Hitbox = 1;

            }
            else if (gameObject.tag == "HitBox2")
            {
                Hitbox = 2;

            }
            else if (gameObject.tag == "HitBox3")
            {
                Hitbox = 3;

            }

        }


    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)//CLONES
        {
            Stats.GetComponent<ReactionsScript>().Hitbox = Hitbox;

        }


    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (Hitbox == 3) //Also know as Player's main hitbox
        {
            PlayerControl.GetComponent<PlayerController>().Contact = 0;

        }



    }



    /*
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)//CLONES
        {
            GameObject.Find("Stats").GetComponent<ReactionsScript>().Hitbox = 3;

        }


    }
    */


}
