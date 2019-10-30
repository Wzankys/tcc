using System;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public Stats playerStats;
	public AttackStats attack;
	public delegate void AttackHandler (Stats playerAttacking, Stats playerAttacked);
	public static AttackHandler OnAttack;
	private Animator animator;
	private float cooldown;
	private bool canAttack = true;
	private bool attacking = false;
    private Player player;
	// Start is called before the first frame update
	void Start () {
		animator = GetComponent<Animator> ();
		playerStats = GetComponent<Stats> ();
        player = GetComponent<Player>();
	}

	// Update is called once per frame
	void Update () {
		//if (!attack) return;
		if (!GameManager.Instance.CompareState (GameState.GAME)) return;
		Attack ();
	}

	void Attack () {
		if (Input.GetButtonDown (GetAxisBasedOnPlayer (attack.keyAxis)) && canAttack) {
			animator.SetTrigger (attack.animationName);
			attacking = true;
			StartCoroutine (CooldownCoroutine ());
		}
	}
	private IEnumerator CooldownCoroutine () {
		canAttack = false;
		yield return new WaitForSeconds (attack.duration);
		canAttack = true;
	}
	private string GetAxisBasedOnPlayer (string axis) {
		return "AtaqueP" + playerStats.playerId + "." + axis;
	}

	private void OnTriggerEnter2D (Collider2D other) {
		if (attacking && other.gameObject.layer == LayerMask.NameToLayer (playerStats.GetOpponentId ())) {
			attacking = false;
			DealDamage (other.gameObject);
            Debug.Log ("deu boa colisao " + other.gameObject.layer + " " + LayerMask.NameToLayer (playerStats.GetOpponentId ()));
		}
	}
	public void DealDamage (GameObject enemy) {
		Stats enemyStats = enemy.GetComponent<Stats> ();
        Debug.Log("Player " + player);
        enemyStats.TakeDamage(attack.damage, player);
		SafelyCallOnAttack (playerStats, enemyStats);
	}

	void AttackOff () {
		attacking = false;
	}

	void SafelyCallOnAttack (Stats playerAttacking, Stats playerAttacked) {
		if (OnAttack != null) {
			OnAttack (playerAttacking, playerAttacked);
		}
	}

}