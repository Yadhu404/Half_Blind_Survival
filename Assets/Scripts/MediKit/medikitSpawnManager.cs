using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medikitSpawnManager : MonoBehaviour
{
    public double[] medKitPosX_1= {44.5,71.5,2,58.5};
    public double[] medKitPosY_1 = {53,-2.4,52.5,65};
    public double[] medKitPosX_2 = {121.7,177.94,353.77,233.97,180.85,271.63,387.4,481.89,355.5,587.4};
    public double[] medKitPosY_2 = {27.17,27.5,13.35,154.03,204.36,244.12,68.7,109.52,366.7,506.5};
    private bool initMapTwospawn = true;
    private MapOneObjectSpawner mapOneObjectSpawner;
    private MapTwoObjectSpawner mapTwoObjectSpawner;
    // Start is called before the first frame update
    void Start()
    {
        mapOneObjectSpawner = GameObject.Find("Map Objects Spawner/Map1").GetComponent<MapOneObjectSpawner>();
        mapTwoObjectSpawner = GameObject.Find("Map Objects Spawner/Map2").GetComponent<MapTwoObjectSpawner>();
    }

    public void SpawnMedkitMap_1(){
         for(int i = 0;i < medKitPosX_1.Length;i++)
         {
             mapOneObjectSpawner.SpawnMedikitMapOne((float)medKitPosX_1[i],(float)medKitPosY_1[i]);
         }
    }

    public void SpawnMedkitMap_2(){
        if(initMapTwospawn)
        {
            mapTwoObjectSpawner.SpawnMedikitMapTwo((float)medKitPosX_2[0],(float)medKitPosY_2[0]);
            initMapTwospawn = false;
        }
        
        for(int i = 1;i < medKitPosX_2.Length;i++)
        {
            mapTwoObjectSpawner.SpawnMedikitMapTwo((float)medKitPosX_2[i],(float)medKitPosY_2[i]);
        }
    }
}
