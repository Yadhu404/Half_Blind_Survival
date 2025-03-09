using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;

public class EnemyasChild : MonoBehaviour
{
    private GameObject enemyParent;
    void Start()
    {
        enemyParent = GameObject.Find("EnemyObj");

        gameObject.transform.SetParent(enemyParent.transform);
    }
}