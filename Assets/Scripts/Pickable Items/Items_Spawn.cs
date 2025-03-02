using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items_Spawn : MonoBehaviour
{
    //Battery
    public GameObject Battery;
    public Vector2[] battery_pos = {};
    private int Battery_num = 8;

    public List<GameObject> remBattery = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        SpawnBattery();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBattery()
    {
        for(int i=0;i < Battery_num;i++)
        {
            GameObject battery = Instantiate(Battery,battery_pos[i],Quaternion.identity);
            battery.name = Battery.name+(i+1);                   //Removes the "Clone".
            battery.transform.SetParent(gameObject.transform);

            remBattery.Add(battery);
        }
    }
}
