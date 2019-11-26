using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [Tooltip("Reference to the win UI GameObject")]
    public GameObject WinUI;
    private LevelTracker levelTracker;
    private Renderer render;

    void Start() {
        WinUI.SetActive(false);
        levelTracker = GameObject.FindGameObjectWithTag("Hole").GetComponent<LevelTracker>();
        render = GetComponent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            levelTracker.LevelCompleted(); 
            WinUI.SetActive(true);
        }
    }

    public bool isVisible()   
    {
        return render.isVisible;
    }
}
