using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsManager : MonoBehaviour
{
   public static PrefsManager instance;

   public List<Transform> ballTransform;
   
   

   private void Awake()
   {
      instance = this;
      PlayerPrefs.SetInt("levelIndex",10);
   }

  public void SaveLevel(int levelIndex)
   {
      PlayerPrefs.SetInt("levelIndex",levelIndex);
   }

  public int getLevel()
  {
      return PlayerPrefs.GetInt("levelIndex");
  }

  public void SaveDiamondCount(int count)
  {
      PlayerPrefs.SetInt("diamondCount",count);
  }

  public int GetDiamondCount()
  {
      return PlayerPrefs.GetInt("diamondCount");
  }
}
