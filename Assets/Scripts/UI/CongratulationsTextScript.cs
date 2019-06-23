using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CongratulationsTextScript : MonoBehaviour
{
    private Text congratulateText;

    // Start is called before the first frame update
    void Start()
    {
        congratulateText = GetComponent<Text>();
    }
    
    public void Congratulate(int starCount)
    {
        if(starCount >= 3)
        {
            congratulateText.text = "PERFECT!!!";
        }
        else if (starCount == 2)
        {
            congratulateText.text = "AMAZING!!";
        }
        else
        {
            congratulateText.text = "GOOD!";
        }
    }
}
