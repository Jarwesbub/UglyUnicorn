using System.Collections;
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
    

    bool feezeLocked = false;

    int distanceFromExtraLife = 5; // How many times bomb explodes on dragon -> player gets extra HP
    int dragonDamageStack = 0; // how many times dragon has taken damage (gets reset if player takes damage)

    void Start()
    {
        Dragon_Sprite = GameObject.Find("Dragon_sprite");
        UU_Sprite = GameObject.Find("UU_sprite");



    }

    void DestroyAllObjects()
    {
        for (int i = 0; i < CloneParent.transform.childCount; i++)
        {
            Destroy(CloneParent.transform.GetChild(i).gameObject);
        }

    }



    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Ball1" || other.gameObject.tag == "Ball2")
            {
            DamageControl();
            dragonDamageStack = 0; //Resets current HP stack
            Destroy(other.gameObject);

            Stats.GetComponent<ReactionsScript>().StartReactions(false); //Hit was NOT successful
            UU_Sprite.GetComponent<UU_AudioScript>().PlayerMissSound(); // Sound effect
        }
        else if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Bomb") // Dragon gets Damage here
        { 
            Destroy(other.gameObject);

            SpriteControl.GetComponent<SpriteColorControl>().DragonGetsDamage();
            Stats.GetComponent<ReactionsScript>().StartReactions(true); //Hit was succesful!
            UU_Sprite.GetComponent<UU_AudioScript>().DragonHitObstacleSound(); // Sound effect

            dragonDamageStack += 1;

            if (dragonDamageStack == distanceFromExtraLife) //HP stack calculation for extra HP
            {
                Stats.GetComponent<StatsScript>().GetHP += 1;
                Dragon_Sprite.GetComponent<Dragon_AnimScript>().DragonPosition(false);
                dragonDamageStack = 0;
                UU_Sprite.GetComponent<UU_AudioScript>().PlayerGetHPSound(); // Sound effect
            }
        }
    }

    public void DamageControl()
    {
        if (!feezeLocked)
        {
            Stats.GetComponent<StatsScript>().DecreaseSpeed();
            StartCoroutine(FreezeLockCoolDown());
        }
    }

    IEnumerator FreezeLockCoolDown()
    {
        feezeLocked = true;
        Spawner.GetComponent<SpawnerScript>().freezeLock = true;
        UU_Sprite.GetComponent<UU_AnimScript>().StartCooldown();

        DestroyAllObjects();

        yield return new WaitForSeconds(3f); // How many seconds player is in cooldown (no damage to the player)

        UU_Sprite.GetComponent<UU_AnimScript>().EndCooldown();
        Spawner.GetComponent<SpawnerScript>().freezeLock = false;
        feezeLocked = false;
    }

}
