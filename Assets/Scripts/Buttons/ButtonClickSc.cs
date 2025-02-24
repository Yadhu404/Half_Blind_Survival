using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSc : MonoBehaviour
{
    public AudioClip buttonClick;
    private AudioSource buttonAudioSRC;

    void Start(){
        buttonAudioSRC = GetComponent<AudioSource>();
    }

    public void Buttonclicksound()
    {
        buttonAudioSRC.clip = buttonClick;
        buttonAudioSRC.Play();
    }
}
