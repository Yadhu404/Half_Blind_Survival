using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caver2O_Sound : MonoBehaviour
{
    public AudioSource caverSoundsrc;
    public AudioClip Clip;
    private float sirenDelay = 0.5f;

    public bool check = true;
    private Coroutine sirenCoroutine = null;

    void Start()
    {
        caverSoundsrc.clip = Clip;
    }

    void Update()
    {
        Collider2D recPlayer = Physics2D.OverlapCircle(transform.position, 50.0f, LayerMask.GetMask("Player"));

        if (recPlayer != null && check)
        {
            check = false;  // Prevents re-triggering

            // Start coroutine only if not already running
            if (sirenCoroutine == null)
            {
                sirenDelay = 0.5f;
                sirenCoroutine = StartCoroutine(PlaySiren());
            }
        }
        else if (recPlayer == null && sirenCoroutine != null) // Player left the range
        {
            StopCoroutine(sirenCoroutine);
            sirenCoroutine = null;  // Reset reference
            check = true;  
        }
    }

    IEnumerator PlaySiren()
    {
        while (true)  // Keeps playing at intervals
        {
            yield return new WaitForSeconds(sirenDelay);
            caverSoundsrc.Play();

            sirenDelay = 8f;
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, 50.0f);
    }
}
