using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSurvivorConnv : MonoBehaviour
{
    //Survivor
    public GameObject Survivor;

    //E Instruction
    public GameObject E_instruction;

    //Chats
    public GameObject Chat_Panel;
    public TextMeshProUGUI playerConv;
    public TextMeshProUGUI survivorConv;

    //Index
    private int i = 0;

    //Chats
    private string[] Conversation = {
        "Heyy...Can you hear me ?",
        "Ahhg...Who are you ?",
        "",
        "Ohh....you survived in there...",
        "What happened ?",
        "I couldn't make this out.",
        "I can help you.",
        "No...no, you leave here, i don't think i can survive anymore....Its better ending up here.",
        "But...How can I leave you here...",
        "It's fine...There is a small base nearby...go find it. You can light up some paths in here...but be careful..its danger.",
        "What is in there ?",
        "Keep moving...You will find it out. Don't rest for longer time",
        "Okay...Ill find it...Thank you."
    };
    // Start is called before the first frame update
    void Start()
    {
        E_instruction.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D isNearSurvivor = Physics2D.OverlapCircle(Survivor.transform.position,3f,LayerMask.GetMask("Player"));

        if(isNearSurvivor != null)  //Checks if the player as approached neare the player
        {
            if(i < Conversation.Length)
            {
                E_instruction.SetActive(true);
            }
            else
            {
                E_instruction.SetActive(false);
            }

            if(Input.GetKeyDown("e"))     
            {
                if(i < Conversation.Length)
                {
                    ShowChats();
                }
                else
                {
                    playerConv.text = "";
                    survivorConv.text = "";
                }
            }
        }
        else
        {
            E_instruction.SetActive(false);
            playerConv.text = "";
            survivorConv.text = "";
            i = 0;
        }
    }

    void ShowChats()   //Shows the conversations
    {
        if(i % 2 == 0)
        {
            if(i == 2)
            {
                playerConv.text = "I am "+PlayerNameSet.instance.GetPlayerName()+", I was the next one to get in.";
            }
            else
            {
                playerConv.text = Conversation[i];
            }
        }
        else
        {
            survivorConv.text = Conversation[i];
        }

        i++;
    }
}
