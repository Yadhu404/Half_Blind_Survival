using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkitScript : MonoBehaviour
{
    private playerMove playerMove;
    private MapOneObjectSpawner mapOneObjectSpawner;
    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<playerMove>();
        mapOneObjectSpawner = GameObject.Find("Map Objects Spawner/Map1").GetComponent<MapOneObjectSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMove.playerHitMedkit){ 
            if(mapOneObjectSpawner.removeObj.Count > 0)
            {
                mapOneObjectSpawner.removeObj.RemoveAt(4);
            }  
            Destroy(gameObject);
        }
    }
}
