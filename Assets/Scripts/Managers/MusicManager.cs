﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip audioClip;
    
    void Awake ()
    {
        var gameObject = GameObject.Find("Music Manager"); 
        gameObject.GetComponent<AudioSource>().clip = audioClip; 
        gameObject.GetComponent<AudioSource>().Play(); 
    }
}
