using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private List<GameObject> _collectedObjects;

    void Start()
    {
    }


    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            gameObject.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}