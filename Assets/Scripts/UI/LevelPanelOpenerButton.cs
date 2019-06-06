using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPanelOpenerButton : MonoBehaviour
{
    private UIScript uIScript;

    private void Start()
    {
        uIScript = FindObjectOfType(typeof(UIScript)) as UIScript;
    }

    public void LevelPanelOpenerButtonPressed()
    {
        uIScript.LevelPanelOpenerUI();
    }
}
