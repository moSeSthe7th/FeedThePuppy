using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selects a random sprite from a List
public class SpriteSelector : MonoBehaviour
{
    public List<Sprite> sprites;

    void Start()
    {
       
        int i = Random.Range(0, sprites.Count);

        GetComponent<SpriteRenderer>().sprite = sprites[i];
        
    }
}


