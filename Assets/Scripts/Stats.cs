using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Stats", menuName = "Stats/Stats", order = 1)]
public class Stats : ScriptableObject {
	public int playerId;
	public float healthPoints = 100.0f;
	public float maxHealthPoints = 100.0f;
	public float reiatsuPoints = 100.0f;

	public float reiatsuRechargeRate;

	public float resistence;
	public float magicalResist;

	public float damage;
	public float magicalDamage;
	public string GetPlayerIdName () {
		return GetName (playerId);
	}
	public string GetOpponentId () {
		int opponentId = playerId == 1 ? 2 : 1;
		return GetName (opponentId);
	}

	public string GetName (int id) {
		return "Player" + id;
	}

	public void TakeDamage (float damage) {
		healthPoints -= damage;
		Debug.Log (GetPlayerIdName () + " took " + damage + " damage");
	}

	public bool IsDead () {
		return healthPoints <= 0;
	}
}