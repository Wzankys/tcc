using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAttack : MonoBehaviour {
	
	[FormerlySerializedAs("Stats")] public Stats stats;
	private Animator animator;
	private float cooldown;
	private bool canAttack = true;
	// Start is called before the first frame update
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (!stats) return;
		Attack ();
	}

	void Attack () {
		var axis = Input.GetAxisRaw (stats.keyAxis);
		if (axis > 0 && canAttack) {
			Debug.Log ("Teste");
			animator.SetTrigger (stats.animation);
			StartCoroutine (CooldownCoroutine ());
		}
	}

	IEnumerator CooldownCoroutine () {
		canAttack = false;
		yield return new WaitForSeconds (stats.atkCooldown);
		canAttack = true;
	}
}