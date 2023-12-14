using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Stats;
    public GameObject Obj1;
    public GameObject Obj2;
    public GameObject Fence;
    public GameObject Stone;
    public GameObject CloneParentObj;
    private GameObject SceneLevel;
    private GameObject PlayerControl;

    public int difficultyLevel;
    public float addSpeed = 0.2f;

    public bool freezeLock = false;
    public bool spawnStart;
    bool damageWait = false;

    public int level; //This works for player animations too

    public int chooseObj;
    int objCount;
    int objMaxCount;

    public bool bombWaitTimer;
    public float waitSpawnerTime;

    void Start()
    {
        SceneLevel = GameObject.Find("SpawnControl");
        PlayerControl = GameObject.Find("PlayerControl");

        addSpeed = 0.2f;

        spawnStart = true;
        bombWaitTimer = false;

        gameObject.GetComponent<BombWaitScript>().enabled = false;
    }


    void Update()
    {
        if (spawnStart & !freezeLock && objCount == 0)
        {
            if (!PlayerControl.GetComponent<PlayerController>().CheckIfPlayerGotHit())
            {
                spawnStart = false;
                CreateObject();
                
            }
            else if (!damageWait)
            {
                StartCoroutine(DamageWait());
            }
        }


    }

    void SetSpawnControllerObject()
    {
        SceneLevel.GetComponent<SpawnController>().ChooseObject(level); // Spawns a new object

    }
    

    void CreateObject()
    {
        SetSpawnControllerObject();

        if (difficultyLevel == 1) // EASY LEVEL
        {
            if (level == 0)
            {
                objMaxCount = 1;
            }
            else if (level == 1)
            {
                objMaxCount = 2;
            }
            else if (level == 2)
            {
                objMaxCount = 2;
            }
            else // Level 3 or more
            {
                objMaxCount = 2;
            }

        }
        else // OTHER LEVELS (normal, hard)
        {
            objMaxCount = 3;
        }

        objCount = Random.Range(1, objMaxCount+1);

        if (chooseObj == 1 || chooseObj == 2 || chooseObj == 3 || chooseObj == 4) // 3-4 = Obstacles
        {
            int numb = 0;
            int add = 6; //original = 5;

            do
            {
                SetSpawnControllerObject();

                if (chooseObj == 1) // RED
                {
                    var OBJ = Instantiate(Obj1, new Vector3(Obj1.transform.position.x + (numb), Obj1.transform.position.y, Obj1.transform.position.z), Quaternion.identity);
                    OBJ.transform.parent = CloneParentObj.transform;
                    OBJ.layer = LayerMask.NameToLayer("Clones");
                    

                    numb += add;
                    objCount -= 1;
                }
                else if (chooseObj == 2) // BLUE
                {

                    var OBJ = Instantiate(Obj2, new Vector3(Obj2.transform.position.x + (numb), Obj2.transform.position.y, Obj2.transform.position.z), Quaternion.identity);
                    OBJ.transform.parent = CloneParentObj.transform;
                    OBJ.layer = LayerMask.NameToLayer("Clones");

                    numb += add;
                    objCount -= 1;
                }
                else if (chooseObj == 3 && !bombWaitTimer) // FENCE
                {
                    bombWaitTimer = true;

                    var OBJ = Instantiate(Fence, new Vector3(Fence.transform.position.x + (numb), Fence.transform.position.y, Fence.transform.position.z), Quaternion.identity);
                    OBJ.transform.parent = CloneParentObj.transform;
                    OBJ.layer = LayerMask.NameToLayer("Clones");

                    numb += add;
                    objCount = 0; // Only Bomb spawns
                    gameObject.GetComponent<BombWaitScript>().enabled = true;

                }
                else if (chooseObj == 4 && !bombWaitTimer) // FENCE
                {
                    bombWaitTimer = true;

                    var OBJ = Instantiate(Stone, new Vector3(Stone.transform.position.x + (numb), Stone.transform.position.y, Stone.transform.position.z), Quaternion.identity);
                    OBJ.transform.parent = CloneParentObj.transform;
                    OBJ.layer = LayerMask.NameToLayer("Clones");

                    numb += add;
                    objCount = 0; // Only Bomb spawns

                    gameObject.GetComponent<BombWaitScript>().enabled = true;

                }

            }
            while (objCount > 0);

        }

        if (objCount == 0)
        {
            StartCoroutine(WaitAfterSpawn());
        }
    }

    IEnumerator WaitAfterSpawn()
    {
        yield return new WaitForSeconds(waitSpawnerTime);
        SceneLevel.GetComponent<SpawnController>().GetSpawnTimer();

    }


    IEnumerator DamageWait()
    {
        damageWait = true;
        yield return new WaitForSeconds(1f); //How long wait before Spawner activates again
        damageWait = false;
        PlayerControl.GetComponent<PlayerController>().SetPlayerGotHit(false);
    }

}
