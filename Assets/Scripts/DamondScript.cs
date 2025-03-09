using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamondScript : MonoBehaviour
{
    public GameObject DiamondHolder;
    public float playerDetectDist = 1.5f;

    public static DamondScript instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }


    public void Diamond_with_Player()
    {
        gameObject.transform.SetParent(DiamondHolder.transform);
    }
}
