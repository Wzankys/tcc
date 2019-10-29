using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static SelectionSettings _selectionSettings;
	public SpriteRenderer background;

	public static void Show (SelectionSettings settings) {
		SceneManager.LoadScene ("Game");
		_selectionSettings = settings;
	}
	void Start () {
		background.sprite = _selectionSettings.selectedArena.sprite;
		foreach (var player in _selectionSettings.selectionInfos) {
			Debug.Log ("Numero de infos: " + _selectionSettings.selectionInfos.Count);
			Debug.Log ("Player: " + player.selectedCharacter.number);
			player.selectedCharacter.prefab.GetComponent<Stats> ().SetPlayerID (player.selectedCharacter.number);
			GameObject playerObject = Instantiate (player.selectedCharacter.prefab);
			playerObject.layer = LayerMask.NameToLayer ("Player" + player.selectedCharacter.number);
			playerObject.GetComponentInChildren<BoxCollider2D> (true).gameObject.layer = LayerMask.NameToLayer ("Player" + player.selectedCharacter.number + "Hit");
			if (player.selectedCharacter.number == 1) {
				playerObject.transform.position = new Vector2 (-54, -36);
			} else if (player.selectedCharacter.number == 2) {
				playerObject.transform.position = new Vector2 (-24, -36);
			}
		}
	}

	void Update () {

	}
}