using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxChildScript : MonoBehaviour
{
    private GameObject Stats;
    int Hitbox;
    bool Check = false;

    void Start()
    {
        Stats = GameObject.Find("Stats");


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
            else
            {
                Hitbox = 0;

            }
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)//CLONES
        {
            Stats.GetComponent<ReactionsScript>().Hitbox = Hitbox;

        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)//CLONES
        {
            Stats.GetComponent<ReactionsScript>().Hitbox = 0;

        }


    }
}
