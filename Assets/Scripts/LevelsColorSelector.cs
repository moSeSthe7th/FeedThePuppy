using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsColorSelector : MonoBehaviour
{
    private Color boneColor;
    private Color backgroundColor;
    private Color groundColor;
    private Color backgroundPanelColor;
    
    void Start()
    {
        string levelColorCode = DataScript.levelColorCode;
        ColorCodeData(levelColorCode);
    }

    
    public void ColorCodeData(string colorCode)
    {
        switch (colorCode)
        {
            case "Red":
                DataScript.backgroundColor = new Color(0.8392157f, 0.5333334f, 0.5333334f);
                DataScript.boneColor = Color.cyan;
                DataScript.groundColor = Color.red;
                DataScript.backgroundPanelImageColor = new Color(1, 0.4009434f, 0.4009434f, 0.7568628f);

                break;
            default:
                DataScript.backgroundColor = new Color(0.8392157f, 0.5333334f, 0.5333334f);
                DataScript.boneColor = Color.cyan;
                DataScript.groundColor = Color.red;
                DataScript.backgroundPanelImageColor = new Color(1, 0.4009434f, 0.4009434f, 0.7568628f);
                break;
        }
    }
}
