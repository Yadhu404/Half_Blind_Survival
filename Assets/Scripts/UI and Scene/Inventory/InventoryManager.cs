using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

[System.Serializable]
public class InventoryData
{
    public List<string> items = new List<string>();
}

public class InventoryManager : MonoBehaviour
{
    public GameObject player;
    public GameObject E_to_pick;
    public TMP_Text InventoryFullMag;
    public LayerMask pickables;

    public Sprite[] pickable_items = {};
    public Image[] Inventory = {};
    public Button[] itemSelectButtons = {};

    public string[] inventoryStore = new string[10];
    private int index = -1;
    private int buttonIndex = -1;

    public static InventoryManager instance;
    void Start()
    {
        instance = this;

        if (GetSetValue() == 1)
        {
            FillInventory();
        }
        else
        {
            IsInventoryFilled(0);
        }

        E_to_pick.SetActive(false);
        InventoryFullMag.text = "";
    }

    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(player.transform.position, 1f, pickables);
        E_to_pick.SetActive(hit != null);

        if (hit != null && Input.GetKeyDown(KeyCode.E))
        {
            switch(hit.gameObject.name)
            {
                case "Fire Ring D":
                    SpawnPortal.instance.Spawn_Portal();
                    PlayerWonScript.instance.isPlayerWithDiamond = true;
                    break;
                case "Dark Diamond":
                    MainDoorTwo.instance.DoorAndLampMap_2();
                    break;
            }
            Match_Pickables(hit.gameObject, hit.gameObject.name);
        }
    }

    void FillInventory()
    {
        string[] itms = GetInventoryItems();
        foreach (string item in itms)
        {
            if (!string.IsNullOrEmpty(item))
            {
                Match_Pickables(null, item);
            }
        }
    }

    void Match_Pickables(GameObject pickable_Object, string pickable_name)
    {
        foreach (var item in pickable_items)
        {
            if (pickable_name.Contains(item.name) && Add_to_Inventory(Array.IndexOf(pickable_items, item), pickable_name))
            {
                if (pickable_Object != null)
                {
                    Destroy(pickable_Object);
                }
                return;
            }
        }
    }

    public bool Add_to_Inventory(int i, string pickable_name)
    {
        int slot = index < Inventory.Length - 1 ? ++index : SearchForEmptySlot();
        if (slot < 0)
        {
            InventoryFullMag.text = "Inventory Is Full";
            return false;
        }

        Inventory[slot].sprite = pickable_items[i];
        SetSlotVisibility(Inventory[slot], 1f);
        SaveInventoryItems(pickable_name, slot);

        return true;
    }

    public void SelectItems(int indx)
    {
        buttonIndex = indx;
    }

    public void UseItems()
    {
        if (buttonIndex < 0) return;

        Image slot = itemSelectButtons[buttonIndex].transform.parent.GetComponent<Image>();
        if (slot?.sprite == null) return;

        switch (slot.sprite.name)
        {
            case "Battery":
                TorchScript.torchScript.AddCharge();
                break;
            case "Ghost Manipulator":
                Items_Spawn.items_Spawn.SetOnGroundActivate();
                break;
            case "Med Kits":
                playerMove.instance.PlayerHealthInc();
                break;
        }

        RemoveItemsFromInventory();
        buttonIndex = -1;
    }

    public void RemoveItemsFromInventory()
    {
        if (buttonIndex < 0 || buttonIndex >= Inventory.Length) return;

        InventoryFullMag.text = "";
        SetSlotVisibility(Inventory[buttonIndex], 0.46f);
        Inventory[buttonIndex].sprite = null;
        SaveInventoryItems("", buttonIndex);
    }

    int SearchForEmptySlot()
    {
        for (int i = 0; i < Inventory.Length; i++)
        {
            if (Inventory[i].sprite == null) return i;
        }
        return -1;
    }

    void SetSlotVisibility(Image slot, float alpha)
    {
        Color newColor = slot.color;
        newColor.a = alpha;
        slot.color = newColor;
    }

    // Saving Data
    public void IsInventoryFilled(int st)
    {
        PlayerPrefs.SetInt("Fill", st);
        PlayerPrefs.Save();
    }

    int GetSetValue()
    {
        return PlayerPrefs.GetInt("Fill", 0);
    }

    public void SaveInventoryItems(string pickable_name, int indx)
    {
        if (indx < 0 || indx >= inventoryStore.Length) return;

        inventoryStore[indx] = pickable_name;

        InventoryData data = new InventoryData { items = new List<string>(inventoryStore) };
        string json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString("inventoryItems", json);
        PlayerPrefs.Save();

        IsInventoryFilled(1);
    }

    public string[] GetInventoryItems()
    {
        if (!PlayerPrefs.HasKey("inventoryItems")) return new string[10];

        string json = PlayerPrefs.GetString("inventoryItems");
        InventoryData data = JsonUtility.FromJson<InventoryData>(json);

        return data?.items?.ToArray() ?? new string[10];
    }
}