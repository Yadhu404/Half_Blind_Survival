using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPortal : MonoBehaviour
{
    public GameObject[] Portal = {};
    public Vector2[] portalPos = {};
    public List<GameObject> removePortal = new List<GameObject>();
    public GameObject diamondHolder;
    public GameObject redDiamond;

    public float portalDetectDist;

    public bool singleCheck = true;

    //Audio
    public AudioSource portalAudioSrc1;
    public AudioSource portalAudioSrc2;

    public AudioSource portalMainAudSrc;
    public AudioClip portalAudClip;

    public bool isPortalSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        portalMainAudSrc.clip = portalAudClip;
    }

    // Update is called once per frame
    void Update()
    {
        Transform DiamondasChild = diamondHolder.transform.Find(redDiamond.name);

        if(singleCheck)
        {
            if(DiamondasChild !=  null)
            {
                Spawn_Portal();
                singleCheck = !singleCheck;
            }
        }

        if(removePortal.Count == 0)
        {
            portalMainAudSrc.Stop();
        } 
    }


    void Spawn_Portal()   //Spawns the Portals when player gets the last Diamond
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Portal[0].transform.position, portalDetectDist);
    }
}
