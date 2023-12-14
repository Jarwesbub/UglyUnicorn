using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script that controls objects to move right and get destroyed by Player or DestroyerControl object

public class MoveScript : MonoBehaviour
{
    private GameObject Stats;
    private GameObject ParticleSystem;
    [SerializeField] private int myID;

    Vector3 vec;
    float moveSpeed;
    private bool startMoving = false; //This determines if object is "clone" or not (original object won't move -> keeps check on other clones)
    public bool detonateBomb;

    void Start()
    {
        Stats = GameObject.Find("Stats");
        ParticleSystem = GameObject.Find("ParticleSystem");

        startMoving = gameObject.layer == 6;

    }
    
    void Update() //ORIGINAL
    {
        if (startMoving)
        {
            moveSpeed = Stats.GetComponent<StatsScript>().Speed;

            vec = transform.localPosition;
            vec.x += -1 * Time.deltaTime * moveSpeed;
            transform.localPosition = vec;
            
        }

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        detonateBomb = false;

        if ((gameObject.tag == "Bomb" || gameObject.tag == "Obstacle") && other.gameObject.tag == "Player")
        {
            detonateBomb = true;
        }

    }


    void OnDestroy()
    {
        if (startMoving & gameObject != null) // Original (not moving) prefabs wont have effect on this
        {
            Vector2 DeathPos;
            DeathPos = new Vector2(transform.position.x, transform.position.y);
            ParticleSystem?.GetComponent<ParticleSystemController>().StartExplosion(DeathPos, myID); // If not null

        }
    }

}
