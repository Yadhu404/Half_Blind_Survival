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
        // Debug.Log(EinstrDetectObj.detectObject);
        if(EinstrDetectObj.detectObject == "Note"){
            DisplayNote();
        }

        if((EinstrDetectObj.detectObject == "Door1" || EinstrDetectObj.detectObject == "Door2") && Einstructionflag.flag){
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

            Note.SetActive(false);
        }
        
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            Note.SetActive(true);

            NotePanel.SetActive(false);
        }   
    }

    void DoorMessage(){
        if(Input.GetKeyDown("e")){
            if(!check.check1){
                DoorMessagePanel.SetActive(true);
            }
            else{
                DoorMessagePanel1.SetActive(true);
            }
        }
    }

}
