using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthbarsc : MonoBehaviour
{
    private playerMove playerhealth;
    public Slider playerhealthbar;
    public TextMeshProUGUI  playerhealthcount;
    // Start is called before the first frame update
    void Start()
    {
        playerhealth = GameObject.Find("Player").GetComponent<playerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //Changing the health bar of the player
        playerhealthbar.value = playerhealth.GetPlayerHealth();

        //Changing the player health count
        playerhealthcount.text = playerhealth.GetPlayerHealth().ToString();
    }
}
