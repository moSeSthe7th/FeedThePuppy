using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsPanelScript : MonoBehaviour
{

    public GameObject levelButtonObj;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= DataScript.totalLevelCount; i++)
        {
            GameObject obj = Instantiate(levelButtonObj);
            obj.gameObject.GetComponentInChildren<Text>().text = i.ToString();
            obj.transform.SetParent(transform);
            if(i > DataScript.maxLevel)
            {
                obj.gameObject.GetComponent<Button>().interactable = false;
            }
        }
    }

    
}
