using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorGameObject : MonoBehaviour
{

    LevelSelectorBonesParent levelSelectorBonesParent;
   // private Button levelSelectorButton;
    private Text levelSelectorButtonText;

    private int levelAtButton;

    void Start()
    {
        levelSelectorBonesParent = GetComponentInChildren < LevelSelectorBonesParent>();
        //levelSelectorButton = GetComponentInChildren<Button>();
        levelSelectorButtonText = GetComponentInChildren<Text>() ;        
        int.TryParse(levelSelectorButtonText.text, out levelAtButton);
        if(levelAtButton <= DataScript.maxLevel)
        {
            //Debug.Log("starsforalllevelslength" + DataScript.starsForAllLevels.Length);
            //Debug.Log("levelatbutton" + DataScript.starsForAllLevels.Length);
            levelSelectorBonesParent.createLevelStars(DataScript.starsForAllLevels[levelAtButton - 1]);
        }
        
    }


    
}
