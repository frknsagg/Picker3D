using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LevelPrefabs m_LevelPrefabs = null;
    [SerializeField] private int currentLevel;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Material cubeMaterial;
    
    public static LevelManager instance;
    private GameObject _currentLevelObject;
    
    
    

    private void Awake()
    {
        instance = this;
        

    }

    private void Start()
    {
        

    }

    private void CreateLevel()
    {
        currentLevel= PlayerPrefs.GetInt("levelIndex");
        if (currentLevel==null)
        {
            currentLevel = 1;
        }
        
        int levelIndex = currentLevel % m_LevelPrefabs.LevelList.Count;
        _currentLevelObject = Instantiate(m_LevelPrefabs.LevelList[levelIndex]);
        
        PlayerStartPosition();


    }

    public void FinishLevel()
    {
        UI_Manager.instance.NextLevelMenuEnabled();
        SaveLevel();
    }

    public void NextLevel()
    {
        Destroy(_currentLevelObject);
        cubeMaterial.color = LevelRandomColor();
        CreateLevel();
        UI_Manager.instance._levelTextChange(currentLevel);
        
        
    }

    private void SaveLevel()
    {
        currentLevel++;
        PlayerPrefs.SetInt("levelIndex",currentLevel);
        
    }

    public void RestartLevel()
    {
        Destroy(_currentLevelObject);
        CreateLevel();
    }

    public void GameOver()
    {
        Debug.Log("Oyun Bitti");
        UI_Manager.instance.LevelFailedMenuEnable();
    }

    private void PlayerStartPosition()
    {
        playerObject.GetComponent<Transform>().position = new Vector3(0.0f, 0.758f, 14.6f);
        playerObject.GetComponent<Rigidbody>().useGravity = true;
        playerObject.GetComponent<PlayerMovement>().enabled = true;
    }

    public void StartGame()
    {
        currentLevel= PlayerPrefs.GetInt("levelIndex");
        UI_Manager.instance._levelTextChange(currentLevel);
        
        CreateLevel();
    }

    public Color LevelRandomColor()
    {
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        Color color = new Color(r, g, b, 255);
        return color;
    }
}