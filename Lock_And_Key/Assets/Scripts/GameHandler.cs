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

    public bool viewPurpleOn = false;

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
                } else if (levelPower == "colorview") {
                    viewPurpleOn = !viewPurpleOn;
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

    public void ToDungeon2(){
        SceneManager.LoadScene("Level1Dungeon2");
    }

    public void ToLevel2Start(){
        SceneManager.LoadScene("GravityTutorial");
    }

    public void ToLevel2Dungeon(){
        SceneManager.LoadScene("Level2Dungeon");
    }

    public void ToTutHiddenPower() {
        SceneManager.LoadScene("TutorialHiddenPower");
    }

     public void StartTutorial() {
        SceneManager.LoadScene("TutorialCell");
    }

    public void ToLevel3() {
        SceneManager.LoadScene("Level3Tutorial");
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
