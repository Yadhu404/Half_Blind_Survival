using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovePlayer : MonoBehaviour
{
    public GameObject Player;
    public float waterSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D playerinWater = Physics2D.OverlapCircle(Player.transform.position,0.5f,LayerMask.GetMask("Water"));

        if(playerinWater != null)
        {
            Player.transform.position += (Vector3.down * waterSpeed) * Time.deltaTime;
        }
    }
}
