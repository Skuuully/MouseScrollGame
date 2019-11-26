using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Aimer : MonoBehaviour
{
    [Header("Colours")]
    [Tooltip("Colour of the aimer when inactive")]
    public Color defaultColor; // colour of the aimer when inactive

    [Tooltip("color when the aim button is pressed / held")]
    public Color activeColor; // color when the aim button is pressed/held

    [Tooltip("Aimer color at maximum shot power")]
    public Color fullyChargedColor; // aimer color at maximum shot power

    [Header("GameObject References")]
    [Tooltip("Game object to the aim line reference")]
    public GameObject aimer;

    private Color currentColor; // colour of the aimer at present
    private SpriteRenderer spriteRenderer; // the renderer of the aim line
    private Shot shot;
    private float currentShotPower;
    private float maxShotPower;
    private bool playerInControl;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shot = GetComponentInParent<Shot>();
        maxShotPower = shot.maxShotValue;
    }

    void Update() {
        currentShotPower = shot.GetShotPower();
        playerInControl = GetComponentInParent<PlayerController>().GetPlayerInControl();
        aimer.SetActive(playerInControl);
        aimer.SetActive(true);
        aimerColorCalc();
        resizeAimer();
    }

    /**  */
    private void aimerColorCalc() {
        Color currentColor = defaultColor;

        if(playerInControl) {
            if (shot.GetShotPower() > 0) {
                float red = Utils.GetValueInNewRange(currentShotPower, 0f, maxShotPower, activeColor.r, fullyChargedColor.r);
                float green = Utils.GetValueInNewRange(currentShotPower, 0f, maxShotPower, activeColor.g, fullyChargedColor.g);
                float blue = Utils.GetValueInNewRange(currentShotPower, 0f, maxShotPower, activeColor.b, fullyChargedColor.b);
                currentColor = new Color(red, green, blue);
            } else if (GetComponentInParent<PlayerController>().GetAiming()) {
                currentColor = activeColor;
            }
        }
        spriteRenderer.color = currentColor;
    }

    private void resizeAimer() {
        Vector3 currentScale = aimer.transform.localScale;
        float y = Utils.GetValueInNewRange(currentShotPower, 0f, maxShotPower, 3f, 4f);
        aimer.transform.localScale = new Vector3(currentScale.x, y, currentScale.z);
    }


}
