using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeInSoundManager : MonoBehaviour
{
    [SerializeField] public AudioSource[] MazeInSound = {};
    [SerializeField] public AudioClip[] MazeInClip = {};
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayMazeSound());
    }

    // Update is called once per frame

    IEnumerator PlayMazeSound()
    {
        while(true)
        {
            float waitTime = Random.Range(10f,20f);

            yield return new WaitForSeconds(waitTime);

            SelectAudioSrcandAudioClip();
        }
    }

    void SelectAudioSrcandAudioClip()
    {
        int audSrc = Random.Range(0,MazeInSound.Length);
        int audClip = Random.Range(0,MazeInClip.Length);
        MazeInSound[audSrc].PlayOneShot(MazeInClip[audClip]);
    }

    void FootStepController(int audSrc, int audClip)
    {
        float waitTimeforLoop = Random.Range(2,5);

        MazeInSound[audSrc].loop = true;


    }
}
