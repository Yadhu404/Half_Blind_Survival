using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinstructionScript : MonoBehaviour
{
    public Transform Player;
    private GameObject Einstruction;
    public float detectDist = 1f;
    public string detectObject;
    public bool flag = false;
   
    // Start is called before the first frame update
    void Start()
    {
        Einstruction = GameObject.Find("Canvas/E instruction");
        Einstruction.SetActive(false);
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

            ShowMessage();
        }
        else{
            flag = false;
            // detectObject = "No-Object";

            ShowMessage();
        }
    }

    void ShowMessage(){
        if(flag){
            Einstruction.SetActive(true);
        }
        else{
            Einstruction.SetActive(false);
        }
    }



    void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
             
        Gizmos.DrawWireSphere(Player.position, detectDist);
    }
}
