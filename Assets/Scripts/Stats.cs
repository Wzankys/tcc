using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {
	public int playerId;
	public float healthPoints = 100.0f;
	public float maxHealthPoints = 100.0f;
	public float reiatsuPoints = 100.0f;

	public float reiatsuRechargeRate = 5;

	public float resistence;
	public float magicalResist;

	public float damage;
	public float magicalDamage;
	public delegate void StatsHandler (Stats stats);
	public delegate void AttackHandler (Stats stats, Player enemy);
	public AttackHandler OnTakeDamage;
	public StatsHandler OnPlayerDeath;
	public StatsHandler OnChargeReiatsu;
	public string GetPlayerIdName () {
		return GetName (playerId);
	}
	public string GetOpponentId () {
		int opponentId = playerId == 1 ? 2 : 1;
		return GetName (opponentId);
	}

	public void SetPlayerID (int id) {
		playerId = id;
	}

	public string GetName (int id) {
		return "Player" + id;
	}

	public void TakeDamage (float damage, Player enemy) {
		healthPoints -= damage;
		Debug.Log ("TAKE DAMAGE " + enemy);
		//Debug.Log (GetPlayerIdName () + " took " + damage + " damage");
		SafelyCallOnTakeDamage (enemy);
		if (healthPoints <= 0) {
			SafelyCallOnPlayerDeath ();
		}
	}

	public bool IsDead () {
		return healthPoints <= 0;
	}

	public void SafelyCallOnTakeDamage (Player enemy) {
		if (OnTakeDamage != null) {
			Debug.Log ("Enemy " + enemy);
			OnTakeDamage (this, enemy);
		}
	}
	public void SafelyCallOnPlayerDeath () {
		if (OnPlayerDeath != null) {
			OnPlayerDeath (this);
		}
	}

	public void ChargeReiatsu (float amount) {
		reiatsuPoints += amount;
		if (OnChargeReiatsu != null) OnChargeReiatsu (this);
	}

}