using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonesParentScript : MonoBehaviour
{
    private Image[] images;
    private SavingScript savingScript;
    private CongratulationsTextScript congratulationsTextScript;

    void Awake()
    {
        images = GetComponentsInChildren<Image>();
        savingScript = FindObjectOfType(typeof(SavingScript)) as SavingScript;
        congratulationsTextScript = FindObjectOfType(typeof(CongratulationsTextScript)) as CongratulationsTextScript;
    }
    
    public void levelPassed()
    {
        
        for (int i = 0; i < images.Length; i++)
        {
            //images[i].color = DataScript.boneColor;
            images[i].gameObject.SetActive(false);
        }

        if (DataScript.score <= DataScript.expectedBoneCount)
        {
            StartCoroutine(levelEndedBones(3));
            congratulationsTextScript.Congratulate(3);

            DataScript.starsForAllLevels[DataScript.levelNumber - 1] = 3;
        }
        else if(DataScript.score <= DataScript.expectedBoneCount * 1.5f)
        {
            StartCoroutine(levelEndedBones(2));
            congratulationsTextScript.Congratulate(2);

            if (DataScript.starsForAllLevels[DataScript.levelNumber - 1] <= 2)
            {
                DataScript.starsForAllLevels[DataScript.levelNumber - 1] = 2;
            }
        }
        else
        {
            StartCoroutine(levelEndedBones(1));
            congratulationsTextScript.Congratulate(1);

            if (DataScript.starsForAllLevels[DataScript.levelNumber - 1] <= 1)
            {
                DataScript.starsForAllLevels[DataScript.levelNumber - 1] = 1;
            }
        }

        
        
        savingScript.saveStarsForAllLevels();
    }

    public IEnumerator levelEndedBones(int boneCount)
    {
        //yield return new WaitForSecondsRealtime(0.01f);         //bu line olmayınca ilk kemik kesinlikle büyümüyor ben de anlamadım saçma aq
        for(int i = 0; i<boneCount; i++)
        {
            GameObject currentBone = images[i].gameObject;
            currentBone.SetActive(true);
            Vector3 boneScale = currentBone.transform.localScale;
            currentBone.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            while(currentBone.transform.localScale.x < boneScale.x)
            {
                currentBone.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                yield return new WaitForSecondsRealtime(0.02f);
            }
        }
    }
}
