using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaSelection : MonoBehaviour {
	
	private int selectionIndex;
	private int previousIndex;
	private int nextIndex;

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
	private GameObject projectionObject;
	private Image projectionImage;
	
	public GameObject nextProjectionObject;
	private Image nextProjectionImage;

	public GameObject previousProjectionObject;
	private Image previousProjectionImage;


	// Start is called before the first frame update
	void Start () {
		leftButton = "Left1";
		rightButton = "Right1";
		selectionButton = "Selection1";
		textBox = GetComponentInChildren<Text>();
		audioSource = GetComponent<AudioSource>();
		projectionObject = GameObject.FindGameObjectWithTag("Arena Projection");
		var scenarios = Resources.LoadAll ("Scenarios", typeof (Sprite));
		Debug.Log ("Tamanho:" + scenarios.Length);
		image = GetComponent<Image> ();
		selectionIndex = 0;
		nextIndex = selectionIndex + 1;
		VerifyIndex(ref nextIndex);
		previousIndex = arenaList.Count;
		VerifyIndex(ref previousIndex);
		LoadAll (scenarios);
		image.sprite = arenaList[selectionIndex];
		
		projectionImage = projectionObject.GetComponent<Image>();
		nextProjectionImage = nextProjectionObject.GetComponent<Image>();
		previousProjectionImage = previousProjectionObject.GetComponent<Image>();
		
		projectionImage.sprite = image.sprite;
		nextProjectionImage.sprite = arenaList[nextIndex];
		previousProjectionImage.sprite = arenaList[previousIndex];
	}

	// Update is called once per frame
	void Update () {
		
		textBox.text = arenaList[selectionIndex].name.ToUpper();
		projectionImage.sprite = image.sprite;

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
		nextIndex = selectionIndex + 1;
		VerifyIndex(ref nextIndex);
		previousIndex = selectionIndex - 1;
		VerifyIndex(ref previousIndex);
		image.sprite = arenaList[selectionIndex];
		nextProjectionImage.sprite = arenaList[nextIndex];
		previousProjectionImage.sprite = arenaList[previousIndex];
		Debug.Log ("Index: " + selectionIndex);
	}

	public void Previous () {
		selectionIndex--;
		VerifyIndex (ref selectionIndex);
		nextIndex = selectionIndex + 1;
		VerifyIndex(ref nextIndex);
		previousIndex = selectionIndex - 1;
		VerifyIndex(ref previousIndex);
		image.sprite = arenaList[selectionIndex];
		nextProjectionImage.sprite = arenaList[nextIndex];
		previousProjectionImage.sprite = arenaList[previousIndex];
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
		yield return new WaitWhile(()=>audioSource.isPlaying);
		HudManager.Instance.OnSelectedArena (arenaList[selectionIndex]);
	}

	private void selectArena () {
		StartCoroutine(selectedArenaDelay());
	}
}