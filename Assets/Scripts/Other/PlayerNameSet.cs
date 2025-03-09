using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameSet : MonoBehaviour
{
    public TMP_InputField playerName;
    public TextMeshProUGUI pName;

    public static PlayerNameSet instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(pName != null)
        {
            pName.text = GetPlayerName();
        }
    }

    //Save Player's name
    public void SetPlayerName()
    {

        if(playerName.text != null)
        {
            PlayerPrefs.SetString("Player_Name",playerName.text);
            PlayerPrefs.Save();

            pName.text = GetPlayerName();
        }
    }

    //Returns player's name
    public string GetPlayerName()
    {
        return PlayerPrefs.GetString("Player_Name");
    }
}
