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

    public static playerMove instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PlayerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 moveDirection = Vector3.zero;   
    isMoving = false;

    // Player Movement Logic
    if (Input.GetKey(KeyCode.UpArrow))
    {
        moveDirection += Vector3.up;
        isMoving = true;
        Umove = true;
    }
    else Umove = false;

    if (Input.GetKey(KeyCode.DownArrow))
    {
        moveDirection += Vector3.down;
        isMoving = true;
        Dmove = true;
    }
    else Dmove = false;

    if (Input.GetKey(KeyCode.LeftArrow))
    {
        moveDirection += Vector3.left;
        isMoving = true;
        Lmove = true;
    }
    else Lmove = false;

    if (Input.GetKey(KeyCode.RightArrow))
    {
        moveDirection += Vector3.right;
        isMoving = true;
        Rmove = true;
    }
    else Rmove = false;

    transform.position += (moveDirection.normalized * playerSpeed) * Time.deltaTime;

    // Increase speed when running
    playerSpeed = (isMoving && Input.GetKey(KeyCode.LeftShift)) ? runSpeed : walkSpeed;

    // **Fixed Animation Logic**
    PlayerAnim.SetBool("isWalking", isMoving); // Use `SetBool` instead of `SetTrigger`
    
    Direction(); // Decide direction

    if (!isMoving)
    {
        Lmove = Rmove = Umove = Dmove = false;
    }

    if (PlayerHealth <= 0 && !isDead)
    {
        gameObject.SetActive(false);
        isDead = true;
    }
       
    }

    void OnCollisionEnter2D(Collision2D player){
        if(player.gameObject.CompareTag("Spike")){  //Decrease the health by 1
            PlayerHealth -= 1;
            SavePlayerHealth(PlayerHealth);
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


    public void PlayerHealthInc()
    {
        playerHitMedkit = true;

            int RegainHealth = PlayerHealth + 50;

            if(RegainHealth >= 100){
                PlayerHealth = 100;
                SavePlayerHealth(PlayerHealth);
            }
            else{
                PlayerHealth = RegainHealth;
                SavePlayerHealth(PlayerHealth);
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


    public void SavePlayerHealth(int health)
    {
        PlayerPrefs.SetInt("PlayerHealth",health);
        PlayerPrefs.Save();
    }

    public int GetPlayerHealth()
    {
        return PlayerPrefs.GetInt("PlayerHealth",100);
    }
}
