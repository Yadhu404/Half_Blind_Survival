using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWonScript : MonoBehaviour
{
    public GameObject PlayerWonPanel;
    public bool playerwon = false;
    private MainDoorTwo diamondwithplayer;
    // Start is called before the first frame update
    void Start()
    {
        PlayerWonPanel.SetActive(false);

        diamondwithplayer = GameObject.Find("Map2 Main Door").GetComponent<MainDoorTwo>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D detectplayerwithdiamond = Physics2D.OverlapBox(transform.position,transform.localScale,0f,LayerMask.GetMask("Player"));

        if(detectplayerwithdiamond != null && diamondwithplayer.DiamondasChild != null && playerwon)
        {
            PlayerWonPanel.SetActive(true);

           Time.timeScale = 0f;

           Debug.Log("Time Scale = "+Time.timeScale);
        }
    }
}
