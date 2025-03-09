using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScreamSound : MonoBehaviour
{
    public AudioClip ghostSound;
    public AudioSource audioSource;

    //Bool
    public bool canMove = false;

    public IEnumerator  CallScreamFn()
    {
        yield return new WaitForSeconds(1);

        canMove = true;
    }

    public void MakeSound()
    {
        audioSource.clip = ghostSound;
        audioSource.Play();
    }
}
