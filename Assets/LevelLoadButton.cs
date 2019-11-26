using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadButton : ClickableButton
{
    public GameObject GOselectorManager;
    private LevelSelectorManager selectorManager;
    private string levelTag;

    protected override void Start() {
        base.Start();
        selectorManager = GOselectorManager.GetComponent<LevelSelectorManager>();

        // default to level 1, can't hurt
        levelTag = "Level001"; 
    }

    protected override void Update() {
        base.Update();

        if (mouseOver && Input.GetMouseButtonUp(0)) {
            loadSelectedLevel();
        }
    }

    private void loadSelectedLevel() {
        levelTag = "Level" + selectorManager.getCurrentLevelTag();
        SceneManager.LoadScene(levelTag);
    }

}
