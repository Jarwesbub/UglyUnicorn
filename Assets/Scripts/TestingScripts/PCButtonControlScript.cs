using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class PCButtonControlScript : MonoBehaviour
{
    //////////This script is only for button press commands in Unity "On Click()" events

    private GameObject PlayerControl;
    private GameObject UU_Sprite;



    void Start()
    {
        PlayerControl = GameObject.Find("PlayerControl");
        UU_Sprite = GameObject.Find("UU_sprite");



    }


    void Update() // PC TESTING!!!!!!!!!!!!!!!
    {
        if (Input.GetKeyDown("a")) // COMPUTER USE
        {
            PlayerControl.GetComponent<PlayerController>().ButtonIsPressed(1);
        }
        if (Input.GetKeyDown("d")) // COMPUTER USE
        {
            PlayerControl.GetComponent<PlayerController>().ButtonIsPressed(2);
        }
        if (Input.GetKeyDown("space"))
        {
            PlayerControl.GetComponent<PlayerController>().SetPlayerJumpStart(true);
            UU_Sprite.GetComponent<UU_AnimScript>().JumpButton();

        }

    }


}
