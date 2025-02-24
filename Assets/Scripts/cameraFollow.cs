using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine3 = UnityEngine.Vector3;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public UnityEngine.Vector3 offset;
    public float smoothMove = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine3 desiredPos = player.position + offset;

        UnityEngine3 smoothedPosition = UnityEngine3.Lerp(transform.position, desiredPos, smoothMove);

        transform.position = smoothedPosition;
    }
}
