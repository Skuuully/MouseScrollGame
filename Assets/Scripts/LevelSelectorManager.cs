using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using TMPro;

public class LevelSelectorManager : MonoBehaviour
{
    public TextMeshProUGUI flavourText;

    private LevelButton[] levelButtons;
    /** The current selected levels level stats reference */
    private LevelStats currentLevelStats;
    private string currentLevelTag;
    private LevelStats[] allLevelStats;

    void Start() {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("levelButton");
        levelButtons = new LevelButton[gameObjects.Length];
        for (int i = 0; i < levelButtons.Length; i++) {
            levelButtons[i] = gameObjects[i].GetComponent<LevelButton>();
        }

        allLevelStats = GameObject.FindGameObjectWithTag("Hole").GetComponent<LevelTracker>().lStats;
        currentLevelStats = allLevelStats[0];
    }

    void Update() {
        if (Input.GetMouseButtonUp(0)) {
            updateCurrentlySelectedLevelStats();
        }

        flavourText.text = currentLevelStats.getFlavourName();
    }

    /** Iterate through the level stats and if selected update the currently selected, break out early once found
     * Iterate in reverse as when the elements were added gets added to position 0 */
    private void updateCurrentlySelectedLevelStats() {
        for (int i = 0; i < levelButtons.Length; i++) {
            if (levelButtons[i].getMouseOver()) {
                currentLevelStats = allLevelStats[i];
                currentLevelTag = levelButtons[i].levelTag;
                break;
            }
        }
    }

    public LevelStats getCurrentlySelectedLevelStats() {
        return currentLevelStats;
    }

    public string getCurrentLevelTag() {
        return currentLevelTag;
    }
}
