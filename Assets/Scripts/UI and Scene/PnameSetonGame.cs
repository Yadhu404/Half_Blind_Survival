using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PnameSetonGame : MonoBehaviour
{
    public TextMeshProUGUI PlayerName;
    // Start is called before the first frame update
    void Start()
    {
        PlayerName.text = PlayerPrefs.GetString("Player_Name");
    }
}
