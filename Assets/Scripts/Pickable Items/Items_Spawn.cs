using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items_Spawn : MonoBehaviour
{
    //Battery
    public GameObject Battery;
    public GameObject GhostManipulator;
    public Vector2[] battery_pos = {};
    public Vector2[] Gman_pos = {};
    private int Battery_num = 8;    
    private int Gman_num = 5;    

    private GameObject Player;
    public static Items_Spawn items_Spawn;
    void Awake()
    {
        items_Spawn = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        SpawnBattery();
    }

    void SpawnBattery()
    {
        //Spawning Battery
        for(int i=0;i < Battery_num;i++)
        {
            GameObject battery = Instantiate(Battery,battery_pos[i],Quaternion.identity);
            battery.name = Battery.name;                   //Removes the "Clone".
            battery.transform.SetParent(gameObject.transform);
        }

        //Spawning Ghost Manipulator
        for(int i = 0;i < Gman_num;i++)
        {
            GameObject gManipulator = Instantiate(GhostManipulator,Gman_pos[i],Quaternion.identity);
            gManipulator.name = GhostManipulator.name;
            gManipulator.transform.SetParent(gameObject.transform);
        }
    }

    public void SetOnGroundActivate()
    {
        Instantiate(GhostManipulator,Player.transform.position,Quaternion.identity);
        GhostManipulatorScript.ghostManipulatorScript.isActivated = true;
    }
}
