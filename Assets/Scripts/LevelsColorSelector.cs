﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsColorSelector : MonoBehaviour
{
    private Color boneColor;
    private Color backgroundColor;
    private Color groundColor;
    private Color backgroundPanelColor;

    string levelColorCode;

    void Start()
    {   
        levelColorCode = DataScript.levelColorCode;
        ColorCodeData(levelColorCode);
    }


    public void ColorCodeData(string colorCode)             //if change the color code of some element, also change it at level manager
    {
        switch (colorCode)
        {
            case "Red": 
                //DataScript.backgroundColor = new Color(0.8392157f, 0.5333334f, 0.5333334f);
                DataScript.skyboxPath = "ResourceMaterials/PinkSkybox";
                DataScript.boneColor = new Color(0.2813279f, 0.5471698f, 0.2938381f);
                DataScript.groundColor = new Color(0.745283f, 0.4324048f, 0.4324048f);
                DataScript.backgroundPanelImageColor = new Color(0.3990299f, 0.463845f, 0.5754717f, 0.7568628f);
                DataScript.obstaclePaths = new int[2] { 1,6 };
                

                break;
            case "Blue":
                //DataScript.backgroundColor = new Color(0.8392157f, 0.5333334f, 0.5333334f);
                DataScript.skyboxPath = "ResourceMaterials/BlueSkybox";
                DataScript.boneColor = new Color(0f, 0.6340652f, 0.6698113f);
                DataScript.groundColor = new Color(1f, 0.8626885f, 0.4575472f);
                DataScript.backgroundPanelImageColor = new Color(0.3990299f, 0.463845f, 0.5754717f, 0.7568628f);
                DataScript.obstaclePaths = new int[2] { 0, 5 };

                break;
            default:
                //DataScript.backgroundColor = new Color(0.8392157f, 0.5333334f, 0.5333334f);
                DataScript.boneColor = Color.cyan;
                DataScript.groundColor = Color.red;
                DataScript.backgroundPanelImageColor = new Color(1, 0.4009434f, 0.4009434f, 0.7568628f);
                break;
        }
    }
}

//FFEE7F esatın bulduğu güneşli yeşilli arkaplana yakışan kod
//2E793B pembeliye yakışan renk kodu 1; 00FF2A pembeli 2