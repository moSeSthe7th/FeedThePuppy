using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject levelPassedPanel;
    public GameObject levelsPanel;

    public Button pauseButton;
    public Button exitButton;


    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        levelPassedPanel.SetActive(false);
        exitButton.gameObject.SetActive(false);
        levelsPanel.SetActive(false);
    }
    
    public void GameOverUI()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        DataScript.isGamePaused = true;
        pauseButton.gameObject.SetActive(false);
    }

    public void LevelPassedUI()
    {
        Time.timeScale = 0;
        levelPassedPanel.SetActive(true);
        DataScript.isGamePaused = true;
        pauseButton.gameObject.SetActive(false);
    }

    public void PausedUI()
    {
        Time.timeScale = 0;

        pausePanel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(true);

        DataScript.isGamePaused = true;
    }

    public void ExitButtonUI()
    {
        Time.timeScale = 1;

        pausePanel.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(false);
        levelsPanel.SetActive(false);

        DataScript.isGamePaused = false;
    }

    public void LevelPanelOpenerUI()
    {
        levelsPanel.SetActive(true);
        pausePanel.SetActive(false);
    }
}
