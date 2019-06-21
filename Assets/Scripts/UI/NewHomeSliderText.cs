using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewHomeSliderText : MonoBehaviour
{
    private Text countText;

    private void OnEnable()
    {
        countText = GetComponent<Text>();
        LevelPassed();
    }
    public void LevelPassed()
    {
        countText.text = DataScript.currentTotalStarCount.ToString() + " / " + DataScript.starsNeededToMoveNewHome.ToString();
    }
}
