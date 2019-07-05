using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingTextScript : MonoBehaviour
{
    private Text startingText;
    
    void Start()
    {
        startingText = GetComponent<Text>();
        //startingText.color = DataScript.boneColor;
    }
    
    public void CloseStartingText()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
