using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Quaternion = UnityEngine.Quaternion;

public class PlayerPositionSet : MonoBehaviour
{
    public GameObject Player;
    public GameObject Pause_Panel;
    public GameObject Dead_Panel;

    private Vector2 playerTempPos;

    public Vector2[] positionNearGate = {};

    private playerMove playerMove;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = Player.GetComponent<playerMove>();

        Player.transform.position = playerMove.GetPlayerPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.activeSelf)
        {
            playerTempPos = Player.transform.position;
        }
    }

    void OnApplicationQuit()
    {
        playerMove.SavePlayerPosition(playerTempPos.x,playerTempPos.y);
    }

    void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            playerMove.SavePlayerPosition(playerTempPos.x,playerTempPos.y);
        } 
    }


    //On Game Retry
    public void SetPositionNearGate()
    {
        Time.timeScale = 1f;
        
        playerMove.PlayerHealth = 100;
        
        if(!Player.activeSelf)
        {
            Player.SetActive(true);
            playerMove.isDead = false;
        }
        if(Pause_Panel.activeSelf)
        {
            Pause_Panel.SetActive(false);
        }
        if(Dead_Panel.activeSelf)
        {
            Dead_Panel.SetActive(false);
        }

        if(playerMove.GetPlayerMapState() == "Map_One")
        {
            Player.transform.position = new Vector2(positionNearGate[0].x, positionNearGate[0].y);
        }
        else if(playerMove.GetPlayerMapState() == "Map_Two")
        {
            Player.transform.position = new Vector2(positionNearGate[1].x, positionNearGate[1].y);
            // Player.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }
}
