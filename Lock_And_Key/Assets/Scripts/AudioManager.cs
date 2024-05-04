using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------- Audio Source ---------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------- Audio Clip ---------------")]
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
        musicSource.clip = background;
        musicSource.Play();
    }

    private void FixedUpdate()
    {
        if(!musicSource.isPlaying)
        {
            Debug.Log("restarting song");
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
