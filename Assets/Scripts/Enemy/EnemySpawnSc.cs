using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class EnemySpawnSc : MonoBehaviour
{
    public Vector2 minMapBound;
    public Vector2 maxMapBound;
    public float SpawnRadius = 1f;
    private bool spawnFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void EnemySpawn()
    {
        Vector2 spawnPosition = Vector2.zero;

        for(int i = 0;i < 100;i++)
        {
            spawnPosition = new Vector2
            (
                Random.Range(minMapBound.x,maxMapBound.x),
                Random.Range(minMapBound.y,maxMapBound.y)
            );

            if(Physics2D.OverlapCircle(transform.position,SpawnRadius,LayerMask.GetMask("walls")) != null)
            {
                spawnFlag = true;
                break;
            }    
        }

        if(spawnFlag)
        {
            Instantiate(gameObject,spawnPosition,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
