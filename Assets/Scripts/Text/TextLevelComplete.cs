using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLevelComplete : MonoBehaviour
{
    private Text text;
    private LevelTracker levelTracker;

    void Start() {
        levelTracker = GameObject.FindGameObjectWithTag("Hole").GetComponent<LevelTracker>();
        text = GetComponent<Text>();
        text.text = "";
    }

    void Update() {
        text.text = string.Format("Level complete!\n {0:00.00} \t" + levelTracker.getShotsTaken(), levelTracker.getTime());
    }
}
