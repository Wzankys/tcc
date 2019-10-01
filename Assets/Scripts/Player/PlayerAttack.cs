using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public Stats playerStats;
	public AttackStats attack;
	private Animator animator;
	private float cooldown;
	private bool canAttack = true;
	// Start is called before the first frame update
	void Start () {
		animator = GetComponent<Animator> ();
		playerStats = GetComponent<PlayerStats> ().playerStats;
	}

	// Update is called once per frame
	void Update () {
		//if (!attack) return;
		Attack ();
	}

	void Attack () {
		if (Input.GetButtonDown (attack.keyAxis)) {
			animator.SetTrigger (attack.animation);
		}
	}

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer (playerStats.GetOpponentId ())) {
			other.GetComponent<PlayerStats> ().playerStats.TakeDamage (attack.damage);
			Debug.Log ("deu boa colisao " + other.gameObject.layer + " " + LayerMask.NameToLayer (playerStats.GetOpponentId ()));
		}
	}
}