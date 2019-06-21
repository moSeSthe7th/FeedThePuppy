using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorBonesParent : MonoBehaviour
{
    private Image[] images;
   
    private int levelToRate;
    private int starCount;
    public Button button;
    private Text levelToRateText;

    private string levelToRateStr;

    // Start is called before the first frame update
    void Awake()
    {
        images = GetComponentsInChildren<Image>();

        for (int i = 0; i < images.Length; i++)
        {
            //images[i].color = DataScript.boneColor;
            images[i].gameObject.SetActive(false);
        }
        
    }

  /*  private void OnEnable()
    {
        levelToRateText = button.GetComponentInChildren<Text>();
        levelToRateStr = levelToRateText.text;
        int.TryParse(levelToRateText.text, out levelToRate);
        Debug.Log("Level to rate string: " + levelToRateStr);
        Debug.Log("Level to rate: " + levelToRate);
        Debug.Log("Stars for all levels length: " + DataScript.starsForAllLevels.Length);
        starCount = DataScript.starsForAllLevels[levelToRate ];

        for(int j = 0; j < starCount; j++)
        {
            images[j].gameObject.SetActive(true);
        }
    }*/

    public void createLevelStars(int starCount)
    {
        for (int i = 0; i < starCount; i++)
        {
            images[i].gameObject.SetActive(true);
        }
    }
}
