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
    public void jumpSound()
    {
        PlaySong(sJump);
    }
    public void selectSound()
    {
        PlaySong(sSelect);
    }
    public void attack1Sound()
    {
        PlaySong(sAttack1);
    }
    public void attack2Sound()
    {
        PlaySong(sAttack2);
    }
    public void attack3Sound()
    {
        PlaySong(sAttack3);
    }
    public void hitSound()
    {
        PlaySong(sHit1);
    }
    public void deathSound()
    {
        PlaySong(sDeath);
    }
    public void winSound()
    {
        PlaySong(sWin);
    }
    public void presentationSound()
    {
        PlaySong(sPresentation);
    }
    public void dashSound()
    {
        PlaySong(sDash);
    }
}
