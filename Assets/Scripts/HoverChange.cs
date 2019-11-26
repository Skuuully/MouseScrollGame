using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverChange : MonoBehaviour
{
    Image image;
    public Color baseColor;
    public Color hoverColor;
    void Start()
    {
        Image image = GetComponentInChildren<Image>();
    }

    void Update() {
        if (image != null) {
            image.color = baseColor;
        } else {
            Debug.Log("image not set");
        }
    }
}
