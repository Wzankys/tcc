using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Stats playerStats;
	public float knockbackForce = 5;
	private Rigidbody2D rb;
	private Animator animator;

	void Start () {
		//rb.GetComponent<Rigidbody2D> ();
		playerStats = GetComponent<Stats> ();
		playerStats.OnTakeDamage += OnTakeDamage;
		animator = GetComponent<Animator> ();
	}
	void OnTakeDamage (Stats playerStats) {
		Debug.Log ("ON TAKE DAMAGE");

		PlayDamageAnimation ();
	}

	float GetPlayerDirection () {
		return Mathf.Clamp (transform.localScale.x, -1, 1);
	}
	public void Knockback () {
		float dir = GetPlayerDirection ();
		rb.AddForce (Vector2.right * dir * knockbackForce);
	}
	void PlayDamageAnimation () {
		animator.SetTrigger ("LevarDano");
	}
}