using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class PointerScript : MonoBehaviour, IPointerDownHandler// required interface when using the OnPointerDown method.
{
    private GameObject PlayerControl;

    void Start()
    {
        PlayerControl = GameObject.Find("PlayerControl");


    }

    /*
    private int ThisButton;

    void Start()
    {
        if (gameObject.tag == Btn1)
        {
            ThisButton = 1;


        }



    }
    */

    //Do this when the mouse is clicked over the selectable object this script is attached to.
    public void OnPointerDown(PointerEventData eventData)
    {

        PlayerControl.GetComponent<PlayerController>().ButtonPressed = 1;
        Debug.Log(this.gameObject.name + " Was Clicked.");
        



        
    }
}