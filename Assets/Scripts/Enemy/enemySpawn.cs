using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public float[] posX = {-10,80,14,84};
    public float[] posY = {40,86,87,28};
    public float timer = 0f;
    public float spawnRate = 3f;
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Spawnenemy();   //To spawn the enemy
    }


    void Spawnenemy(){        //Spawning the Enemies
        for(int i = 0;i < 4;i++){
            transform.position = new Vector3(posX[i], posY[i], -1);
            Instantiate(Enemy, transform.position, transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
