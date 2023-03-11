using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class SpriteColorControl : MonoBehaviour
{
    public GameObject Stats;
    private GameObject Dragon_Sprite;
    public SpriteRenderer PlayerSpriteRenderer;
    public SpriteRenderer EnemySpriteRenderer;

    public Color Normal;
    public Color PlayerHP;
    public Color PlayerDMG;
    public Color EnemyAttack;
    public Color EnemyDMG;

    //public int Value;
    public int HealthCalc;
    int Health;

    public bool GameStart;
    public bool DragonGetDamage = false;
    //public int Cooldown = 0; // 0 = Cooldown not active, 1 = Cooldown active, 2 = Cooldown stop

    void Start()
    {
        Dragon_Sprite = GameObject.Find("Dragon_sprite");
        GetComponent<SpriteRenderer>();

        GameStart = true;
        HealthCalc = Stats.GetComponent<StatsScript>().health;
    }
    void LateUpdate()
    {
        if (GameStart == true)
        {
            GameStart = false;
        }
    }

    void Update()
    {
        Health = Stats.GetComponent<StatsScript>().health;

        if (HealthCalc - 1 >= Health)
        {
            HealthCalc = Health;

                StartCoroutine(SpriteDamage());

        }

        if (HealthCalc + 1 <= Health)
        {
            HealthCalc = Health;

            if (GameStart == false)
            {
                StartCoroutine(SpriteGetHP());
            }
            else
            {
                GameStart = false;
            }

        }

        if (DragonGetDamage == true)
        {
            DragonGetDamage = false;
            StartCoroutine(DragonDamage());

        }



    }

    IEnumerator DragonDamage()
    {
        Dragon_Sprite.GetComponent<Dragon_AnimScript>().GetDamage = true;

        float ColorTime = 0.2f;
        float WaitTime = 0.1f;

        EnemySpriteRenderer.color = EnemyDMG;
        yield return new WaitForSeconds(ColorTime);
        EnemySpriteRenderer.color = Normal;
        yield return new WaitForSeconds(WaitTime);
        EnemySpriteRenderer.color = EnemyDMG;
        yield return new WaitForSeconds(ColorTime);
        EnemySpriteRenderer.color = Normal;
        yield return new WaitForSeconds(WaitTime);
        EnemySpriteRenderer.color = EnemyDMG;
        yield return new WaitForSeconds(ColorTime);
        EnemySpriteRenderer.color = Normal;

    }


    IEnumerator SpriteDamage()
    {
        Dragon_Sprite.GetComponent<Dragon_AnimScript>().Bite = true;

        float BiteWaitTime = 0.2f;
        float ColorTime = 0.1f;

        EnemySpriteRenderer.color = EnemyAttack;
        yield return new WaitForSeconds(BiteWaitTime);
        PlayerSpriteRenderer.color = PlayerDMG;
        yield return new WaitForSeconds(ColorTime);
        PlayerSpriteRenderer.color = Normal;
        EnemySpriteRenderer.color = Normal;
        //yield return new WaitForSeconds(MidTime);
        //PlayerSpriteRenderer.color = Normal;


    }

    IEnumerator SpriteGetHP()
    {
        float ColorTime = 0.1f;
        EnemySpriteRenderer.color = Color.red;
        PlayerSpriteRenderer.color = PlayerHP;
        yield return new WaitForSeconds(ColorTime);
        PlayerSpriteRenderer.color = Normal;
        EnemySpriteRenderer.color = Normal;

    }


}
