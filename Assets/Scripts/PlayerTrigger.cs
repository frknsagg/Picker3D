using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private List<GameObject> _collectedObjects;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        if (other.CompareTag("Finish"))
        {
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            LevelManager.instance.FinishLevel();
           
        }
    }
}