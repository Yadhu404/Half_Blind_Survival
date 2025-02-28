using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameSet : MonoBehaviour
{
    public TMP_InputField playerName;
    public TextMeshProUGUI pName;
    // Start is called before the first frame update
    void Start()
    {
        pName.text = GetPlayerName();
    }

    //Save Player's name
    public void SetPlayerName()
    {
        PlayerPrefs.SetString("Player_Name",playerName.text);
        PlayerPrefs.Save();

        pName.text = GetPlayerName();
        Debug.Log("Player Name: "+GetPlayerName());
    }

    //Returns player's name
    public string GetPlayerName()
    {
        return PlayerPrefs.GetString("Player_Name");
    }
}
