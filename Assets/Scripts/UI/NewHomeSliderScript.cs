using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewHomeSliderScript : MonoBehaviour
{
    private Slider slider;

    private void OnEnable()
    {
        slider = GetComponent<Slider>();
        slider.interactable = false;
        LevelPassed();
    }

    public void LevelPassed()
    {
        DataScript.currentTotalStarCount = 0;

        if(DataScript.starsForAllLevels != null)
        {
            for (int i = 0; i < DataScript.starsForAllLevels.Length; i++)
            {
                DataScript.currentTotalStarCount += DataScript.starsForAllLevels[i];
            }
        }

        slider.value = (float)DataScript.currentTotalStarCount / (float)DataScript.starsNeededToMoveNewHome;     //does not work when float cast removed
        
    }
}
