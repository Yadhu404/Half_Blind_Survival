using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootPointsc : MonoBehaviour
{
    public GameObject Spike;
    public GameObject Laser;
    public GameObject Enemy;
    private GameObject ghost;
    private GameObject torchLight;
    public float playerDetectDist;
    public float incrDetectDist;

    public float spawnRate = 0.5f;
    public float timer = 0;
    public bool flag = false;
    public bool isLaser;
    private bool flag1 = true;


    public String victimName;

    private GhostStaySet ghostStaySet;
    private MapTwoObjectSpawner mapTwoObjectSpawner;
    // private AudioSource ShootSound;
    // Start is called before the first frame update
    void Start()
    {
        torchLight = GameObject.Find("Player/Torch/Torch Light");
        mapTwoObjectSpawner = GameObject.Find("Map Objects Spawner/Map2").GetComponent<MapTwoObjectSpawner>();

        if(ghost == null && mapTwoObjectSpawner.mapTwo){
            ghost = GameObject.FindGameObjectWithTag("ghost");
            ghostStaySet = ghost.GetComponent<GhostStaySet>();
        }

        // ShootSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectandSpawn();
    }

    public void DetectandSpawn() {
        Collider2D playerCollider = Physics2D.OverlapCircle(Enemy.transform.position, playerDetectDist, LayerMask.GetMask("Player","Ghost"));

        //Check the presence of player within the range
        if(playerCollider != null) { //If player is within the range

            victimName = playerCollider.name;
            // Debug.Log("Victim Name = "+victimName);
            
            playerDetectDist = incrDetectDist;  //Increase the detect range.

            if(!isLaser)
            {
                if(playerCollider.name.Contains("Ghost"))
                {
                    if(!ghostStaySet.isHidden)
                    {
                        flag = true;
                        SpikeSpawn();
                    }
                }
                else
                {
                    flag = true;
                    SpikeSpawn();
                }
            }
        }
        else{              //If player is not within the range
            flag = false;
            playerDetectDist = incrDetectDist - 2;  //Detect distance back to default range
        }

        //Checks the presence of torch light
        float tempDetectDist = playerDetectDist;
        if(!torchLight.activeSelf){      //If torch is OFF
            playerDetectDist = 2f;       //Decrease the detect distance to 2
        }
        else{
            playerDetectDist = tempDetectDist;
        }

    }

    void SpikeSpawn(){   //Spawn the spikes based on the time
        if(timer < spawnRate) {
            timer += Time.deltaTime;
        }
        else {
            GameObject spikeInstance = Instantiate(Spike, transform.position, transform.rotation);
            spikeInstance.GetComponent<SpikeScript>().SetShootPoint(this);
            timer = 0f;
        }
    }

    void spawnLaser()
    {
        if(flag1)
        {
            flag1 = false;
            
        }
        Instantiate(Laser, transform.position, transform.rotation);
    }
}
