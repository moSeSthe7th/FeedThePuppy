using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selects a random sprite from an array
public class SpriteSelector : MonoBehaviour
{
    public Sprite[] sprites;

    void Start()
    {
        int i = Random.Range(0, sprites.Length);

        GetComponent<SpriteRenderer>().sprite = sprites[i];
        
    }
}


