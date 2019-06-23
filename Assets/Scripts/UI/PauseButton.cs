using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{

    private Button pauseButton;
    private UIScript uIScript;

    // Start is called before the first frame update
    void Start()
    {
        uIScript = FindObjectOfType(typeof(UIScript)) as UIScript;
        pauseButton = GetComponent<Button>();
    }

   
    public void PauseButtonPressed()
    {
        if (!DataScript.isGamePaused)
        {
            uIScript.PausedUI();
        }
    }
}
