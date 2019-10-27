using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {
	public int playerId;
	public float healthPoints = 100.0f;
	public float maxHealthPoints = 100.0f;
	public float reiatsuPoints = 100.0f;

	public float reiatsuRechargeRate;

	public float resistence;
	public float magicalResist;

	public float damage;
	public float magicalDamage;
	public delegate void StatskHandler (Stats stats);
	public StatskHandler OnTakeDamage;
	public StatskHandler OnPlayerDeath;
	public string GetPlayerIdName () {
		return GetName (playerId);
	}
	public string GetOpponentId () {
		int opponentId = playerId == 1 ? 2 : 1;
		return GetName (opponentId);
	}

	public void SetPlayerID(int id)
	{
		playerId = id;
	}

	public string GetName (int id) {
		return "Player" + id;
	}

	public void TakeDamage (float damage) {
		healthPoints -= damage;
		Debug.Log (GetPlayerIdName () + " took " + damage + " damage");
		SafelyCallOnTakeDamage ();
	}

	public bool IsDead () {
		return healthPoints <= 0;
	}

	public void SafelyCallOnTakeDamage () {
		if (OnTakeDamage != null) {
			OnTakeDamage (this);
		}
	}

}