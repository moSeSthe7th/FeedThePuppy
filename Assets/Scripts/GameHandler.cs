using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class GameHandler : MonoBehaviour
{
    private BoardManager boardManager;
    private UIScript uIScript;

    private void Awake()
    {
        boardManager = FindObjectOfType(typeof(BoardManager)) as BoardManager;
        uIScript = FindObjectOfType(typeof(UIScript)) as UIScript;

        DataScript.gameSpeed = 1.5f;
        DataScript.currentLevel = PlayerPrefs.GetInt("Current Level", 1);
        DataScript.maxLevel = PlayerPrefs.GetInt("Max Level", 1);
        DataScript.isGamePaused = false;
        DataScript.totalLevelCount = 10;
        DataScript.starsForAllLevels = new int[DataScript.totalLevelCount];
        DataScript.starsNeededToMoveNewHome = 40;           // bu hardcoded bunu bi şekilde değiştirebilirsin
        DataScript.currentTotalStarCount = 0;
        DataScript.isExitOccupied = false;

        Time.timeScale = DataScript.gameSpeed;

        if (DataScript.starsForAllLevels != null)
        {
            for (int i = 0; i < DataScript.starsForAllLevels.Length; i++)
            {
                DataScript.currentTotalStarCount += DataScript.starsForAllLevels[i];
            }
        }


        Time.timeScale = 1;

        boardManager.currentLevel = DataScript.currentLevel;

        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }

    }

    public void LevelPassed()
    {
       FB.LogAppEvent(AppEventName.AchievedLevel, DataScript.currentLevel);
       if (DataScript.currentLevel < DataScript.totalLevelCount)
        {
            if (DataScript.currentLevel == DataScript.maxLevel)
            {
                DataScript.maxLevel = DataScript.maxLevel + 1;
            }
            PlayerPrefs.SetInt("Max Level", DataScript.maxLevel);
            PlayerPrefs.SetInt("Current Level", DataScript.currentLevel + 1);
        }
        
        uIScript.LevelPassedUI();
    }

    public void GameOver()
    {
        uIScript.GameOverUI();
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }

}
