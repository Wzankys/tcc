using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (Instance != null && Instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            setInstance(this);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void Play(AudioClip clip,bool loop)
    {
        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.Play();
    }

    public bool isPlaying()
    {
        return audioSource.isPlaying;
    }
}
