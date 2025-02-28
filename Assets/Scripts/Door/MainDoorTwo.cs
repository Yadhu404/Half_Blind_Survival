using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MainDoorTwo : MonoBehaviour
{
    public Transform DiamondasChild;
    public GameObject DiamondHolder;
    public GameObject Diamond;
    public GameObject Player;
    public Light2D MapTwoDoorLamp;
    public GameObject PlayerDetecter;
    private PlayerDetectionSC playerDetectionSC;
    private playerMove playerMove;
    private bool doorCheck = true;
    private DoorManager doorManager;
    // Start is called before the first frame update
    void Start()
    {
        doorManager = GetComponent<DoorManager>();

        MapTwoDoorLamp.intensity = 0; //Initially no Light

        playerDetectionSC = PlayerDetecter.GetComponent<PlayerDetectionSC>();

        playerMove = Player.GetComponent<playerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(doorCheck)
        {
            if(playerDetectionSC.panel2 != null && (playerMove.GetPlayerMapState() == "Map_2"))
            {
                doorManager.DoorClose();
                doorCheck = false;

                MapTwoDoorLamp.intensity = 0;  //Puts off the lamp near Map 2
            }      
        }
    }
    public bool CheckDiamondwithPlayer()
    {
        DiamondasChild = DiamondHolder.transform.Find(Diamond.name); 

        if(DiamondasChild != null)  //Checks if the Player has the Diamond
        {
            doorManager.DoorOpen();  //Opens the Door to Map 2

            MapTwoDoorLamp.intensity = 1; //Puts on the lamp near Map 2

            return false;
        }
        return true;
    }
}
