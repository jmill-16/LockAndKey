using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// using UnityEditorInternal;

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

    private Animator playerAnim;
    public Animator transition;

    //public Animator colorAnimOn;
    // Start is called before the first frame update
    void Start()
    {
        selectedHiddenPower = true;
        canOpenDoor = false;
        sceneName = SceneManager.GetActiveScene().name;
        if (GameObject.FindWithTag("Player") != null) {
            playerAnim = GameObject.FindWithTag("Player").GetComponentInChildren<Animator>();
        }
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
                if (playerAnim) {
                    if (viewHiddenOn) {
                            playerAnim.SetTrigger("ColorVis");
                    }
                    else {
                        Debug.Log("turn off");
                        playerAnim.SetTrigger("ColorVisOff");
                    }
                }
            } else {
                //Debug.Log("not hidden");
                if (levelPower == "speed") {
                    speedOn = !speedOn;
                    if (playerAnim) {
                            playerAnim.SetTrigger("SpeedOn");}
                } else if (levelPower == "reversegravity") {
                    if (reverseGravityOn) {
                        reverseGravityOn = false;
                        if (playerAnim) {
                            playerAnim.SetTrigger("FlipGravOff");}
                    } else {
                        reverseGravityOn = true;
                        if (playerAnim) {
                            playerAnim.SetTrigger("FlipGrav");}
                    }
                } else if (levelPower == "colorview") {
                    if (viewPurpleOn) {
                        viewPurpleOn = false;
                        if (playerAnim) {
                            playerAnim.SetTrigger("ColorVisOff");}
                    } else {
                        viewPurpleOn = true;
                        if (playerAnim) {
                            playerAnim.SetTrigger("ColorVis");}
                    }
                    //viewPurpleOn = !viewPurpleOn;
                    //Debug.Log("viewpurple: " + viewPurpleOn);

                }
            }
        }
    }

    IEnumerator TransitionTrigger() {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
    }

    public void StartGame() {
        TransitionTrigger();
        SceneManager.LoadScene("IntroCutscene");
    }

    public void StartLevel1() {
        TransitionTrigger();
        SceneManager.LoadScene("Level1Dungeon");
    }

    public void ToDungeon2(){
        TransitionTrigger();
        SceneManager.LoadScene("Level1Dungeon2");
    }

    public void ToDungeon3() {
        TransitionTrigger();
        SceneManager.LoadScene("Level1Dungeon3");
    }

    public void ToLevel2Start(){
        TransitionTrigger();
        SceneManager.LoadScene("GravityTutorial");
    }

    public void ToLevel2Dungeon(){
        TransitionTrigger();
        SceneManager.LoadScene("Level2Dungeon");
    }

    public void ToTutHiddenPower() {
        TransitionTrigger();
        SceneManager.LoadScene("TutorialHiddenPower");
    }

     public void StartTutorial() {
        TransitionTrigger();
        SceneManager.LoadScene("TutorialCell");
    }

    public void ToLevel3() {
        TransitionTrigger();
        SceneManager.LoadScene("Level3Tutorial");
    }

    public void Credits() {
        TransitionTrigger();
        SceneManager.LoadScene("Credits");
    }

    public void ToDungeonBoss(){
        TransitionTrigger();
        SceneManager.LoadScene("DungeonBoss");
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
