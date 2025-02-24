using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionSC : MonoBehaviour
{
    public Transform MapOneDoorPanel;
    public Transform MapTwoDoorPanel;
    public Collider2D panel1,panel2;

    private playerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<playerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        panel1 = Physics2D.OverlapBox(MapOneDoorPanel.position,MapOneDoorPanel.localScale,0f,LayerMask.GetMask("Player"));
        
        panel2 = Physics2D.OverlapBox(MapTwoDoorPanel.position,MapTwoDoorPanel.localScale,0f,LayerMask.GetMask("Player"));


        if(panel1 != null)
        {
            playerMove.whichMap = "Map_One";
            playerMove.SavePlayerMapState();
        }
        else if(panel2 != null)
        {
            playerMove.whichMap = "Map_Two";
            playerMove.SavePlayerMapState();
        }
    }
}
