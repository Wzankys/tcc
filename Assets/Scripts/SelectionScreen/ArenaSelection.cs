using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaSelection : MonoBehaviour {
	private int selectionIndex;

	private float selectionDelay;

	public float delayTime;
	
	private string Name;
	private Text textBox;

	private AudioSource audioSource;

	public AudioClip select;
	public AudioClip selected;

	//inputs
	private string leftButton;
	private string rightButton;
	private string selectionButton;

	private List<Sprite> arenaList = new List<Sprite> ();

	private Image image;

	// Start is called before the first frame update
	void Start () {
		leftButton = "Left2";
		rightButton = "Right2";
		selectionButton = "Selection1";
		textBox = GetComponentInChildren<Text>();
		audioSource = GetComponent<AudioSource>();
		var scenarios = Resources.LoadAll ("Scenarios", typeof (Sprite));
		Debug.Log ("Tamanho:" + scenarios.Length);
		image = GetComponent<Image> ();
		selectionIndex = 0;
		LoadAll (scenarios);
		image.sprite = arenaList[selectionIndex];
	}

	// Update is called once per frame
	void Update () {
		
		textBox.text = arenaList[selectionIndex].name.ToUpper();

		if (selectionDelay < Time.time) {
			if (Input.GetButton (leftButton))
			{
				audioSource.clip = @select;
				audioSource.Play();
				selectionDelay = Time.time + delayTime;
				Previous ();
			}

			if (Input.GetButton (rightButton)) {
				audioSource.clip = @select;
				audioSource.Play();
				selectionDelay = Time.time + delayTime;
				Next ();
			}
		}

		if (Input.GetButtonDown (selectionButton)) {
			print ("AAAAAAA");
			StartCoroutine(selectedArenaDelay());
			selectArena ();
		}

	}

	public void LoadAll (object[] loadedObjects) {
		for (int i = 0; i < loadedObjects.Length; i++) {
			arenaList.Add (loadedObjects[i] as Sprite);
		}

	}

	public void Next () {
		selectionIndex++;
		VerifyIndex (ref selectionIndex);
		image.sprite = arenaList[selectionIndex];
		Debug.Log ("Index: " + selectionIndex);
	}

	public void Previous () {
		selectionIndex--;
		VerifyIndex (ref selectionIndex);
		image.sprite = arenaList[selectionIndex];
		Debug.Log ("Index: " + selectionIndex);
	}

	public void VerifyIndex (ref int index) {
		if (index >= arenaList.Count) { index = 0; } else if (index < 0) {
			index = arenaList.Count - 1;
		}
	}

	IEnumerator selectedArenaDelay()
	{
		audioSource.clip = @selected;
		audioSource.Play();
		yield return new WaitForSeconds(selected.length);
	}

	private void selectArena () {
		HudManager.Instance.OnSelectedArena (arenaList[selectionIndex]);
	}
}