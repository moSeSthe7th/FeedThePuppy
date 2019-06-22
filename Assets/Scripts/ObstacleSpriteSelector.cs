using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpriteSelector : MonoBehaviour
{
    public List<Sprite> sprites;


    void Start()
    {

        int i = Random.Range(0, DataScript.obstaclePaths.Length);
        int selectedSprite = DataScript.obstaclePaths[i];
        Debug.Log("SelectedSprite " + selectedSprite);
        GetComponent<SpriteRenderer>().sprite = sprites[selectedSprite];

    }
}
