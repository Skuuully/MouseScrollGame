using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public abstract class ClickableButton : MonoBehaviour
{
    [Header("Colours")]
    [Tooltip("The base color of the button")]
    /** The base color of the button */
    public Color baseColor;

    /** The color of the button when hovered over */
    [Tooltip("The color of the button when hovered over")]
    public Color hoverColor;
    [Space(10)]

    [Header("Other")]

    /** The text to display on the button */
    [Tooltip("The text to display on the button")]
    public string displayText;

    /** Reference to the background image */
    protected Image backgroundImage;
    /** Bool to show if mouse is hovering over the button */
    protected bool mouseOver;
    /** The text displayed */
    protected TextMeshProUGUI uiDisplayText;

    protected virtual void Start() {
        uiDisplayText = GetComponentInChildren<TextMeshProUGUI>();
        backgroundImage = GetComponentInChildren<Image>();
        uiDisplayText.text = displayText;
        mouseOver = false;
    }

    protected virtual void Update() {
        if (mouseOver) {
            backgroundImage.color = hoverColor;
        } else {
            backgroundImage.color = baseColor;
        }
    }

    /** Gets whether the mouse is currently hovering over the button */
    public bool getMouseOver() {
        return mouseOver;
    }

    private void OnMouseEnter() {
        mouseOver = true;
    }

    private void OnMouseExit() {
        mouseOver = false;
    }
}
