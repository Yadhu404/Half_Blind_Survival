using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRespawn : MonoBehaviour
{

    private float detectDistance = 5f;


    private MapTwoObjectSpawner mapTwoObjectSpawner;

    // Start is called before the first frame update
    void Start()
    {
        mapTwoObjectSpawner = GameObject.Find("Map Objects Spawner/Map2").GetComponent<MapTwoObjectSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D isOutSideMap = Physics2D.OverlapCircle(transform.position,detectDistance,LayerMask.GetMask("GhostRespawn"));

        if(isOutSideMap != null)
        {
            Respawn();
        }
    }


    public void Respawn()
    {
        int ind = Random.Range(0, mapTwoObjectSpawner.GhostPosX.Length);

        transform.position = new Vector2(mapTwoObjectSpawner.GhostPosX[ind], mapTwoObjectSpawner.GhostPosY[ind]);
    }
}
