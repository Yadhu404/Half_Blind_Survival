using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutMap : MonoBehaviour
{
    public GameObject Player;
    private playerMove playerMove;

    public GameObject MapOutDetect_Obj;
    private PlayerDetectionSC playerDetectionSC;
    private MapTwoObjectSpawner mapTwoObjectSpawner;
    public GameObject portalObj;
    private PortalScript portalScript;

    private bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = Player.GetComponent<playerMove>();

        playerDetectionSC = MapOutDetect_Obj.GetComponent<PlayerDetectionSC>();

        mapTwoObjectSpawner = GameObject.Find("Map Objects Spawner/Map2").GetComponent<MapTwoObjectSpawner>();

        portalScript = portalObj.GetComponent<PortalScript>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Map State: "+playerMove.GetPlayerMapState());
        if(flag)
        {
            if(playerDetectionSC.panel3 != null || playerMove.GetPlayerMapState() == "Map_0")
            {
                if(portalScript.inPortal)
                {
                    mapTwoObjectSpawner.DespawnMapTwoObj();
                    flag = false;
                }
            }
        }
    }
}
