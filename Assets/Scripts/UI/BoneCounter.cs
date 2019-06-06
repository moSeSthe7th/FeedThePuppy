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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBoneCounter()
    {
        boneCounterText.text = DataScript.boneCount.ToString() + " / " + DataScript.expectedBoneCount.ToString() ;
    }
}
