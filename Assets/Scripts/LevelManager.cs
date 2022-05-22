using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void RestartGame()
    {
        Debug.Log("Oyun Tekrar Başlatıldı");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        Debug.Log("Oyun Bitti");
    }
}