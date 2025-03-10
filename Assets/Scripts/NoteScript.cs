using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public GameObject NotePanel;
    public GameObject Note;
    public GameObject DoorMessagePanel;
    public GameObject DoorMessagePanel1;
    public EinstructionScript Einstructionflag;
    public EinstructionScript EinstrDetectObj;
    public MaindoorSc check;

    public string hitObject;

    private bool isNoteRead = false;
    // Start is called before the first frame update
    void Start()
    {
        NotePanel.SetActive(false);
        Note.SetActive(true);

        DoorMessagePanel.SetActive(false);
        DoorMessagePanel1.SetActive(false);

        check = GameObject.Find("Main Door").GetComponent<MaindoorSc>();
    }

    // Update is called once per frame
    void Update()
    {
        hitObject = EinstrDetectObj.detectObject;

        isNoteRead = hitObject == "Note" ? true : false;
       
        if(isNoteRead)
        {
            DisplayNote();
        }

        if((hitObject == "Door1" || hitObject == "Door2") && Einstructionflag.flag){
            DoorMessage();
        }
        else{
            DoorMessagePanel.SetActive(false);
            DoorMessagePanel1.SetActive(false);
        }
    }

    void DisplayNote(){
       
        if(Input.GetKeyDown("e")){
            NotePanel.SetActive(true);

            Time.timeScale = 0f;
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            NotePanel.SetActive(false);

            isNoteRead = false;
            Time.timeScale = 1f;
        }
    }

    void DoorMessage(){
        if(Input.GetKeyDown("e")){
            if(playerMove.instance.GetPlayerMapState() == "Map_2")
            {
                DoorMessagePanel1.SetActive(true);
                return;
            }

            if(!check.check1){
                DoorMessagePanel.SetActive(true);
            }
            else{
                DoorMessagePanel1.SetActive(true);
            }
        }
    }

}
