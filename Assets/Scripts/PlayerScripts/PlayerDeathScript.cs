using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    public GameObject DeathExplosion;

    private GameObject Dragon_sprite;
    private GameObject UU_sprite;

    void Awake()
    {
        Dragon_sprite = GameObject.Find("Dragon_sprite");
        UU_sprite = GameObject.Find("UU_sprite");
    }


    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(StartDeath());
    }


    IEnumerator StartDeath()
    {
        yield return new WaitForSeconds(1f);

        Dragon_sprite.GetComponent<Dragon_AnimScript>().DragonFireBreath(); // Dragon starts fire animation

        yield return new WaitForSeconds(0.5f);

                //DeathExplosion.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(0f);

        UU_sprite.GetComponent<UU_AnimScript>().PlayerDiesAnim(); // Player starts death animation
    }

}
