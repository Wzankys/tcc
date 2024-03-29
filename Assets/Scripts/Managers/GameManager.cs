﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

	public static SelectionSettings _selectionSettings;
	public SpriteRenderer background;
	public List<Player> players;
	public GameState gameState;
	public Image p1Icon,
	p2Icon;
	public Text txtTimer,
	wins1,
	wins2,
	name1,
	name2,
	txtPlayerWins;
	private float _timer = 60;
	private static int player1Wins,
	player2Wins;

	public static void Show (SelectionSettings settings) {
		SceneManager.LoadScene ("Game");
		_selectionSettings = settings;
	}
	void Start () {
		txtPlayerWins.enabled = false;
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
				p1Icon.sprite = player.selectedCharacter.prefab.GetComponent<Player> ().icon;
				name1.text = player.selectedCharacter.prefab.name.ToUpper();
				playerObject.transform.position = new Vector2 (-54, -36);
			} else if (player.selectedCharacter.number == 2) {
				p2Icon.sprite = player.selectedCharacter.prefab.GetComponent<Player> ().icon;
				name2.text = player.selectedCharacter.prefab.name.ToUpper();
				playerObject.transform.position = new Vector2 (-24, -36);
				playerObject.GetComponent<Player>().Flip();
			}
			Player playerScript = playerObject.GetComponent<Player> ();
			players.Add (playerScript);
			playerScript.playerStats.OnPlayerDeath += OnPlayerDeath;
		}
	}
	void OnPlayerDeath (Stats stats) {
		gameState = GameState.GAMEOVER;
		Debug.Log(stats.GetOpponentRawId ());
		if (stats.GetOpponentRawId () == 1) {
			player1Wins++;
			Debug.Log("p1 wins");
		}
		if (stats.GetOpponentRawId () == 2) {
			player2Wins++;
			Debug.Log("p2 wins");
		}

		if (player1Wins >= 2) {
			txtPlayerWins.enabled = true;
			txtPlayerWins.text = "PLAYER 1 WINS!";
			player1Wins = 0;
			player2Wins = 0;
			StartCoroutine (SelectScreenCoroutine ());
			return;
		} else if (player2Wins >= 2) {
			txtPlayerWins.enabled = true;
			txtPlayerWins.text = "PLAYER 2 WINS!";
			player1Wins = 0;
			player2Wins = 0;

			StartCoroutine (SelectScreenCoroutine ());
			return;
		}

		StartCoroutine (ResetGameCoroutine ());
	}

	IEnumerator ResetGameCoroutine () {
		yield return new WaitForSeconds (3);
		Show (_selectionSettings);
	}
	IEnumerator SelectScreenCoroutine () {
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene ("Select");
	}

	public bool CompareState (GameState state) {
		return state == gameState;
	}
	void Update () {
		if (_timer > 0)
			_timer -= Time.deltaTime;
		txtTimer.text = ((int) _timer).ToString ();
		if (_timer <= 0 && gameState != GameState.GAMEOVER) {
			gameState = GameState.GAMEOVER;
			if (players[0].playerStats.healthPoints >= players[1].playerStats.healthPoints) {
				player1Wins++;
			} else {
				player2Wins++;
			}
			StartCoroutine (ResetGameCoroutine ());
		}
	}
}