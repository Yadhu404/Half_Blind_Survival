using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medikitSpawnManager : MonoBehaviour
{
    public GameObject medikit;
    public double[] medKitPosX_1= {44.5,71.5,2,58.5};
    public double[] medKitPosY_1 = {53,-2.4,52.5,65};
    public double[] medKitPosX_2 = {121.7,177.94,353.77,233.97,180.85,271.63,387.4,481.89,355.5,587.4};
    public double[] medKitPosY_2 = {27.17,27.5,13.35,154.03,204.36,244.12,68.7,109.52,366.7,506.5};
    public float timer = 0f;
    public int randomPos; 
    public int temp;
    private bool initMapTwospawn = true;

    private playerMove playerMove;
    private MapOneObjectSpawner mapOneObjectSpawner;
    private MapTwoObjectSpawner mapTwoObjectSpawner;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<playerMove>();

        mapOneObjectSpawner = GameObject.Find("Map Objects Spawner/Map1").GetComponent<MapOneObjectSpawner>();
        mapTwoObjectSpawner = GameObject.Find("Map Objects Spawner/Map2").GetComponent<MapTwoObjectSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMove.playerHitMedkit){   

            timer += Time.deltaTime;
            if(timer >= 10f){

                if(playerMove.whichMap == "Map_One")
                {
                    SpawnMedkitMapOne();
                }
                else if(playerMove.whichMap == "Map_Two")
                {
                    for(int i=0;i<2;i++)
                    {
                        SpawnMedkitMapTwo();
                    }
                }

                timer = 0f;

                playerMove.playerHitMedkit = false;  
            }
        }
    }

    public void SpawnMedkitMapOne(){

        randomPos = Random.Range(0,medKitPosX_1.Length);
        
        if(temp != randomPos){
            //Placing the med kit in random positions
            mapOneObjectSpawner.SpawnMedikitMapOne((float)medKitPosX_1[randomPos],(float)medKitPosY_1[randomPos]);
        }
        else{
            SpawnMedkitMapOne();
        }

         temp = randomPos;

    }

    public void SpawnMedkitMapTwo(){
        if(initMapTwospawn)
        {
            mapTwoObjectSpawner.SpawnMedikitMapTwo((float)medKitPosX_2[0],(float)medKitPosY_2[0]);
            initMapTwospawn = false;
        }
        
        randomPos = Random.Range(0,medKitPosX_2.Length);
        
        if(temp != randomPos){
            //Placing the med kit in random positions
            mapTwoObjectSpawner.SpawnMedikitMapTwo((float)medKitPosX_2[randomPos],(float)medKitPosY_2[randomPos]);
        }
        else{
            SpawnMedkitMapTwo();
        }

         temp = randomPos;
    }
}
