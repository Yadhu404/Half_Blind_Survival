using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWonScript : MonoBehaviour
{
    public GameObject PlayerWonPanel;
    public bool playerwon = false;

    public bool isPlayerWithDiamond = false;
    public static PlayerWonScript instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        PlayerWonPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D detectplayerwithdiamond = Physics2D.OverlapBox(transform.position,transform.localScale,0f,LayerMask.GetMask("Player"));

        if(detectplayerwithdiamond != null && isPlayerWithDiamond &&  playerwon)
        {
            PlayerWonPanel.SetActive(true);
        }
    }
}
