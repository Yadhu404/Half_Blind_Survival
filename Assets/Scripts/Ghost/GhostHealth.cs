using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHealth : MonoBehaviour
{
    public float health = 55f;

    private GhostRespawn ghostRespawn;
    // Start is called before the first frame update
    void Start()
    {
        ghostRespawn = GetComponent<GhostRespawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.CompareTag("Spike"))
            {
                health -= 1;

                if(health <= 0)
                {
                    ghostRespawn.Respawn();
                    health = 55f;
                }
            } 
    }
}
