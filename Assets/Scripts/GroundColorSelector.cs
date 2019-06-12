using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColorSelector : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = DataScript.groundColor;
    }

   
}
