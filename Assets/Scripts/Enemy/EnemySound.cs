using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public AudioSource caverSoundsrc;
    public AudioClip Clip;
    // Start is called before the first frame update
    void Start()
    {
        caverSoundsrc.clip = Clip;
        caverSoundsrc.Play();
    }
}
