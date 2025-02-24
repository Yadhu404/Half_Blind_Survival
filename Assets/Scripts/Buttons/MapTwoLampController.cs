using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MapTwoLampController : MonoBehaviour
{
    public float playerDetectDistance = 0.2f;
    public GameObject Switch;
    private bool switchState = false;


    public Light2D[] MapTwoLamp = {};

    public float[] c_2OX = {};
    public float[] c_2OY = {};
    private MapTwoObjectSpawner mapTwoObjectSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        mapTwoObjectSpawner = GameObject.Find("Map Objects Spawner/Map2").GetComponent<MapTwoObjectSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!switchState)
        {
            //Checks the player
            Collider2D recPlayer = Physics2D.OverlapCircle(Switch.transform.position,playerDetectDistance,LayerMask.GetMask("Player"));

            if(recPlayer != null)
            {
                if(Input.GetKeyDown("e"))
                {
                    switchState = !switchState; //Toggle the State of the switch
                }
            }

            if(switchState)
            {
                AcvtivateLamp();

                if(mapTwoObjectSpawner.caver2O.Count > 0)
                {
                    SetCaverOnMap();
                }
            }
        }
    }

    void AcvtivateLamp()
    {
        Debug.Log("Lights On");
        for(int i = 0;i < MapTwoLamp.Length;i++)
        {
            MapTwoLamp[i].intensity = 4; //Puts on all the lamps
        }
    }

    void SetCaverOnMap()
    {
        for(int i = 0; i < c_2OX.Length;i++)
        {
            mapTwoObjectSpawner.caver2O[i].transform.position = new Vector2(c_2OX[i],c_2OY[i]);
        }
    }
}
