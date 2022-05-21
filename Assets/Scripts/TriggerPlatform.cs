using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  DG.Tweening;
using TMPro;

public class TriggerPlatform : MonoBehaviour
{
    private GameObject _parentObject;
    public Pushing push;
    private Material _currentColor;
    [SerializeField] private int topSayisi = 0;
    private TextMeshProUGUI MinimumText;
    private TextMeshProUGUI MaximumText;
    public static TriggerPlatform instance;
    private int maxBallCount = 5;
    

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }


    private void Start()
    {
        
        _parentObject = transform.parent.gameObject;
        _currentColor = _parentObject.GetComponent<MeshRenderer>().material;
        MinimumText = _parentObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        MaximumText = _parentObject.transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        MaximumText.text = "" + maxBallCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PlatformAnim());
        }
        
        if (other.CompareTag("Collectable"))
        {
            topSayisi += 1;
            MinimumText.text =""  + topSayisi;
           
        }
    }

    private IEnumerator PlatformAnim()
    {
        yield return new WaitForSeconds(1.5f);

        if (topSayisi>=maxBallCount)
        {
            _parentObject.transform.DOMoveY(0, 0.5f);
            _currentColor.DOColor(Color.green, 0.5f);
        }
        else
        {
            Debug.Log("Game Over");
        }
       
        
    }
    
    
}


