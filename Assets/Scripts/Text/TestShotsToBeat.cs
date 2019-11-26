using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using TMPro;

public class TestShotsToBeat : MonoBehaviour
{
    int shotsToBeat;

    void Start()
    {
        LevelStats stats = GameObject.FindGameObjectWithTag("Hole").GetComponent<LevelTracker>().getCurrentLevelStats();
        if (stats != null) {
            Debug.Log("shots: " + stats.getShots());
            shotsToBeat = stats.getShots();
            TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
            text.SetText(string.Format("{0:00}", shotsToBeat));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
