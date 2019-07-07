using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    
    public void NextLevelButtonPressed()
    {
        if (DataScript.levelNumber < DataScript.totalLevelCount)
        {
            DataScript.levelNumber = DataScript.levelNumber + 1;
            
        }

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
