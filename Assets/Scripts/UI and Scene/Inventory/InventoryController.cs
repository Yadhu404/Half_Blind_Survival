using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject InventoryPanel;
    // Start is called before the first frame update
    void Start()
    {
        InventoryPanel.SetActive(false);
    }

    public void Open_Inventory()
    {
        InventoryPanel.SetActive(true);
    }

    public void Close_Inventory()
    {
        InventoryPanel.SetActive(false);
    }
}
