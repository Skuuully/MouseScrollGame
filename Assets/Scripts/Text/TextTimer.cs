using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTimer : MonoBehaviour
{
    private LevelTracker levelStats;
    private Text text;
    private float time;
    
    void Start() {
        text = GetComponent<Text>();
        levelStats = GameObject.FindGameObjectWithTag("Hole").GetComponent<LevelTracker>();
        text.text = "";
    }

    // Update is called once per frame
    void Update() {
        time = levelStats.getTime();
        text.text = string.Format("{0:00.00}", time); // Formats as xx:xx
    }
}
