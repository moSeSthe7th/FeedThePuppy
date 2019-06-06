using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameHandler : MonoBehaviour
{
    private BoardManager boardManager;
    private UIScript uIScript;

    private void Awake()
    {
        boardManager = FindObjectOfType(typeof(BoardManager)) as BoardManager;
        uIScript = FindObjectOfType(typeof(UIScript)) as UIScript;

        
        DataScript.currentLevel = PlayerPrefs.GetInt("Current Level", 1);
        DataScript.maxLevel = PlayerPrefs.GetInt("Max Level", 1);
        DataScript.isGamePaused = false;
        DataScript.totalLevelCount = 6;

        Time.timeScale = 1;

        boardManager.currentLevel = DataScript.currentLevel;
        
    }

    public void LevelPassed()
    {
       if(DataScript.currentLevel < DataScript.totalLevelCount)
        {
            DataScript.currentLevel = DataScript.currentLevel + 1;

            if (DataScript.currentLevel > DataScript.maxLevel)
            {
                DataScript.maxLevel = DataScript.currentLevel;
            }

            PlayerPrefs.SetInt("Current Level", DataScript.currentLevel);
            PlayerPrefs.SetInt("Max Level", DataScript.maxLevel);

        }

        uIScript.LevelPassedUI();
    }

    public void GameOver()
    {
        uIScript.GameOverUI();
    }
    
}
