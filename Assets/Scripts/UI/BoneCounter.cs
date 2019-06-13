using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoneCounter : MonoBehaviour
{
    private LevelManager levelManager;

    private Text boneCounterText;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType(typeof(LevelManager)) as LevelManager;
        boneCounterText = GetComponent<Text>();
        SetBoneCounter();
    }

    
    public void SetBoneCounter()
    {
       
    }

    private void Update()
    {
        boneCounterText.text = DataScript.boneCount.ToString() + " / " + DataScript.expectedBoneCount.ToString();
    }
}
