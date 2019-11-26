using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
	public AudioClip musicMenu;

	void Start ()
	{
		AudioManager.Instance.Play(musicMenu,true);
		/*var gameObject = GameObject.Find ("Music Manager");
		AudioSource audioSource = gameObject.GetComponent<AudioSource> ();
		if (audioSource != null) {
			audioSource.clip = musicMenu;
			audioSource.loop = true;
			audioSource.Play ();
		}*/
	}
}