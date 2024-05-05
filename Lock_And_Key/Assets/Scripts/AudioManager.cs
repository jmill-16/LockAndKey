using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public GameOver GameOver;
    public bool isaudioplaying = false;

    [Header("------------- Audio Source ---------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] public AudioSource SFXSource;

    [Header("------------- Audio Clip ---------------")]
    public AudioClip mainmenumusic;
    public AudioClip background;
    public AudioClip gravityOn;
    public AudioClip gravityOFF;
    public AudioClip ViewHiddenOn;
    public AudioClip ViewHiddenOff;
    public AudioClip walking;
    public AudioClip unlockDoor;
    public AudioClip enemyDamage;

    private void Start()
    {
        if(GameOver.gameisover == true)
        {
            Debug.Log("stop playing music");
            musicSource.Stop();
            musicSource.clip = mainmenumusic;
            musicSource.Play();
        } else {
            musicSource.clip = background;
            musicSource.Play();
        }
    }

    private void Update()
    {
        if(GameOver.gameisover == true && !isaudioplaying)
        {
            isaudioplaying = true;
            Debug.Log("stop playing music");
            musicSource.Stop();
            musicSource.clip = mainmenumusic;
            musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public AudioSource getMusic() {
        return musicSource;
    }

    public AudioSource getSFX() {
        return SFXSource;
    }
}
