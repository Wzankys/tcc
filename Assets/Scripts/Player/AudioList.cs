using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioList : MonoBehaviour
{
    public AudioClip sPresentation, sWin, sDash, sJump, sSelect, sAttack1, sAttack2, sAttack3, sHit1, sDeath;
    private AudioSource audioS;
     void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

   public void PlaySong(AudioClip clip)
    {
        audioS.clip = clip;
        audioS.Play();
    }
    void jumpSound()
    {
        PlaySong(sJump);
    }
    void selectSound()
    {
        PlaySong(sSelect);
    }
    void attack1Sound()
    {
        PlaySong(sAttack1);
    }
    void attack2Sound()
    {
        PlaySong(sAttack2);
    }
    void attack3Sound()
    {
        PlaySong(sAttack3);
    }
    void hitSound()
    {
        PlaySong(sHit1);
    }
    void deathSound()
    {
        PlaySong(sDeath);
    }
    void winSound()
    {
        PlaySong(sWin);
    }
    void presentationSound()
    {
        PlaySong(sPresentation);
    }
    void dashSound()
    {
        PlaySong(sDash);
    }
}
