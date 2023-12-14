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

    int healthCalc;
    int health;

    bool gameStart;

    void Start()
    {
        Dragon_Sprite = GameObject.Find("Dragon_sprite");
        GetComponent<SpriteRenderer>();

        gameStart = true;
        healthCalc = Stats.GetComponent<StatsScript>().health;
    }
    void LateUpdate()
    {
        gameStart = !gameStart;

    }

    void Update()
    {
        health = Stats.GetComponent<StatsScript>().health;

        if (healthCalc - 1 >= health)
        {
            healthCalc = health;

                StartCoroutine(SpriteDamage());

        }

        else if (healthCalc + 1 <= health)
        {
            healthCalc = health;

            if (!gameStart)
            {
                StartCoroutine(SpriteGetHP());
            }
            else
            {
                gameStart = false;
            }

        }

    }

    public void DragonGetsDamage()
    {
        StartCoroutine(DragonDamage());
    }

    IEnumerator DragonDamage()
    {
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
        Dragon_Sprite.GetComponent<Dragon_AnimScript>().DragonBites();

        float BiteWaitTime = 0.2f;
        float ColorTime = 0.1f;

        EnemySpriteRenderer.color = EnemyAttack;
        yield return new WaitForSeconds(BiteWaitTime);
        PlayerSpriteRenderer.color = PlayerDMG;
        yield return new WaitForSeconds(ColorTime);
        PlayerSpriteRenderer.color = Normal;
        EnemySpriteRenderer.color = Normal;

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
