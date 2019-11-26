using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class LevelButton : ClickableButton
{
    [Tooltip("The name of the level the button loads")]
    /** The name of the level the button loads */
    public string levelTag;

    protected override void Start() {
        base.Start();
    }

    protected override void Update() {
        base.Update();
        if (mouseOver && Input.GetMouseButtonUp(0)) {
            if (levelTag.Equals("Restart")) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name.ToString());
                Time.timeScale = 1.0f;
            } else if (levelTag.Equals("Next")) {
                SceneManager.LoadScene(ParseLevel());
                Time.timeScale = 1.0f;
            } else if (levelTag.Equals("Main Menu")) {
                SceneManager.LoadScene("Main Menu");
                Time.timeScale = 1.0f;
            }
        }
    }

    /** 
 * Returns a string which is the end part of a level identifier e.g. "001", or "123" 
 * Uses this levels name and parses out the number to add one onto to get the number of the next level 
 */
    private string ParseLevel() {
        // Get this levels name
        string currentScene = SceneManager.GetActiveScene().name.ToString();
        char[] levelTagChar = currentScene.ToCharArray();
        int currentSceneLength = currentScene.Length;
        int numDigits = 0;
        char[] digits = new char[currentSceneLength];

        // Loop through the name adding the digits from the name to the digits array
        for (int i = 0; i < currentSceneLength; i++) {
            if (Utils.isDigit(levelTagChar[i])) {
                digits[numDigits] = levelTagChar[i];
                numDigits++;
            }
        }

        // Populate a new array containg just the digits to parse out
        char[] digitCharArray = new char[numDigits];
        for (int i = 0; i < numDigits; i++) {
            digitCharArray[i] = digits[i];
        }

        string s = new string(digitCharArray);
        int.TryParse(s, out int parsed);
        int currentLevelNum = parsed;
        int nextLevel = currentLevelNum + 1;

        string returnVal = "Level";
        if (currentLevelNum < 10) {
            returnVal += "00" + nextLevel.ToString();
        } else if (currentLevelNum < 100) {
            returnVal += "0" + nextLevel.ToString();
        } else {
            returnVal += nextLevel.ToString();
        }
        return returnVal;
    }
}
