using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GhostManipulatorScript : MonoBehaviour
{
    public Light2D blinkLight;

    private float timer = 0f;
    public float blinkDelay = 1.5f;

    private bool toggle = true;

    public bool isActivated = false;

    private GameObject Player;



    public static GhostManipulatorScript ghostManipulatorScript;

    void Awake()
    {
        ghostManipulatorScript = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        blinkLight.intensity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Blink the light with a delay
        if(timer >= blinkDelay)
        {
            blinkLight.intensity = toggle? 1f : 0f;
            toggle = !toggle;
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }

        //Change the color on activating
        if(isActivated)
        {
            blinkLight.color = Color.green;
        }
        else
        {
            blinkLight.color = Color.red;
        }
    }
}
