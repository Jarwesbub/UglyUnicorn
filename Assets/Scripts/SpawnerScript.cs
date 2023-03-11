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
    public GameObject Fence; // OBSTACLE
    public GameObject Stone; // OBSTACLE
    public GameObject CloneParentObj;
    public GameObject SceneLevel;
    private GameObject PlayerControl;

    public int DifficultyLevel;
    public float AddSpeed = 0.2f;//

    public bool FreezeLock = false;
    public bool SpawnStart;
    bool DamageWaiting = false;

    public int Level; //This works for player animations too
    float CurrentSpeed;
    public float MAINSPEED; //DELETE TESTING !!!!!!!!!!!!!!!!!!!!
    //public float SpeedChecker = 4f; //Adds +3 at the start // EARLIER BUILD
    //public float minTime, maxTime;

    public int ChooseObj;
    int ObjCount;
    int ObjMaxCount;
    int SpawnNumber;

    public bool BombWaitTimer;
    public float WaitSpawnerTime;



    void Start()
    {
        SceneLevel = GameObject.Find("SpawnControl"); /////////Object where Spawn(number)Control script is
        PlayerControl = GameObject.Find("PlayerControl");

        AddSpeed = 0.2f;

        SpawnStart = true;
        BombWaitTimer = false;

        gameObject.GetComponent<BombWaitScript>().enabled = false;
    }


    void Update()
    {
        MAINSPEED = Stats.GetComponent<StatsScript>().Speed; // DELETE LATER !!!!!!!!!!!!!!!!!!!!!!!!



        if (SpawnStart == true & FreezeLock == false && ObjCount == 0) // OBJCount == TESTING
        {
            if (PlayerControl.GetComponent<PlayerController>().GetHit == false)
            {
                SpawnStart = false;
                CreateObject();
                
            }
            else if (DamageWaiting == false)
            {
                StartCoroutine(DamageWait());
            }
        }


    }

    void GetSpawnController() // For new levels use "Spawn(Level number)Controller" as a script in SceneLevel.GetComponent
    {
        if (DifficultyLevel == 1) // Scene 1
        {
            SceneLevel.GetComponent<Spawn1Controller>().ChooseObject(Level);
            
        }
        else //Testing
        {
            SceneLevel.GetComponent<Spawn1Controller>().ChooseObject(Level);


        }


        /*
        else if (SceneLEVEL == 2) // Scene 2
        {


        }
        */
    }
    

    void CreateObject()
    {
        GetSpawnController();///////////////////////////////////////////////////////////////////////////////

        //ORIGINAL SCRIPT
        //ChooseObject(Level);

        if (DifficultyLevel == 1) // EASY LEVEL
        {
            if (Level == 0)
            {
                ObjMaxCount = 1;
            }
            if (Level == 1)
            {
                ObjMaxCount = 2;
            }
            if (Level == 2)
            {
                ObjMaxCount = 2;
            }
            if (Level >= 3)
            {
                ObjMaxCount = 2;
            }

        }
        else // OTHER LEVELS (normal, hard)
        {
            ObjMaxCount = 3;
        }

        ObjCount = Random.Range(1, ObjMaxCount+1);
        SpawnNumber = ObjCount;

        if (ChooseObj == 1 || ChooseObj == 2 || ChooseObj == 3 || ChooseObj == 4) // 3-4 = Obstacles
        {
            int Numb = 0;
            int Add = 6; //original = 5;

            do
            {
                //ORIGINAL SCRIPT
                //ChooseObject(Level);

                GetSpawnController();///////////////////////////////////////////////////////////////////////////

                if (ChooseObj == 1) // RED
                {

                    var OBJ = Instantiate(Obj1, new Vector3(Obj1.transform.position.x + (Numb), Obj1.transform.position.y, Obj1.transform.position.z), Quaternion.identity);
                    OBJ.transform.parent = CloneParentObj.transform;
                    OBJ.layer = LayerMask.NameToLayer("Clones");
                    

                    Numb += Add;
                    ObjCount -= 1;
                }
                else if (ChooseObj == 2) // BLUE
                {

                    var OBJ = Instantiate(Obj2, new Vector3(Obj2.transform.position.x + (Numb), Obj2.transform.position.y, Obj2.transform.position.z), Quaternion.identity);
                    OBJ.transform.parent = CloneParentObj.transform;
                    OBJ.layer = LayerMask.NameToLayer("Clones");

                    Numb += Add;
                    ObjCount -= 1;
                }
                else if (ChooseObj == 3 && BombWaitTimer == false) // FENCE
                {
                    BombWaitTimer = true;

                    var OBJ = Instantiate(Fence, new Vector3(Fence.transform.position.x + (Numb), Fence.transform.position.y, Fence.transform.position.z), Quaternion.identity);
                    OBJ.transform.parent = CloneParentObj.transform;
                    OBJ.layer = LayerMask.NameToLayer("Clones");

                    Numb += Add;


                    ObjCount = 0; // Only Bomb spawns

                    gameObject.GetComponent<BombWaitScript>().enabled = true;

                }
                else if (ChooseObj == 4 && BombWaitTimer == false) // FENCE
                {
                    BombWaitTimer = true;

                    var OBJ = Instantiate(Stone, new Vector3(Stone.transform.position.x + (Numb), Stone.transform.position.y, Stone.transform.position.z), Quaternion.identity);
                    OBJ.transform.parent = CloneParentObj.transform;
                    OBJ.layer = LayerMask.NameToLayer("Clones");

                    Numb += Add;


                    ObjCount = 0; // Only Bomb spawns

                    gameObject.GetComponent<BombWaitScript>().enabled = true;

                }

            }
            while (ObjCount > 0);

        }

        if (ObjCount == 0)
        {
            StartCoroutine(WaitAfterSpawn());
        }
    }

    IEnumerator WaitAfterSpawn()
    {
        yield return new WaitForSeconds(WaitSpawnerTime);
        SceneLevel.GetComponent<Spawn1Controller>().GetSpawnTimer();

    }



    IEnumerator DamageWait()
    {
        DamageWaiting = true;
        yield return new WaitForSeconds(1f); //How long wait before Spawner activates again
        DamageWaiting = false;
        PlayerControl.GetComponent<PlayerController>().GetHit = false;
    }

}


