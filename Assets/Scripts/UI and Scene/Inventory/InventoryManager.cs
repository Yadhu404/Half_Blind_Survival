using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class InventoryManager : MonoBehaviour
{
    public GameObject player;
    public GameObject E_to_pick;

    public LayerMask pickables;
    //Pickable Item
    public Sprite[] pickable_items = {};

    //Items in the Inventory
    public Image[] Inventory = {};
    public Button[] itemSelectButtons = {};
    private int index = -1;
    private int buttonIndex = -1;

    //Bools
    public bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        E_to_pick.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(player.transform.position,1f,pickables);

        if(hit != null)
        {
            E_to_pick.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                Match_Pickables(hit.gameObject, hit.gameObject.name);
            }
        }
        else
        {
            E_to_pick.SetActive(false);
        }
    }

    void Match_Pickables(GameObject pickable_Object, string pickable_name)
    {
        for(int i=0;i<pickable_items.Length;i++)
        {
            if(pickable_name.Contains(pickable_items[i].name))
            {
                Add_to_Inventory(i);
        
                Destroy(pickable_Object); //Destroys the object after picking

                break;
            }
        }
    }

    public void Add_to_Inventory(int i)  //Add the items to Inventory
    {
        if(index < Inventory.Length - 1)
        {
            index++;
        }
        else
        {
            return;
        }

        Image image = Inventory[index].GetComponent<Image>();
        Color newColor = image.color;
        newColor.a = 1f;
        image.color = newColor;

        Inventory[index].sprite = pickable_items[i]; //Setting the sprite
    }


    public void SelectItems(int index)
    {
        buttonIndex = index;
    }

    public void UseItems()
    {
        if(buttonIndex >= 0)
        {
            Transform parentSlot = itemSelectButtons[buttonIndex].GetComponent<Button>().transform.parent;

            if(parentSlot != null)
            {
                Image slot = parentSlot.GetComponent<Image>();

                if(slot != null && slot.sprite != null)
                {
                    //To increase charge of the torch
                    if(slot.sprite.name == "Battery")
                    {
                        TorchScript.torchScript.AddCharge();
                    }

                    //Resetting the color and sprite to null
                    RemoveItemsFromInventory();
                }
            }
        }
    }

    public void RemoveItemsFromInventory() // And to remove items from the inventory
    {
        Image image = Inventory[buttonIndex].GetComponent<Image>();
        Color newColor = image.color;
        newColor.a = 0.46f;
        image.color = newColor;
        Inventory[buttonIndex].sprite = null; 
    }
}
