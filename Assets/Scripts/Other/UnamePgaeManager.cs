using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnamePgaeManager : MonoBehaviour
{
    public GameObject UnamePage;
    public GameObject HomePage;


    private PlayerNameSet playerNameSet;
    // Start is called before the first frame update
    void Start()
    {
        playerNameSet = GetComponent<PlayerNameSet>();

        if(playerNameSet.GetPlayerName() == "")
        {
            UnamePage.SetActive(true);
        }
        else
        {
            HomePage.SetActive(true);
        }
    }

    public void NameSet()
    {
        UnamePage.SetActive(false);
        HomePage.SetActive(true);
    }

    public void SetNewName()
    {
        UnamePage.SetActive(true);
        HomePage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
