using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTwoInSound : MonoBehaviour
{
    [SerializeField] public AudioSource[] MazeInSound = {};
    [SerializeField] public AudioClip[] MazeInClip = {};

    private playerMove playerMove;
    private bool isPlayerInMapTwo = false;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<playerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMove.GetPlayerMapState() == "Map_Two" && !isPlayerInMapTwo)
        {
            isPlayerInMapTwo = !isPlayerInMapTwo;
            if(isPlayerInMapTwo)
            {
                StartCoroutine(PlayMazeSound());
            }
        }
    }

    IEnumerator PlayMazeSound()
    {
        while(true)
        {
            float waitTime = Random.Range(15f,20f);

            yield return new WaitForSeconds(waitTime);

            SelectAudioSrcandAudioClip();
        }
    }

    void SelectAudioSrcandAudioClip()
    {
        int audSrc = Random.Range(0,MazeInSound.Length);
        int audClip = Random.Range(0,MazeInClip.Length);

        MazeInSound[audSrc].PlayOneShot(MazeInClip[audClip]);
        // Debug.Log(MazeInSound[audSrc]+" is playing "+MazeInClip[audClip]+" clip...");
    }
}
