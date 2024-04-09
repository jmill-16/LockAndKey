using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    private string sceneName;

    //Powers
    public bool viewHiddenOn = false;
    public bool speedOn = false;

    public bool reverseGravityOn = false;

    public string levelPower;   //make "speed", "reversegravity"

    public bool selectedHiddenPower;

    public bool canOpenDoor;
    // Start is called before the first frame update
    void Start()
    {
        selectedHiddenPower = true;
        canOpenDoor = false;
        sceneName = SceneManager.GetActiveScene().name;
    }

    public void Update() {
        //Debug.Log("view hidden: " + viewHiddenOn);
        //toggle selected power on and off
        if (Input.GetKeyDown("o")) {
            //Debug.Log("o pressed");
            //Debug.Log("view hidden: " + viewHiddenOn);
            if (selectedHiddenPower) {
                //Debug.Log("hidden");
                viewHiddenOn = !viewHiddenOn;
            } else {
                //Debug.Log("not hidden");
                if (levelPower == "speed") {
                    speedOn = !speedOn;
                } else if (levelPower == "reversegravity") {
                    reverseGravityOn = !reverseGravityOn;
                }
            }
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("IntroCutscene");
    }

    public void StartLevel1() {
        SceneManager.LoadScene("Level1Dungeon");
    }

     public void StartTutorial() {
        SceneManager.LoadScene("TutorialCell");
    }

    public void Credits() {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void returnToMM() {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        GameHandler_PauseMenu.GameisPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}
