using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchScript : MonoBehaviour
{
    bool torchOff = false;
    public float torchLife = 100;

    public Slider torchLifeBar;
    public Image lifeBarColor;

    private float timer = 0f;
    public float chargeLowTime = 20f;
    public float chargeLowAmout = 5f;

    public GameObject torchLight;
    public GameObject playerLight;


    public static TorchScript torchScript;
    void Awake()
    {
        torchScript = this;
    }

    // Update is called once per frame
    void Update()
    {   
        ChargeReduction();
        LifeBarColorSet();
        ToggleTorch();
    }


    void ToggleTorch()
    {
        if (Input.GetKeyDown("o")){
            torchOff = !torchOff;

            if(torchOff){
                torchLight.SetActive(false);
                playerLight.SetActive(false);
            }
            else{
                torchLight.SetActive(true);
                playerLight.SetActive(true);
            }
        }
    }

    void ChargeReduction()
    {
        if(timer >= chargeLowTime)
        {
            torchLife -= chargeLowAmout; 
            torchLifeBar.value = torchLife;
            
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }

        if(torchLife <= 0)
        {
            torchLight.SetActive(false);
        }
    }

    public void AddCharge()
    {
        torchLife += 50f;
        if(torchLife > 100)
        {
            torchLife = 100f;
            torchLifeBar.value = torchLife;
        }
    }

    void LifeBarColorSet()
    {
        if(torchLife >= 80f && torchLife <= 100f)
        {
            lifeBarColor.color = Color.green;
        }
        else if(torchLife >= 20f && torchLife <= 79f)
        {
            lifeBarColor.color = Color.yellow;
        }
        else if(torchLife >= 0f && torchLife <= 19f)
        {
            lifeBarColor.color = Color.red;
        }
    }
}
