using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
	public AttackStats attackStats;
	private Animator animator;
	private float cooldown;
	private bool canAttack = true;
	// Start is called before the first frame update
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (!attackStats) return;
		Attack ();
	}

	void Attack () {
		var axis = Input.GetAxisRaw (attackStats.keyAxis);
		if (axis > 0 && canAttack) {
			Debug.Log ("Teste");
			animator.SetTrigger (attackStats.animation);
			StartCoroutine (CooldownCoroutine ());
		}
	}

	IEnumerator CooldownCoroutine () {
		canAttack = false;
		yield return new WaitForSeconds (attackStats.cooldown);
		canAttack = true;
	}
}