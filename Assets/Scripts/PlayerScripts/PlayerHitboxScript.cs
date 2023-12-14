using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitboxScript : MonoBehaviour
{
    private GameObject Stats;
    private GameObject PlayerControl;
    [SerializeField] private int myHitboxID;

    void Start()
    {
        Stats = GameObject.Find("Stats");
        PlayerControl = GameObject.Find("PlayerControl");

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 6) // CLONES
        {
            Stats.GetComponent<ReactionsScript>().Hitbox = myHitboxID;

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (myHitboxID == 3) // Also know as Player's main hitbox
        {
            PlayerControl.GetComponent<PlayerController>().ResetContactValue();

        }



    }


}
