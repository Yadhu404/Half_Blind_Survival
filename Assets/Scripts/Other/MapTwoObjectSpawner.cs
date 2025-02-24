using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTwoObjectSpawner : MonoBehaviour
{
    public GameObject[] Detecters = {};
    public GameObject[] Objects  = {};

    //Enemy Positions
    public float[] posX = {};
    public float[] posY = {};

    //Ghost Postions
    public float[] GhostPosX = {};
    public float[] GhostPosY = {};


    //Caver 2.O List
    public List<GameObject> caver2O = new List<GameObject>();

    //Object numbers
    private float Caver_num = 5;
    private float Caver_2O_num = 3;
    private float Ghost_num = 2;

    //Boolean checks
    public bool flag0 = true;
    public bool isGhostSpawn = false;
    public bool mapTwo = false;

    private PlayerDetectionSC playerDetectionSC;
    private MapOneObjectSpawner mapOneObjectSpawner;

    private medikitSpawnManager medikitSpawnManager;
    public GameObject MedkitObject;

    public GameObject enemyParent1;
    public GameObject enemyParent2; 

    public GameObject Player;
    private playerMove playerMove;
    

    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = Player.GetComponent<playerMove>();

        playerDetectionSC = Detecters[0].GetComponent<PlayerDetectionSC>();
        
        mapOneObjectSpawner = GameObject.Find("Map Objects Spawner/Map1").GetComponent<MapOneObjectSpawner>();

        medikitSpawnManager = MedkitObject.GetComponent<medikitSpawnManager>();

        // enemyParent1 = GameObject.Find("EnemyObj/Map_2/CAVER");
        // enemyParent2 = GameObject.Find("EnemyObj/Map_2/CAVER_2O");
    }

    // Update is called once per frame
    void Update()
    {
        if(flag0)
        {
            if(playerDetectionSC.panel2 != null || playerMove.GetPlayerMapState() == "Map_Two")
            {
                medikitSpawnManager.SpawnMedkitMapTwo(); //Spawns medikit
                
                SpawnEnemyMapTwo(); //Spawns enemies
                SpawnGhost(); //Spawns ghosts
                flag0 = false;
            }
        }
    }


    //Spawns Medikit in Map 2
    public void SpawnMedikitMapTwo(float xPos, float yPos) 
    {
        GameObject med = Instantiate(Objects[3],new Vector3(xPos, yPos, 0),Quaternion.identity);
        med.transform.SetParent(MedkitObject.transform); 
    }




    //Spawns Enemies
    void SpawnEnemyMapTwo()
    {
        mapOneObjectSpawner.DespawnObject();  //Removes Enemy from Map 1

        mapTwo = true;
        //Spawning Caver 2.O
        for(i = 0;i < Caver_2O_num;i++)
        {
            GameObject caver_2O = Instantiate(Objects[0],new Vector3(posX[i],posY[i],0),Quaternion.identity);
            caver_2O.transform.SetParent(enemyParent2.transform);

            caver2O.Add(caver_2O);
        }

        //Spawning Caver
        for(int j = i;j < Caver_num + Caver_2O_num;j++)
        {
            GameObject caver = Instantiate(Objects[1],new Vector3(posX[j],posY[j],0),Quaternion.identity);
            caver.transform.SetParent(enemyParent1.transform);
        }
    }




    //Spawns Ghosts
    void SpawnGhost()
    {
        for(int k = 0;k < Ghost_num;k++)
        {
            int index = Random.Range(0,GhostPosX.Length);

            Instantiate(Objects[2], new Vector3(GhostPosX[index],GhostPosY[index],0),Quaternion.identity);
        }

        isGhostSpawn = true;
    }


}
