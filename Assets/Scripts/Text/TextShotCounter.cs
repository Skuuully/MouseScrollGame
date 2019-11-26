using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextShotCounter : MonoBehaviour
{
    private LevelTracker levelTracker;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        levelTracker = GameObject.FindGameObjectWithTag("Hole").GetComponent<LevelTracker>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = levelTracker.getShotsTaken().ToString();
    }
}
