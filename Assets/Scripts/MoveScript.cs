using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Script that controls objects to move right and get destroyed by Player or DestroyerControl object
/// 
/// </summary>

public class MoveScript : MonoBehaviour
{
    //[SerializeField]
    private GameObject Stats;
    private GameObject ParticleSystem;
    private int ThisObject;

    Vector3 Vec;
    float MoveSpeed;
    private bool StartMoving = false; //This determines if object is "clone" or not (original object won't move -> keeps check on other clones)
    public bool DetonateBomb;

    //TEST
    /*
    public int SkipFrames; //TESTING
    public int SkipFramesMax;
    */
    void Awake()
    {
        Stats = GameObject.Find("Stats");
        ParticleSystem = GameObject.Find("ParticleSystem");

    }



    void Start()
    {
        if (gameObject.tag == "Ball1")
        {
            ThisObject = 1;

        }
        else if (gameObject.tag == "Ball2")
        {
            ThisObject = 2;

        }
        else if (gameObject.tag == "Obstacle")
        {
            ThisObject = 3;

        }



        if (gameObject.layer == 6) // Clones
        {
            StartMoving = true;

        }
        else
        {
            StartMoving = false;
        }

    }
    
    void Update() //ORIGINAL
    {
        if (StartMoving == true)
        {
            
            MoveSpeed = Stats.GetComponent<StatsScript>().Speed;

            Vec = transform.localPosition;
            Vec.x += -1 * Time.deltaTime * MoveSpeed;
            transform.localPosition = Vec;
            
            
        }

    }
    
    /*
    void Update() //TEST
    {
        if (StartMoving == true)
        {

            MoveSpeed = Stats.GetComponent<StatsScript>().Speed;

            SkipFrames++;

            //Vec = transform.localPosition;
            Vec.x += -1 * (Time.deltaTime * MoveSpeed);


            if (SkipFrames == SkipFramesMax)
            {
                transform.localPosition = Vec;
                SkipFrames = 0;
            }

        }
    }
    */
    void OnTriggerEnter2D(Collider2D other)
    {
        DetonateBomb = false;

        if ((gameObject.tag == "Bomb" || gameObject.tag == "Obstacle") && other.gameObject.tag == "Player")
        {
            DetonateBomb = true;

        }

    }




    void OnDestroy()
    {
        if (StartMoving == true & gameObject != null) // Original (not moving) prefabs wont have effect on this
        {

            Vector2 DeathPos;

            DeathPos = new Vector2(transform.position.x, transform.position.y);

            if (ParticleSystem != null)
            {

                ParticleSystem.GetComponent<ParticleSystemController>().StartExplosion(DeathPos, ThisObject);

            }

            Debug.Log("Destroyed");
        }
    }

}
