using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaindoorSwitchSC : MonoBehaviour
{
    public double[] switchPosX = {};
    public double[] switchPosY = {};
    // Start is called before the first frame update
    void Start()
    {
        int randomNum = Random.Range(0,switchPosX.Length);
        
        gameObject.transform.localPosition = new Vector2((float)switchPosX[randomNum],(float)switchPosY[randomNum]);
    }
}
