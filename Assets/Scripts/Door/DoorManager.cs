using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;

    public AudioClip DoorSound;
    public AudioSource doorAudioSRC;
    // Start is called before the first frame update
    void Start()
    {
        door1.SetActive(true);
        door2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorOpen()
    {
        doorAudioSRC.clip = DoorSound;
        doorAudioSRC.Play();

        door1.SetActive(false);
        door2.SetActive(false);
    }
    public void DoorClose()
    {
        doorAudioSRC.clip = DoorSound;
        doorAudioSRC.Play();

        door1.SetActive(true);
        door2.SetActive(true);
    }
}
