using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergerScript : MonoBehaviour
{
    
    public GameObject badDog;
    public GameObject bore;

    private GameObject board;

    public GameObject mergeParticleSystemObj;
    private ParticleSystem mergeParticleSystem;

    private void Start()
    {
        DataScript.isMergeAvailable = true;
        DataScript.mergedPuppyCount = 0;
    }

    
    public IEnumerator MergeObjects(string gameObjectToMerge, Vector3 mergePosition)
    {
        DataScript.canMove = true;

        if (DataScript.isMergeAvailable)
        {
            board = GameObject.FindWithTag("Board");

            GameObject mergerParticleObj = Instantiate(mergeParticleSystemObj, mergePosition, Quaternion.identity) as GameObject;
            mergeParticleSystem = mergerParticleObj.GetComponent<ParticleSystem>();
            mergeParticleSystem.Play();

            if(gameObjectToMerge == "Bad Dog")
            {
                GameObject go = Instantiate(badDog, mergePosition, Quaternion.identity, board.transform);
            }
            else if(gameObjectToMerge == "Bore")
            {
                GameObject go = Instantiate(bore, mergePosition, Quaternion.identity, board.transform);
                DataScript.mergedPuppyCount += 1;
            }
            
        }
        yield return new WaitForSecondsRealtime(0.2f);
    }

   /* public void MergeObjects(GameObject mergedObject, Vector3 mergePosition)
    {
        DataScript.canMove = true;
        
        if (DataScript.isMergeAvailable)
        {
            
            board = GameObject.FindWithTag("Board");

            GameObject mergerParticleObj = Instantiate(mergeParticleSystemObj, mergePosition, Quaternion.identity) as GameObject;
            mergeParticleSystem = mergerParticleObj.GetComponent<ParticleSystem>();
            mergeParticleSystem.Play();

            GameObject go = Instantiate(badDog, mergePosition, Quaternion.identity, board.transform);
        }
      
    }*/


}
