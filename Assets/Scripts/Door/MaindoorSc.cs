using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaindoorSc : MonoBehaviour
{
    public GameObject DoorSwitch;
    public GameObject PlayerDetecter;
    private PlayerDetectionSC playerDetectionSC;
    public float playerDetectDist = 1f;
    public bool flag = true;
    private bool check = false;
    public bool check1 = false;
    public AudioClip SwitchSond;
    public AudioSource switchAudioSRC;
    private DoorManager doorManager;
    private MainDoorTwo mainDoorTwo;
    // Start is called before the first frame update
    void Start()
    {
        doorManager = GetComponent<DoorManager>();

        mainDoorTwo = GameObject.Find("Map2 Main Door").GetComponent<MainDoorTwo>();

        playerDetectionSC = PlayerDetecter.GetComponent<PlayerDetectionSC>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        
    }

    void DetectPlayer(){

        //To open and close the door using the Switch
        Collider2D detectPlayer = Physics2D.OverlapCircle(DoorSwitch.transform.position,playerDetectDist,LayerMask.GetMask("Player"));

        if(detectPlayer != null){

            if(Input.GetKeyDown("e")){

                switchAudioSRC.clip = SwitchSond;
                switchAudioSRC.Play();  

                if(flag){
                    doorManager.DoorOpen();
                    flag = false;
                }
                else{
                    doorManager.DoorClose();
                    flag = true;
                }
            }
        }

        //To close the door once the Player got inside  the Maze
        CheckPlayerInside();

        //To open the door to the MAP 2 if the player has the Diamond
        if(flag)
        {
            flag = mainDoorTwo.CheckDiamondwithPlayer();
        }
    }


    void CheckPlayerInside()
    {
        
        if(playerDetectionSC.panel1 != null){
            if(!check){
                doorManager.DoorClose();
                check1 = true;
            }

            check = true;
            flag = true;
        }
    }
}
