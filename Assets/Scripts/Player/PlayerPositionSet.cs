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

    public Vector2[] retryPlayerPosition = {};

    private playerMove playerMove;

    private bool check = false;

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

    public void SetPotionOnHome()
    {
        playerMove.SavePlayerPosition(playerTempPos.x,playerTempPos.y);
    }



    //On Game Retry
    public void SetPositionNearGate()
    {
        ResetSavedVariables.instance.ResetInventory();

        playerMove.instance.SavePlayerHealth(100);    

        Time.timeScale = 1f;
        
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

        if(playerMove.GetPlayerMapState() == "Map_1")
        {
            Player.transform.position = new Vector2(retryPlayerPosition[0].x, retryPlayerPosition[0].y);
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            check = true;
        }
        else if(playerMove.GetPlayerMapState() == "Map_2")
        {
            Player.transform.position = new Vector2(retryPlayerPosition[1].x, retryPlayerPosition[1].y);
            Player.transform.rotation = Quaternion.Euler(0, 0, -90);
            check = true;
        }
        else if(playerMove.GetPlayerMapState() == "Map_0")
        {
            Player.transform.position = new Vector2(retryPlayerPosition[2].x, retryPlayerPosition[2].y);
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            check = true;
        }
        else
        {
            check = false;
        }

        if(check)
        {
            check = false;
            playerMove.SavePlayerPosition(Player.transform.position.x,Player.transform.position.y);
            SceneManagersc.instance.LoadToLoadScene();   
        }
    }
}
