using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinstructionScript : MonoBehaviour
{
    public Transform Player;
    public GameObject EtoPick;
    public GameObject EtoOpen;
    public float detectDist = 1f;
    public string detectObject;
    public bool flag = false;
   
    // Start is called before the first frame update
    void Start()
    {
        EtoPick.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DetectIneteractable();
    }

    void DetectIneteractable(){
        Collider2D detect = Physics2D.OverlapCircle(Player.position,detectDist,LayerMask.GetMask("interobj"));

        if(detect != null){

            detectObject = detect.gameObject.name;
            flag = true;

            if(detect.gameObject.name == "Door1" || detect.gameObject.name == "Door2" || detect.gameObject.name == "Door Switch")
            {
                ShowMessage(EtoOpen);
            }
            else if(detect.gameObject.name == "Note")
            {
                ShowMessage(EtoPick);
            }
        }
        else if(flag){
            detectObject = "";
            flag = false;
            ShowMessage(EtoPick);
            ShowMessage(EtoOpen);

        }
    }

    void ShowMessage(GameObject Einstr){
        if(flag){
            Einstr.SetActive(true);
        }
        else{
            Einstr.SetActive(false);
        }
    }
}
