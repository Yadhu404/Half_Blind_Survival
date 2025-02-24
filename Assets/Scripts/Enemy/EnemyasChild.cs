using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;

public class EnemyasChild : MonoBehaviour
{
    //Parent Objects
    // public GameObject enemyParent_1; //Map_1
    private GameObject enemyParent;
    void Start()
    {
        // enemyParent_1 = GameObject.Find("EnemyObj/Map_1");

        enemyParent = GameObject.Find("EnemyObj");

        gameObject.transform.SetParent(enemyParent.transform);
    }
}