using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MainDoorTwo : MonoBehaviour
{
    public GameObject Player;
    public Light2D MapTwoDoorLamp;
    public GameObject PlayerDetecter;
    private PlayerDetectionSC playerDetectionSC;
    private playerMove playerMove;
    private bool doorCheck = true;
    private DoorManager doorManager;


    public static MainDoorTwo instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        doorManager = GetComponent<DoorManager>();

        MapTwoDoorLamp.intensity = 1;  //Puts on the lamp near Map 2

        playerDetectionSC = PlayerDetecter.GetComponent<PlayerDetectionSC>();

        playerMove = Player.GetComponent<playerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(doorCheck)
        {
            if(playerMove.GetPlayerMapState() != "Map_2")
            {
                if(playerDetectionSC.panel2 != null)
                {
                    doorManager.DoorClose();
                    doorCheck = false;

                    MapTwoDoorLamp.intensity = 0;  //Puts off the lamp near Map 2

                    playerMove.whichMap = "Map_2";
                    playerMove.SavePlayerMapState();
                } 
            }     
        }
    }
    public void DoorAndLampMap_2()
    {
        doorManager.DoorOpen();  //Opens the Door to Map 2
    }
}
