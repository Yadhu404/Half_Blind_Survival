using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnamePgaeManager : MonoBehaviour
{
    public GameObject UnamePage;
    public GameObject HomePage;

    public GameObject enterNameMessage;
    private Animator enterNameShake;


    // Start is called before the first frame update
    void Start()
    {
        if(enterNameMessage.activeSelf)
        {
            enterNameShake = enterNameMessage.GetComponent<Animator>();
        }

        if(PlayerNameSet.instance.GetPlayerName() == "")
        {
            UnamePage.SetActive(true);
            HomePage.SetActive(false);
        }
        else
        {
            UnamePage.SetActive(false);
            HomePage.SetActive(true);
        }
    }

    public void NameSet()
    {
        if(PlayerNameSet.instance.playerName.text != "")
        {
            UnamePage.SetActive(false);
            HomePage.SetActive(true);
        }
        else
        {
            enterNameShake.SetTrigger("shake");
        }
    }

    public void SetNewName()
    {
        UnamePage.SetActive(true);
        HomePage.SetActive(false);
    }
}
