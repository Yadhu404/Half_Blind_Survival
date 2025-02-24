using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    private SpawnPortal spawnPortal;

    public GameObject Player;

    //Boolean
    private bool check = true;
    private bool check1 = true;
    public bool inPortal = false;

    //Audio
    public AudioClip intoPortalSound; 
    public AudioClip outfromPortalSound;

    public GameObject playerWinPanel;
    private PlayerWonScript playerWonScript;
    // Start is called before the first frame update
    void Start()
    {
        spawnPortal = GetComponent<SpawnPortal>();
        playerWonScript = playerWinPanel.GetComponent<PlayerWonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnPortal.isPortalSpawn)
        {
            Collider2D playerDetect = Physics2D.OverlapCircle(  //Checks Player in Portal 1
                spawnPortal.Portal[0].transform.position,
                spawnPortal.portalDetectDist,
                LayerMask.GetMask("Player")
            );

            Collider2D playerDetect_1 = Physics2D.OverlapCircle(  //Checks Player in Portal 2
                spawnPortal.Portal[1].transform.position,
                spawnPortal.portalDetectDist,
                LayerMask.GetMask("Player")
            );

            if(playerDetect != null)  //If player in Portal 1
            {
                if(check)
                {
                    StartCoroutine(TransportPlayer());
                    check = false;
                }
            }
            else if(playerDetect_1 != null)  //If player in Portal 2
            {
                if(check1)
                {
                    StartCoroutine(PortalDisappear());
                    check1 = false;
                }
            }
        }
    }

    IEnumerator TransportPlayer()   //Transport Player to end portal within 1.5s
    {
        inPortal = true;

        spawnPortal.portalAudioSrc1.clip = intoPortalSound;
        spawnPortal.portalAudioSrc1.Play();

        Player.SetActive(false);  //Player Disappears

        yield return new WaitForSeconds(1.5f);

        Player.transform.position = spawnPortal.Portal[1].transform.position;
        Player.SetActive(true);
    }

    IEnumerator PortalDisappear()  //Remove the Portals within 2s
    {
        spawnPortal.portalAudioSrc2.clip = outfromPortalSound;
        spawnPortal.portalAudioSrc2.Play();

        yield return new WaitForSeconds(2f);

        for(int i = spawnPortal.removePortal.Count-1;i >= 0;i--)
        {
            Destroy(spawnPortal.removePortal[i]);
            spawnPortal.removePortal.RemoveAt(i);
        }

        StartCoroutine(PlayerWin());
    }

    IEnumerator PlayerWin()
    {
        yield return new WaitForSeconds(1f);

        playerWonScript.playerwon = true;
    }
}
