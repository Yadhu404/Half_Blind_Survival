using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadScript : MonoBehaviour
{
    public GameObject playerdead;
    public GameObject player;
    // public AudioClip PlayerDeadSound;
    private AudioSource audiosource;
    private bool oncePlayed = false;

    public GameObject portalObject;
    private PortalScript portalScript;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();

        portalScript = portalObject.GetComponent<PortalScript>();

        playerdead.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.activeSelf && !oncePlayed && !portalScript.inPortal){

            if(!audiosource.isPlaying)
            {
                audiosource.Play();
            }

            // Time.timeScale = 0f;
            playerdead.SetActive(true);

            oncePlayed = true;
        }
    }
}
