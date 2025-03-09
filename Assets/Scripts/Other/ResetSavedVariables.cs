using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSavedVariables : MonoBehaviour
{
    public static ResetSavedVariables instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetVariables()
    {
        playerMove.instance.SavePlayerPosition(1.95f,-14.39f);  //Reset the Player's Position

        playerMove.instance.whichMap = "Map_0";         //Reset the Map State
        playerMove.instance.SavePlayerMapState();

        //Reset the Invetory Data
        ResetInventory();


    }

    public void ResetInventory()
    {
        for(int i=0;i<InventoryManager.instance.inventoryStore.Length;i++) 
        {
            InventoryManager.instance.SaveInventoryItems("",i);
        }
        InventoryManager.instance.IsInventoryFilled(0);
    }
}
