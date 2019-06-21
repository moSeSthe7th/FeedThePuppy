using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    
    public void NextLevelButtonPressed()
    {
        if (DataScript.currentLevel < DataScript.totalLevelCount)
        {
            DataScript.currentLevel = DataScript.currentLevel + 1;
            
        }

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
