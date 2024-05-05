using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public bool gameisover = false;
    public void Setup()
    {
        gameObject.SetActive(true);
        gameisover = true;
    }

    // public void RestartButton()
    // {
    //     SceneManagement.LoadScene("IntroCutscene");

    // }

    // public void ExitButton()
    // {
    //     SceneManagement.LoadScene("MainMenu");
    // }
}
