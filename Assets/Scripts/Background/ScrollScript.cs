using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    //public GameObject BackgroundControl; // Place where ScrollSpeedScript is located

    private GameObject BackgroundControl;

    public float ScrollSpeed = -1f;
    private float BackgroundWidth; //Current backgrounds width size / 100 (if background is 57600 pixels wide -> BgWidth = 57.6

    Vector2 StartPos;
    Vector2 CurrentPos;
    float NewPos;

    //RectTransform rt = (RectTransform)gameObject.transform;

    // Start is called before the first frame update
    void Start()
    {
        //float width = rt.rect.width;

        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        BackgroundWidth = width;




        StartPos = transform.position;
        transform.position = StartPos + Vector2.right * NewPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Background4")
        {

            
        }
        if (gameObject.tag == "Background5")
        {
            
        }

        CurrentPos = transform.position;

        //NewPos = Mathf.Repeat(Time.time * ScrollSpeed, BackgroundWidth);
        NewPos = Mathf.Repeat(Time.time * ScrollSpeed, BackgroundWidth);
        transform.position = StartPos + Vector2.right * NewPos;


        
    }
}
