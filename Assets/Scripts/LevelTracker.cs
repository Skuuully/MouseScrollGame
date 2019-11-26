using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class LevelTracker : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The stats for all the levels, target times etc.")]
    public LevelStats[] lStats;

    private int shotsTaken; // number of shots taken so far.
    private float timer; // tracks the time.
    private bool levelCompleted;

    void Start() {
        levelCompleted = false;
        ResetLevel();
    }


    void Update() {
        if (levelCompleted) {
            Time.timeScale = 0.0f;
        } else {
            timer += Time.deltaTime;
        }
    }

    /** Resets the stats of the level */
    public void ResetLevel() {
        shotsTaken = 0;
        timer = 0;
    }

    /** Increments the shot counter */
    public void ShotTaken() {
        shotsTaken++;
    }

    /** Accessor for the number of shots taken */
    public int getShotsTaken() {
        return shotsTaken;
    }

    /** Accessor for the amount of time elapsed for the level */
    public float getTime() {
        return timer;
    }

    /** Accessor to set the level as having been completed, used to stop time, show win etc. */
    public void LevelCompleted() {
        levelCompleted = true;
    }

    /** Return the stats of the current level. If the name of the level does not contain a digit then returns null */
    public LevelStats getCurrentLevelStats() {
        LevelStats stats = null;
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(sceneName);
        for (int i = 0; i < sceneName.Length; i++) {
            char currentChar = sceneName[i];
            if (Utils.isDigit(currentChar)) {
                int levelNo = (int)char.GetNumericValue(currentChar);
                if (levelNo <= lStats.Length && currentChar != '0') {
                    stats = lStats[(int)levelNo -1];
                }
            }
        }

        Debug.Log("Returning: " + stats);
        return stats;
    }
   
}
