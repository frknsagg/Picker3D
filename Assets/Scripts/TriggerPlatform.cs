using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TriggerPlatform : MonoBehaviour
{
    private GameObject _parentObject;
    private GameObject KarakterGameObject;

    private Material _currentColor;
    [SerializeField] private Material _cubeColor;
    [SerializeField] private int topSayisi = 0;
    
    private TextMeshProUGUI MinimumText;
    private TextMeshProUGUI MaximumText;

    
    
    private Sequence _sequence;
    
    private void Start()
    {
        DOTween.Init();
        _sequence = DOTween.Sequence();
        
        _parentObject = transform.parent.gameObject;
        _currentColor = _parentObject.GetComponent<MeshRenderer>().material;
        
        MinimumText = _parentObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        MaximumText = _parentObject.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        
        MaximumText.text = "/ " + LevelSettings.instance.MaxBallCount;
        KarakterGameObject = GameObject.Find("Player");
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
            MinimumText.text = "" + topSayisi;
            StartCoroutine(DestroyCollectable(other.gameObject));
        }
    }

    private IEnumerator PlatformAnim()
    {
        yield return new WaitForSeconds(2f);

        if (topSayisi >= LevelSettings.instance.MaxBallCount)
        {
          

            _sequence.Append(_parentObject.transform.DOMoveY(0, 0.5f));
            _sequence.Join(_currentColor.DOColor(_cubeColor.color, 0.5f));
           
           
            gameObject.tag = "Untagged";
            KarakterGameObject.GetComponent<PlayerMovement>().enabled = true;
            MinimumText.enabled = false;
            MaximumText.enabled = false;


        }
        else
        {
            LevelManager.instance.GameOver();
        }
    }

    private IEnumerator DestroyCollectable(GameObject other)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(other.gameObject);
        
    }
}