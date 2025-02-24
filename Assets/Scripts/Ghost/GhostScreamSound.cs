using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScreamSound : MonoBehaviour
{
    // public AudioClip ghostScream;
    // public AudioClip ghostSound;
    public AudioSource audioSource;

    //Bool
    public bool canMove = false;

    //Scripts
    private GhostScript ghostScript;
    private GhostStaySet ghostStaySet;
    // Start is called before the first frame update
    void Start()
    {
        ghostScript = GetComponent<GhostScript>();
        ghostStaySet = GetComponent<GhostStaySet>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            GhostMakeSound();
        }

        // if(ghostStaySet.isHidden)
        // {
        //     canMove = false;
        // }

    }

    void GhostMakeSound(){}
    void Scream(){}

    public IEnumerator  CallScreamFn()
    {
        Scream();

        yield return new WaitForSeconds(1);

        canMove = true;
    }
}
