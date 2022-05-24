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
        RandomCollectablePosition(10);
    }

    
  
    public void RandomCollectablePosition(int count)
    {

        for (int i = 0; i < count; i++)
        {
            float x = Random.Range(2.15f, -2.15f);
            float z = Random.Range(20.0f, 25.0f);
            //38-50
            //66-85
            Instantiate(collectableObjects[0], new Vector3(x, 0.5f, z), Quaternion.identity);
        }
        
        
    }

    private int BallCount(int levelIndex)
    {
        if (levelIndex<9)
        {
            return 5;
        }

        return (levelIndex / 10) * 10;
    }
}


