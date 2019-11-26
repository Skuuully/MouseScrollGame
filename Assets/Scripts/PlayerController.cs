using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class PlayerController : MonoBehaviour
{
    public float shotScale; // A value to multiply the shot by to scale up or down the power
    public float rotationSpeed; // The speed of which to rotate

    private bool playerInControl; // Whether the player is currently aiming
    private Vector2 oldPos; // the position of the player last frame
    private Rigidbody2D rigidbody2d; // the rigidbody of the player
    private LevelTracker levelStats; // Stats about the level
    private bool aiming; // whether the player is currently holding space
    private float rotationStrength = 80;
    /** Never access directly outside of construction, use update ZRotation and get ZRotation to use its value */
    private Angle zRotation;

    private Shot shot; // shot stuff
    private float currentShotPower;


    void Start() {
        playerInControl = true;
        oldPos = new Vector2();
        rigidbody2d = GetComponent<Rigidbody2D>();
        levelStats = GameObject.FindGameObjectWithTag("Hole").GetComponent<LevelTracker>();
        shot = GetComponent<Shot>();
        // Aligned to the x axis, unity rotation is aligned to the y
        zRotation = new Angle(levelStats.getCurrentLevelStats().getStartingAngle());
    }

    private void Update() {

        if (Input.GetButton("AimLeft")) {
            rotateInZ(Time.deltaTime * rotationStrength);
        }

        if(Input.GetButton("AimRight")) {
            rotateInZ(Time.deltaTime * rotationStrength * -1);
        }

        if (Input.GetButtonDown("AimSpin")) {
            rotateInZ(180);
        }

        updateZRotation();

        if (Input.GetButton("Aim")) {
            aiming = true;
            if (playerInControl && (Input.mouseScrollDelta.y != 0)) {
                shot.IncrementShot(Mathf.Abs(Input.mouseScrollDelta.y));
            }
        } else {
            aiming = false;
            currentShotPower = shot.GetShotPower();
            if (currentShotPower > 0) {
                levelStats.ShotTaken();
                rigidbody2d.AddForce(-1 * getPointingVectorNormalised() * currentShotPower, ForceMode2D.Impulse);
            }
            shot.shotTaken();
        }
    }

    private void rotateInZ(float rotationAmount) {
        if (Mathf.Abs(rotationAmount) < 0.5f) {
            Debug.Log("Attempting to rotate by less than 0.5f: " + rotationAmount);
        } else {
            Debug.Log("Rotating amount: " + rotationAmount);
        }

        zRotation.addToAngle(rotationAmount);
    }

    private void updateZRotation() {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        // Remove 90 from the angle to align it back to the y axis as Unity expects
        Vector3 newRotation = new Vector3(currentRotation.x, currentRotation.y, zRotation.getAngleYAligned());
        transform.rotation = Quaternion.Euler(newRotation);
    }

    /** Gets the vector that the ball/aimer are pointing in */
    private Vector2 getPointingVectorNormalised() {
        float currentAngle = zRotation.getAngleXAligned();
        // Basic trig math, takes values in radians
        float x = Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float y = Mathf.Sin(currentAngle * Mathf.Deg2Rad);
        Vector2 pointingDirection = new Vector2(x, y);
        return pointingDirection.normalized;
    }

    private void FixedUpdate() {
        Vector2 newPos = transform.position;
        float distanceMoved = Vector2.Distance(oldPos, newPos);
        playerInControl = (distanceMoved < 0.025f) ? true : false;
        oldPos = newPos;
    }



    public bool GetPlayerInControl() {
        return playerInControl;
    }

    public bool GetAiming() {
        return aiming;
    }
}
