using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    
    void Start()
    {
        if (DataScript.puppyCount > 1 && DataScript.mergedPuppyCount == 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

   
    void Update()
    {
        
        if (DataScript.mergedPuppyCount == DataScript.puppyCount - 1)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
