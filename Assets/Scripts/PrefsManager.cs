using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsManager : MonoBehaviour
{
   public static PrefsManager instance;

   private void Awake()
   {
      instance = this;
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
      int toplam = GetDiamondCount() + count;
      PlayerPrefs.SetInt("diamondCount",toplam);
      UI_Manager.instance.DiamondTextChange();
  }

  public int GetDiamondCount()
  {
      return PlayerPrefs.GetInt("diamondCount");
  }
}
