using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergerScript : MonoBehaviour
{
    public bool isMergeAvailable;           // bu true olmuyor bi daha
    public GameObject badDog;

    private GameObject board;

    private void Start()
    {
        isMergeAvailable = true;
        
    }

    

    public IEnumerator MergeObjects(GameObject gameObject, Vector3 position)
    {
        board = GameObject.FindWithTag("Board");

        yield return new WaitForSecondsRealtime(0.2f);

        

        if (isMergeAvailable)
        {
            gameObject.SetActive(false);
            //GameObject go = Instantiate(badDog, position, Quaternion.identity,board.transform);
        }

        isMergeAvailable = true;
        
        
    }
}
