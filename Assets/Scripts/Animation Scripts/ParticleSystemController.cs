using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    public GameObject RedExplosion;
    public GameObject BlueExplosion;
    public GameObject ObstacleExplosion;

    private int ObjNumber;

    private ParticleSystem ParticleSys;

    private Vector2 StartPos;
    public Vector2 NextVecPos;
    
    public void StartExplosion(Vector2 NewPos, int Color)
    {
        NextVecPos = NewPos;

        ExplosionGetPos(Color);

    }

    private void ExplosionGetPos(int Color)
    {
        if (Color == 1)
        {
            RedExplosion.transform.position = new Vector2(NextVecPos.x, NextVecPos.y);
            RedExplosion.GetComponent<ParticleSystem>().Play();


        }
        if (Color == 2)
        {
            BlueExplosion.transform.position = new Vector2(NextVecPos.x, NextVecPos.y);
            BlueExplosion.GetComponent<ParticleSystem>().Play();


        }
        if (Color == 3)
        {
            ObstacleExplosion.transform.position = new Vector2(NextVecPos.x, NextVecPos.y);
            ObstacleExplosion.GetComponent<ParticleSystem>().Play();


        }


    }




    // Start is called before the first frame update
    void Start()
    {
        StartPos = new Vector2(transform.position.x, transform.position.y);


    }

}
