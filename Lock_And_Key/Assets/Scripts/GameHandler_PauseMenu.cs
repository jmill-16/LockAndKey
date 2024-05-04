using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameHandler_PauseMenu : MonoBehaviour {

        public static bool GameisPaused = false;
        public GameObject pauseMenuUI;
        private AudioManager audioManager;
        public static float volumeLevel = 1.0f;
        private Slider sliderVolumeCtrl;

        void Awake (){
                if (SceneManager.GetActiveScene() != null) {
                        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
                        SetLevel (volumeLevel);
                }
                GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                if (sliderTemp != null){
                        sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                        sliderVolumeCtrl.value = volumeLevel;
                }
        }

        void Start (){
                pauseMenuUI.SetActive(false);
                GameisPaused = false;
        }

        void Update (){
                if (Input.GetKeyDown(KeyCode.Escape)){
                        if (GameisPaused){
                                Resume();
                        }
                        else{
                                Pause();
                        }
                }
                if (pauseMenuUI.activeSelf == true && (SceneManager.GetActiveScene() != null)) {
                        GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                        sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                        SetLevel(sliderVolumeCtrl.value);
                }

        }

        public void Pause(){
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                GameisPaused = true;
        }

        public void Resume(){
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                GameisPaused = false;
        }

        public void SetLevel (float sliderValue){
                if (SceneManager.GetActiveScene() != null) {
                        audioManager.getMusic().volume = sliderValue;
                        audioManager.getSFX().volume = sliderValue;
                        volumeLevel = sliderValue;
                }
        }
}
