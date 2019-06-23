using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewHomeSliderFillColor : MonoBehaviour
{

    private Image image;

    private void OnEnable()
    {
        image = GetComponent<Image>();
        image.color = DataScript.boneColor;
    }
}
