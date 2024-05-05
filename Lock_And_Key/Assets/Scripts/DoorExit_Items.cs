using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorExit_Items : MonoBehaviour
{
    public GameHandler gameHandler;
    public string NextLevel;
    public AudioSource audioSource;

    public AudioManager audioManager;

    private bool isAudioPlaying = false;

    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        gameObject.GetComponent<Collider2D>().enabled = false;
        //audioSource = GetComponent<AudioSource>();
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (gameHandler.canOpenDoor)
        {
            //Debug.Log("Door available");
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    //   void Update(){
    //         if (gameHandler.canOpenDoor){
    //             //Debug.Log("door available");
    //               gameObject.GetComponent<Collider2D>().enabled = true;
    //         }
    //   }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("here");

        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("yup");
            if (!isAudioPlaying)
            {
                StartCoroutine(PlayAudioAndLoadNextLevel());
            }
        }
    }

    IEnumerator PlayAudioAndLoadNextLevel()
    {
        isAudioPlaying = true;
        //audioSource.Play();

        audioManager.SFXSource.clip = audioManager.unlockDoor;
        audioManager.SFXSource.Play();

        // Wait for the duration of the audio clip
        //yield return new WaitForSeconds(audioSource.clip.length);
        yield return new WaitForSeconds(audioManager.SFXSource.clip.length);

        // Load the next level
        SceneManager.LoadScene(NextLevel);
    }
}