using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeOutSoundManager : MonoBehaviour
{
    [SerializeField] public AudioSource MazeOutSound;
    [SerializeField] public AudioClip[] MazeOutClip = {};
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    
        MazeOutSound.PlayOneShot(MazeOutClip[index]);

        StartCoroutine(WaitforMusic());
    }
    IEnumerator WaitforMusic()
    {
        yield return new WaitWhile(()=> MazeOutSound.isPlaying);

        index = 1;
        MazeOutSound.loop = true;
        MazeOutSound.clip = MazeOutClip[index];
        MazeOutSound.Play();
    }
}
