using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class LevelSettings : MonoBehaviour
{
    [SerializeField] private List<GameObject> collectableObjects;
    public  static LevelSettings   instance;
   public int MaxBallCount;

   private void Awake()
   {
       instance = this;
       MaxBallCount = BallCount(PrefsManager.instance.getLevel());
   }
   void Start()
   {
       RandomCollectableInstantiate(MaxBallCount * 2);
   }

   public void RandomCollectableInstantiate(int count)
   {
       int r = Random.Range(0, collectableObjects.Count);

       for (int i = 0; i < count; i++)
       {
           float x = Random.Range(-2.15f, 2.15f);
           float z = Random.Range(18.0f, 27.0f);
           Vector3 vec = new Vector3(x, 2.80f, z);
           GameObject obje= Instantiate(collectableObjects[r], vec, Quaternion.identity);
           
       }
       for (int i = 0; i < count; i++)
       {
           float x = Random.Range(-2.15f, 2.15f);
           float z = Random.Range(36.0f, 56.0f);
           Vector3 vec = new Vector3(x, 2.80f, z);
           GameObject obje= Instantiate(collectableObjects[r], vec, Quaternion.identity);
          
       }
       for (int i = 0; i < count; i++)
       {
           float x = Random.Range(-2.15f, 2.15f);
           float z = Random.Range(66.0f, 85.0f);
           Vector3 vec = new Vector3(x, 2.80f, z);
           GameObject obje= Instantiate(collectableObjects[r], vec, Quaternion.identity);
            
       }
        
        
   }

    private int BallCount(int levelIndex)
    {
        if (levelIndex<=9)
        {
            return 5;
        }
        return (levelIndex / 10) * 10; 
       
    }
}


