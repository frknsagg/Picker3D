using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI LevelText;
   [SerializeField] private TextMeshProUGUI diamondCount;
    
    
    [SerializeField] private GameObject nextLevelTextMenu;
    [SerializeField] private GameObject levelFailedMenu;
    [SerializeField] private GameObject startGameMenu;
    

   public static UI_Manager instance;

   private void Awake()
   {
      instance = this;
    
   }

   private void Start()
   {
      
      nextLevelTextMenu.gameObject.SetActive(false);
      levelFailedMenu.gameObject.SetActive(false);
      startGameMenu.gameObject.SetActive(true);
      diamondCount.text = "Elmas Sayisi " + PrefsManager.instance.GetDiamondCount();

   }

   public void _levelTextChange(int levelIndex)
   {
      LevelText.text = "Level " + levelIndex;
   }

   public void NextLevelMenuEnabled()
   {
      nextLevelTextMenu.gameObject.SetActive(true);
   }
   public void LevelFailedMenuEnable()
   {
      levelFailedMenu.gameObject.SetActive(true);
   }

   public  void RestartLevelButton()
   {
      LevelManager.instance.RestartLevel();
      levelFailedMenu.gameObject.SetActive(false);
   }

   public void NextLevelButton()
   {
      LevelManager.instance.NextLevel();
      nextLevelTextMenu.gameObject.SetActive(false);
   }

   public void StartGameButton()
   {
      startGameMenu.gameObject.SetActive(false);
      LevelManager.instance.StartGame();
   }

   public void DiamondTextChange()
   {
      diamondCount.text = "Elmas Sayisi " + PrefsManager.instance.GetDiamondCount();
   }
}
