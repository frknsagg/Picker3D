using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pushing : MonoBehaviour
{
    private Rigidbody fizik;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
           other.gameObject.GetComponent<Rigidbody>().AddForce(0,200,200);
        }
    }

   
}
