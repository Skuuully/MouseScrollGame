using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class TimeToBeatText : MonoBehaviour
{
    float timeToBeat;
    void Start() {
        LevelStats stats = GameObject.FindGameObjectWithTag("Hole").GetComponent<LevelTracker>().getCurrentLevelStats();
        if (stats != null) {
            Debug.Log("time: " + stats.getTime());
            timeToBeat = stats.getTime();
            TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
            text.SetText(string.Format("{0:00.00}", timeToBeat));
        }
    }
}
