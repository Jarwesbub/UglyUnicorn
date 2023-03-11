using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    public GameObject CloneParent;
    public GameObject Stats;
    public GameObject Spawner;
    public GameObject SpriteControl;
    public GameObject PlayerControl;
    private GameObject Dragon_Sprite;
    private GameObject UU_Sprite;
    

    bool FreezeLocked = false;

    public int PlayerGetHPNext = 5; //ORIGINAL = 3 // How many times bomb explodes on dragon -> player gets extra HP // CONTROLLED IN SpawnController
    int HPNow = 0; //Current stack number for extra HP

    float SlowSpeed;

    void Start()
    {
        Dragon_Sprite = GameObject.Find("Dragon_sprite");
        UU_Sprite = GameObject.Find("UU_sprite");



    }



    void DestroyAllObjects()
    {
        //if (DestroyChilds == true)
        {
            for (int i = 0; i < CloneParent.transform.childCount; i++)
            {
                Destroy(CloneParent.transform.GetChild(i).gameObject);
            }

        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {

        //if (other.name.Contains("Ball"))
        if (other.gameObject.tag == "Ball1" || other.gameObject.tag == "Ball2")
            {
            DamageControl();
            HPNow = 0; //Resets current HP stack
            Destroy(other.gameObject);
            //DestroyChilds = true;
            Stats.GetComponent<ReactionsScript>().StartReactions(false); //Hit was NOT successful
            UU_Sprite.GetComponent<UU_AudioScript>().PlayerMissSound(); // Sound effect
        }
        else if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Bomb") // Dragon gets Damage here
        { 
            Destroy(other.gameObject);
            //DestroyChilds = true;
            SpriteControl.GetComponent<SpriteColorControl>().DragonGetDamage = true;
            Stats.GetComponent<ReactionsScript>().StartReactions(true); //Hit was succesful!
            UU_Sprite.GetComponent<UU_AudioScript>().DragonHitObstacleSound(); // Sound effect

            HPNow += 1;

            if (HPNow == PlayerGetHPNext) //HP stack calculation for extra HP
            {
                Stats.GetComponent<StatsScript>().GetHP += 1;
                Dragon_Sprite.GetComponent<Dragon_AnimScript>().DragonPosition(false);
                HPNow = 0;
                UU_Sprite.GetComponent<UU_AudioScript>().PlayerGetHPSound(); // Sound effect
            }
        }
    }

    public void DamageControl()
    {
        //float AddedSpeed = GameObject.Find("PlayerControl").GetComponent<PlayerController>().AddSpeed;
        if (FreezeLocked == false)
        {
            Stats.GetComponent<StatsScript>().DecreaseSpeed();

            /*
            float MainSpeed = Stats.GetComponent<StatsScript>().Speed;
            SlowSpeed = MainSpeed;

            if (MainSpeed <= 10f)
            {
                SlowSpeed -= 2f;
            }
            else if (MainSpeed <= 15f)
            {
                SlowSpeed = 8f;
            }
            else
            {
                SlowSpeed -= 9f;
            }
            
            Stats.GetComponent<StatsScript>().Speed = SlowSpeed;
            Stats.GetComponent<StatsScript>().Damage += 1;
            PlayerControl.GetComponent<PlayerController>().GetHit = true;
            */
            StartCoroutine(FreezeLockCoolDown());
        }
    }

    IEnumerator FreezeLockCoolDown()
    {
        FreezeLocked = true;
        Spawner.GetComponent<SpawnerScript>().FreezeLock = true;
        //GameObject.Find("SpriteControl").GetComponent<SpriteColorControl>().Cooldown = 1;
        //UU_Sprite.GetComponent<UU_AnimScript>().GetDamage = 1; //Starts GetDamageTrigger
        UU_Sprite.GetComponent<UU_AnimScript>().StartCooldown();

        DestroyAllObjects();

        yield return new WaitForSeconds(3f); // How many seconds player is in cooldown (no damage to the player)

        UU_Sprite.GetComponent<UU_AnimScript>().EndCooldown();
        //UU_Sprite.GetComponent<UU_AnimScript>().GetDamage = 2; // Starts CooldownEndTrigger
        //GameObject.Find("SpriteControl").GetComponent<SpriteColorControl>().Cooldown = 2;
        Spawner.GetComponent<SpawnerScript>().FreezeLock = false;
        FreezeLocked = false;
    }

}
