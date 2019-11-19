using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

	public static SelectionSettings _selectionSettings;
	public SpriteRenderer background;
	public List<Player> players;
	public GameState gameState;
	public Text txtTimer,
	wins1,
	wins2;
	private float _timer = 60;
	private static int player1Wins,
	player2Wins;

	public static void Show (SelectionSettings settings) {
		SceneManager.LoadScene ("Game");
		_selectionSettings = settings;
	}
	void Start () {
		wins1.text = player1Wins.ToString ();
		wins2.text = player2Wins.ToString ();
		gameState = GameState.GAME;
		background.sprite = _selectionSettings.selectedArena.sprite;
		foreach (var player in _selectionSettings.selectionInfos) {
			//Debug.Log ("Numero de infos: " + _selectionSettings.selectionInfos.Count);
			//Debug.Log ("Player: " + player.selectedCharacter.number);
			player.selectedCharacter.prefab.GetComponent<Stats> ().SetPlayerID (player.selectedCharacter.number);
			GameObject playerObject = Instantiate (player.selectedCharacter.prefab);
			playerObject.layer = LayerMask.NameToLayer ("Player" + player.selectedCharacter.number);
			playerObject.GetComponentInChildren<BoxCollider2D> (true).gameObject.layer = LayerMask.NameToLayer ("Player" + player.selectedCharacter.number + "Hit");
			if (player.selectedCharacter.number == 1) {
				playerObject.transform.position = new Vector2 (-54, -36);
			} else if (player.selectedCharacter.number == 2) {
				playerObject.transform.position = new Vector2 (-24, -36);
			}
			Player playerScript = playerObject.GetComponent<Player> ();
			players.Add (playerScript);
			playerScript.playerStats.OnPlayerDeath += OnPlayerDeath;
		}
	}
	void OnPlayerDeath (Stats stats) {
		if (stats.GetOpponentRawId () == 0) {
			player1Wins++;
		}
		if (stats.GetOpponentRawId () == 1) {
			player2Wins++;
		}

		gameState = GameState.GAMEOVER;
		StartCoroutine (ResetGameCoroutine ());
	}

	IEnumerator ResetGameCoroutine () {
		yield return new WaitForSeconds (3);
		Show (_selectionSettings);
	}

	public bool CompareState (GameState state) {
		return state == gameState;
	}
	void Update () {
		_timer -= Time.deltaTime;
		txtTimer.text = ((int) _timer).ToString ();
	}
}