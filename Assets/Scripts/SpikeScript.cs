using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    private ShootPointsc ShootPoint;
    public GameObject player;
    private GameObject ghost;
    public Vector3 PlayerRecentPos;
    public AudioSource shootSound;
    public float moveSpeed = 15f;
    public float  timer = 0f;

    private GameObject Victim;
    private Vector3 direction;

    public void SetShootPoint(ShootPointsc shootPoint)
    {
        this.ShootPoint = shootPoint;
    }
    // Start is called before the first frame update
    void Start()
    {
        shootSound = GetComponent<AudioSource>();
        
        if(player == null || ghost == null){
            player = GameObject.FindGameObjectWithTag("Player");
            ghost = GameObject.FindGameObjectWithTag("ghost");
        }
        if(player == null){
            Debug.Log("Player not found!!!");
        }
        else{
            PlayerRecentPos = player.transform.position;
        }

        Destroy(gameObject,0.5f);
        // Debug.Log("Spike Destroyed!!!");
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Walls") || other.gameObject.CompareTag("ghost")){
            // Debug.Log("Object Name = "+other.gameObject.name);
            
            Destroy(gameObject);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        shootSound.Play();
        // transform.position = Vector3.MoveTowards(transform.position, PlayerRecentPos,moveSpeed * Time.deltaTime);
        // Debug.Log("TARGET NAME = "+ShootPoint.victimName);
        if(ShootPoint.victimName == "Player")
        {
            Victim = player;
        }
        else  if(ShootPoint.victimName.Contains("Ghost"))
        {
            Victim = ghost;
        }
        
        if (Victim != null)
        {
            direction = Victim.transform.position - transform.position;
            transform.position += (direction * moveSpeed) * Time.deltaTime;
        }
    }
}



        // Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, 0f);
        // spike.position = Vector3.MoveTowards(spike.position, targetPosition  , moveSpeed * Time.deltaTime);

        // Debug.Log("Players Position --> "+targetPosition+" Spike Position --> "+spike.position);

        // spike.position += (Vector3.right * 5) * Time.deltaTime;
