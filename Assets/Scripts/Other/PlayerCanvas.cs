using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanvas : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation; // Store the initial rotation
    }

    void LateUpdate()
    {
        transform.rotation = initialRotation; // Lock rotation every frame
    }
}