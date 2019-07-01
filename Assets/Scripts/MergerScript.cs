using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergerScript : MonoBehaviour
{
    
    public GameObject badDog;

    private GameObject board;

    public GameObject mergeParticleSystemObj;
    private ParticleSystem mergeParticleSystem;

    private void Start()
    {
        DataScript.isMergeAvailable = true;
    }

    

    public IEnumerator MergeObjects(GameObject gameObject, Vector3 mergePosition)
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
