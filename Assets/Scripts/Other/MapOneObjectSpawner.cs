using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MapOneObjectSpawner : MonoBehaviour
{
    public GameObject[] Detecters = {};
    public GameObject[] Objects  = {};

    //Enemy Positions
    public float[] enemyPosX = {};
    public float[] enemyPosY = {};

    public List<GameObject> removeObj = new List<GameObject>();
    private float mapOneObjCount = 0;

    //Object Count
    private int Caver_num = 4; 
    //Boolean
    private bool flag0 = true;
    public bool mapOne = false;
    private PlayerDetectionSC playerDetectionSC;
    private medikitSpawnManager medikitSpawnManager;
    public GameObject MedkitObject;

    public GameObject Player;
    private playerMove playerMove;

    public GameObject enemyParent;
    public GameObject MedikitObject; 
    // Start is called before the first frame update
    void Start()
    {
        playerDetectionSC = Detecters[0].GetComponent<PlayerDetectionSC>();

        medikitSpawnManager = MedkitObject.GetComponent<medikitSpawnManager>();

        playerMove = Player.GetComponent<playerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(flag0)
        {
            if(playerDetectionSC.panel1 != null || playerMove.GetPlayerMapState() == "Map_1")
            {
                SpawnEnemyMapOne(); //Spawns enemies
                medikitSpawnManager.SpawnMedkitMap_1(); //Spawns medkit
                flag0 = false;
            }
        }
    }

    void SpawnEnemyMapOne()  //Spawns Enemy from Map 1
    {
        mapOne = true;
        for(int i = 0;i < Caver_num;i++)
        {
            GameObject enemy = Instantiate(Objects[0],new Vector3(enemyPosX[i],enemyPosY[i],0),Quaternion.identity);
            enemy.transform.SetParent(enemyParent.transform);

            removeObj.Add(enemy);

            mapOneObjCount = removeObj.Count;
        }
    }

    public void SpawnMedikitMapOne(float xPos, float yPos) //Spawns Medikit in Map 1
    {
        GameObject med = Instantiate(Objects[1],new Vector3(xPos, yPos, 0),Quaternion.identity);
        med.name = Objects[1].name;
        med.transform.SetParent(MedikitObject.transform); 

        removeObj.Add(med);

        mapOneObjCount = removeObj.Count;
    }

    public void DespawnObject()   //Removes Objects from Map 1
    {
        for(int i = 0;i < mapOneObjCount;i++)
        {
            Destroy(removeObj[i]);
        }
        removeObj.Clear();
        mapOneObjCount = removeObj.Count;
    }
}
