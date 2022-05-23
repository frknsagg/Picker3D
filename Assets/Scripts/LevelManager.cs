using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LevelPrefabs m_LevelPrefabs = null;
    [SerializeField] private int _currentLevel=2;
    public static LevelManager instance;
    private GameObject _currentLevelObject;

    private void Awake()
    {
        instance = this;
        

    }

    private void Start()
    {
        _currentLevel= PlayerPrefs.GetInt("levelIndex");
        CreateLevel();

    }

    private void CreateLevel()
    {
        if (_currentLevel==null)
        {
            _currentLevel = 1;
        }
        int levelIndex = _currentLevel % m_LevelPrefabs.LevelList.Count;
        Debug.Log(PlayerPrefs.GetInt("levelindex = "+levelIndex));
        _currentLevelObject = Instantiate(m_LevelPrefabs.LevelList[levelIndex]);
    }

    public void FinishLevel()
    {
        Debug.Log("finish çalıştı");
        SaveLevel();
    }

    private void SaveLevel()
    {
        _currentLevel++;
        PlayerPrefs.SetInt("levelIndex",_currentLevel);
        Debug.Log(_currentLevel);
        Debug.Log(PlayerPrefs.GetInt("levelIndex"));
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