using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class ButtonPointerScript : MonoBehaviour, IPointerDownHandler// required interface when using the OnPointerDown method.
{
    public int Button;
    private GameObject PlayerControl;

    void Start()
    {
        PlayerControl = GameObject.Find("PlayerControl");

    }

    //Do this when the mouse is clicked over the selectable object this script is attached to.
    public void OnPointerDown(PointerEventData eventData)
    {

        PlayerControl.GetComponent<PlayerController>().ButtonPressed = Button;
        //Debug.Log(this.gameObject.name + " Was Clicked.");
        
    }
}
