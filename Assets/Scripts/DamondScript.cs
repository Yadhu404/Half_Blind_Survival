using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamondScript : MonoBehaviour
{
    public GameObject DiamondHolder;
    public float playerDetectDist = 1.5f;
    // public AudioClip DiamondAudio;
    private AudioSource DiamondSoundSRC;
    // private bool oncePlaySound = false;
    
    // Start is called before the first frame update
    void Start()
    {
        DiamondSoundSRC = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D detectPlayer = Physics2D.OverlapCircle(transform.position,playerDetectDist,LayerMask.GetMask("Player"));

        if(detectPlayer != null)
        {
            if(Input.GetKeyDown("e"))
            {
                gameObject.transform.SetParent(DiamondHolder.transform);
                gameObject.SetActive(false);
                //StartCoroutine(DisableGameObject());
            }
        }
    }


    IEnumerator DisableGameObject(){
        yield return new WaitForSeconds(DiamondSoundSRC.clip.length);

        gameObject.transform.SetParent(DiamondHolder.transform);
        gameObject.SetActive(false);
    }
}
