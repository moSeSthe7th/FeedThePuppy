using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewHomeRemainingText : MonoBehaviour
{
    private Text remainingText;

    private void OnEnable()
    {
        remainingText = GetComponent<Text>();
        remainingText.text = "Collect " + DataScript.starsNeededToMoveNewHome.ToString() + " bones to move to a new home!";
    }
}
