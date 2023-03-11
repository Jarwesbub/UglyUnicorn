using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMoveScript : MonoBehaviour
{
    Vector3 Vec;
    float MoveSpeed;
    private bool StartMoving = false; //This determines if object is "clone" or not (original object won't move -> keeps check on other clones)


    void Start()
    {
        //if (gameObject.name.Contains("(Clone)"))
        if (gameObject.layer == 6) // Clones
        {
            StartMoving = true;

        }
        else
        {
            StartMoving = false;
        }
    }

    //void Update()
    void FixedUpdate()
    {
        if (StartMoving == true)
        {
            MoveSpeed = GameObject.Find("Stats").GetComponent<StatsScript>().Speed;

            Vec = transform.localPosition;
            Vec.x += -1 * Time.deltaTime * MoveSpeed;
            transform.localPosition = Vec;
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HitBox1")
        {
            Destroy(gameObject);

        }


        /*
        //if (other.gameObject.tag == "Ball1" || other.gameObject.tag == "Ball2" || other.gameObject.tag == "Bomb")
        if (other.gameObject.layer == 6) //CLONES
        {
            Destroy(other.gameObject);
        }
        */
    }

    void OnDestroy()
    {
        Debug.Log("Destroyed");

    }

}