/*
void ChooseObject(int lvl)
{
    int Percent = 0; // 1=2%

    if (lvl == 1 || lvl == 0)
    {
        Percent = Random.Range(1, 51); //50=100%

        if (Percent > 0 && Percent <= 50)
        {
            ChooseObj = Random.Range(1, 3);
        }
        else
        {
            ChooseObj = 3;
        }
    }

    if (lvl == 2)
    {
        Percent = Random.Range(1, 51); //50=100%

        if (Percent > 0 && Percent <= 45)
        {
            ChooseObj = Random.Range(1, 3);
        }
        else
        {
            ChooseObj = 3;
        }
    }

    if (lvl >= 3)
    {
        Percent = Random.Range(1, 51); //50=100%

        if (Percent > 0 && Percent <= 45)
        {
            ChooseObj = Random.Range(1, 3);
        }
        else
        {
            ChooseObj = 3;
        }
    }


    //ChooseObj = Random.Range(1, 4);





    
}



*/
/*
IEnumerator SpawnTimer2()
{
    float SpeedCalc = GameObject.Find("Stats").GetComponent<StatsScript>().Speed;
    float Time = 5f;

    if (SpeedCalc < 7f)
    {
        minTime = 4f;
        maxTime = 5f;

        Level = 1;
    }
    else if (SpeedCalc < 10f)
    {
        minTime = 3f;
        maxTime = 4f;
        Level = 2;
    }
    else if (SpeedCalc < 12f)
    {
        minTime = 1.5f;
        maxTime = 2f;
        Level = 3;
    }
    else if (SpeedCalc < 15f)
    {
        minTime = 1f;
        maxTime = 1.5f;
        Level = 4;
    }
    else if (SpeedCalc < 19f)
    {
        minTime = 0.8f;
        maxTime = 1f;
        Level = 5;
    }
    else if (SpeedCalc < 26f)
    {
        minTime = 0.6f;
        maxTime = 0.8f;
        Level = 6;
    }
    else if (SpeedCalc > 26f)
    {
        minTime = 0.4f;
        maxTime = 0.6f;
        Level = 7;
    }

    Time = Random.Range(minTime, maxTime);

    yield return new WaitForSeconds(Time);

    SpawnStart = true;

}
*/
