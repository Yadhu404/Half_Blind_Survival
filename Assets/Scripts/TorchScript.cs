using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{
    bool torchOff = false;

    public GameObject torchLight;
    public GameObject playerLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o")){
            torchOff = !torchOff;

            if(torchOff){
                Debug.Log("Torch OFF");
                torchLight.SetActive(false);
                playerLight.SetActive(false);
            }
            else{
                Debug.Log("Torch ON");
                torchLight.SetActive(true);
                playerLight.SetActive(true);
            }
        }
    }
}
