﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
	public AudioClip audioClip;

	void Awake () {
		var gameObject = GameObject.Find ("Music Manager");
		AudioSource audioSource = GetComponent<AudioSource> ();
		if (audioSource != null) {
			audioSource.clip = audioClip;
			audioSource.Play ();
		}
	}
}