using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPortal : MonoBehaviour
{
    public GameObject[] Portal = {};
    public Vector2[] portalPos = {};
    public List<GameObject> removePortal = new List<GameObject>();

    public float portalDetectDist;

    //Audio
    public AudioSource portalAudioSrc1;
    public AudioSource portalAudioSrc2;

    public AudioSource portalMainAudSrc;
    public AudioClip portalAudClip;

    public bool isPortalSpawn = false;

    public static SpawnPortal instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        portalMainAudSrc.clip = portalAudClip;
    }

    // Update is called once per frame
    void Update()
    {
        if(removePortal.Count == 0)
        {
            portalMainAudSrc.Stop();
        } 
    }


    public void Spawn_Portal()   //Spawns the Portals when player gets the last Diamond
    {
        StartCoroutine(PlayPortalSound()); //Plays Portal Sound

        for(int i = 0;i < portalPos.Length;i++)
        {
            GameObject portal = Instantiate(Portal[i],new Vector2(portalPos[i].x,portalPos[i].y),Quaternion.identity);
            
            //Fetching the Audio Source of Portal 1
            if(i == 0)
            {
                portalAudioSrc1 = portal.GetComponent<AudioSource>();
            }
            //Fetching the Audio Source of Portal 2
            if(i == 1)
            {
                portalAudioSrc2 = portal.GetComponent<AudioSource>();
            }
            isPortalSpawn = true;
            
            removePortal.Add(portal);

            portal.transform.SetParent(gameObject.transform);
        }
    }


    IEnumerator PlayPortalSound() //Plays Portal Sound in 1s.
    {
        yield return new WaitForSeconds(1f);
        portalMainAudSrc.Play();
    }
}
