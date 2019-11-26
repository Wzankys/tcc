using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioList : MonoBehaviour
{
    public AudioClip sPresentation, sWin, sDash, sJump, sSelect, sAttack1, sAttack2, sAttack3, sHit1, sDeath,r1,r2,r3;
    private AudioSource audioS;
     void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

   IEnumerator PlaySong(AudioClip clip)
    {
        audioS.clip = clip;
        audioS.Play();
        yield return new WaitWhile(()=>audioS.isPlaying);
    }
    public void jumpSound()
    {
        StartCoroutine(PlaySong(sJump));
    }
    public void selectSound()
    {
        StartCoroutine(PlaySong(sSelect));
    }
    public void attack1Sound()
    {
        StartCoroutine(PlaySong(sAttack1));
    }
    public void attack2Sound()
    {
        StartCoroutine(PlaySong(sAttack2));
    }
    public void attack3Sound()
    {
        StartCoroutine(PlaySong(sAttack3));
    }
    public void hitSound()
    {
        StartCoroutine(PlaySong(sHit1));
    }
    public void deathSound()
    {
        StartCoroutine(PlaySong(sDeath));
    }
    public void winSound()
    {
        StartCoroutine(PlaySong(sWin));
    }
    public void presentationSound()
    {
        StartCoroutine( PlaySong(sPresentation));
    }
    public void dashSound()
    {
        StartCoroutine(PlaySong(sDash));
    }

    public void Reiatsu1()
    {
        StartCoroutine(PlaySong(r1));
    }
    public void Reiatsu2()
    {
        StartCoroutine(PlaySong(r2));
    }
    public void Reiatsu3()
    {
        StartCoroutine(PlaySong(r3));
    }
    
}
