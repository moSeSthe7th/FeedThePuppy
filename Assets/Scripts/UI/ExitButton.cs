using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private Button exitButton;
    private UIScript uIScript;

    // Start is called before the first frame update
    void Start()
    {
        uIScript = FindObjectOfType(typeof(UIScript)) as UIScript;
        exitButton = GetComponent<Button>();
    }

   
    public void ExitButtonPressed()
    {
        if (DataScript.isGamePaused)
        {
            uIScript.ExitButtonUI();
        }
        
    }
}
