using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LevelPrefabs m_LevelPrefabs = null;
    [SerializeField] private int _currentLevel;
    public static LevelManager instance;
    private GameObject _currentLevelObject;

    private void Awake()
    {
        instance = this;
        

    }

    private void Start()
    {
        _currentLevel= PlayerPrefs.GetInt("levelIndex");
        UI_Manager.instance._levelTextChange(_currentLevel);
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
        UI_Manager.instance.NextLevelMenuEnabled();
        SaveLevel();
    }

    private void SaveLevel()
    {
        _currentLevel++;
        PlayerPrefs.SetInt("levelIndex",_currentLevel);
        
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