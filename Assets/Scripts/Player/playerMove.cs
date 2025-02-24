using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float playerSpeed;
    public float walkSpeed;
    public float runSpeed;
    public int PlayerHealth = 100;
    public Camera cam;
    public GameObject medKit;
    private Animator PlayerAnim;
    public bool isMoving;
    private bool Umove = false;
    private bool Lmove = false;
    private bool Rmove = false;
    private bool Dmove = false;

    public bool playerHitMedkit = false;
    public bool isDead  = false;

    public String whichMap = "";
    private float[] playerPos = {};
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;   
        
        isMoving = false;
        //Player to move front and back.

        if(Input.GetKey(KeyCode.UpArrow)){
            moveDirection += Vector3.up;
            isMoving = true;
            Umove = true;
        }
        else{
            Umove = false;
        }

        if(Input.GetKey(KeyCode.DownArrow)){
            moveDirection += Vector3.down;
            isMoving = true;
            Dmove = true;
        }
        else{
            Dmove = false;
        }
    
        //Player to move left and right

        if(Input.GetKey(KeyCode.LeftArrow)){
            moveDirection += Vector3.left;
            isMoving = true;
            Lmove = true;
        }
        else{
            Lmove = false;
        }

        if(Input.GetKey(KeyCode.RightArrow)){
            moveDirection += Vector3.right;
            isMoving = true;
            Rmove = true;
        }
        else{
            Rmove = false;
        }

        transform.position += (moveDirection.normalized * playerSpeed) * Time.deltaTime;


        //Increase the speed of the player by holding the shift key along with the key
        if(isMoving && (Input.GetKey("left shift"))){
            playerSpeed = runSpeed;
        }
        else{
            playerSpeed = walkSpeed;
        }

        if(isMoving){
            PlayerAnim.SetTrigger("PlayerWalk");
        }
        else{
            PlayerAnim.ResetTrigger("PlayerWalk");
            PlayerAnim.SetTrigger("PlayerIdle");
        }

        Direction(); //Decides the direction

        if(!isMoving)
        {
            Lmove = Rmove = Umove = Dmove = false;
        }

        // Debug.Log("Player position --> "+transform.position);
        // Debug.Log("Player Health : "+PlayerHealth);

        if(PlayerHealth <= 0 && !isDead){
            gameObject.SetActive(false);

            isDead = !isDead;
            // Debug.Log("Player Dead");
        }
       
    }

    void OnCollisionEnter2D(Collision2D player){
        if(player.gameObject.CompareTag("Spike")){  //Decrease the health by 1
            PlayerHealth -= 1;
        }


        if(player.gameObject.CompareTag("Medkit")){  //Regain health with medkit.
            playerHitMedkit = true;

            int RegainHealth = PlayerHealth + (PlayerHealth * 50 / 100);

            if(RegainHealth >= 100){
                PlayerHealth = 100;
            }
            else{
                PlayerHealth = RegainHealth;
            }
        }

        if(player.gameObject.CompareTag("weapon")){  //Taking the weapon.

        }
    }


    void Direction()
    {
        if(Umove){
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        if(Dmove){
            transform.rotation = Quaternion.Euler(0,0,180);
        }
        if(Rmove){
            transform.rotation = Quaternion.Euler(0,0,-90);
        }
        if(Lmove){
            transform.rotation = Quaternion.Euler(0,0,90);
        }

        if(Umove && Rmove){
            transform.rotation = Quaternion.Euler(0,0,315);
        }
        if(Umove && Lmove){
            transform.rotation = Quaternion.Euler(0,0,-315);
        }
        if(Dmove && Rmove){
            transform.rotation = Quaternion.Euler(0,0,-135);
        }
        if(Dmove && Lmove){
            transform.rotation = Quaternion.Euler(0,0,135);
        }
    }

    public void SavePlayerPosition(float X, float Y)
    {
        PlayerPrefs.SetFloat("Player_Pos_X",X);
        PlayerPrefs.SetFloat("Player_Pos_Y",Y);
        PlayerPrefs.Save();
    }

    public Vector2 GetPlayerPosition()
    {
        Vector2 pos = new Vector2(
            PlayerPrefs.GetFloat("Player_Pos_X",transform.position.x),
            PlayerPrefs.GetFloat("Player_Pos_Y",transform.position.y)
        );

        return pos;
    }

    public void SavePlayerMapState()
    {
        PlayerPrefs.SetString("Map_State",whichMap);
        PlayerPrefs.Save();
    }

    public String GetPlayerMapState()
    {
        return PlayerPrefs.GetString("Map_State");
    }
}
