using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorExit_Items : MonoBehaviour
{
    public GameHandler gameHandler;
    public string NextLevel;
    public AudioSource audioSource;

    private bool isAudioPlaying = false;

    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        gameObject.GetComponent<Collider2D>().enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (gameHandler.canOpenDoor)
        {
            Debug.Log("Door available");
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isAudioPlaying)
            {
                StartCoroutine(PlayAudioAndLoadNextLevel());
            }
        }
    }

    IEnumerator PlayAudioAndLoadNextLevel()
    {
        isAudioPlaying = true;
        audioSource.Play();

        // Wait for the duration of the audio clip
        yield return new WaitForSeconds(audioSource.clip.length);

        // Load the next level
        SceneManager.LoadScene(NextLevel);
    }
}