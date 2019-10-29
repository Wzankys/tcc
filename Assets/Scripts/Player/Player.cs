using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Stats playerStats;
	[Header ("Movement Settings")]
	public float knockbackForce = 5;
	public float jumpForce = 400f;
	public float speed;
	public float groundeCheckerOffset = 1.5f;
	public float dashForce = 200;
	[Range (0, .3f)] public float m_MovementSmoothing = .05f;
	private Rigidbody2D rb;
	private Animator animator;
	private float horizontalAxis, verticalAxis;
	private bool isJumping, isGrounded, isFacingRight = true, jump = false;
	private Vector3 velocity;
	private int jumpCount = 0;
	public int ID {
		get { return playerStats.playerId; }
	}

	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		playerStats = GetComponent<Stats> ();
		animator = GetComponent<Animator> ();
		playerStats.OnTakeDamage += OnTakeDamage;
		playerStats.OnPlayerDeath += OnPlayerDeath;
		isFacingRight = true;
	}

	void Update () {
		if (!GameManager.Instance.CompareState (GameState.GAME)) return;
		GetInput ();
		UpdateAnimations ();
	}

	void FixedUpdate () {
		Move ();
	}
	void OnTakeDamage (Stats playerStats) {
		PlayDamageAnimation ();
	}
	void OnPlayerDeath (Stats playerStats) {
		PlayDeathAnimation ();
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
	void PlayDeathAnimation () {
		animator.SetTrigger ("MorteP1");
	}

	void GetInput () {
		horizontalAxis = Input.GetAxisRaw ("Horizontal" + ID) * speed;
		JumpInput ();
		DashInput ();
	}

	void JumpInput () {
		if (Input.GetButtonDown ("Jump" + ID)) {
			Jump ();
		}
	}
	void DashInput () {
		if (Input.GetButtonDown ("Dash" + ID)) {
			Dash ();
		}
	}
	void Dash () {
		rb.AddForce (transform.TransformDirection (Vector2.right) * FacingDirection () * dashForce, ForceMode2D.Impulse);
		// animator.SetBool ("isDash", true);
		print ("DASH");
	}

	void UpdateAnimations () {
		animator.SetFloat ("Speed", Mathf.Abs (horizontalAxis));
	}
	void Move () {
		// Move the character by finding the target velocity
		Vector3 targetVelocity = new Vector2 (horizontalAxis * Time.fixedDeltaTime * 10f, rb.velocity.y);
		// And then smoothing it out and applying it to the character
		rb.velocity = Vector3.SmoothDamp (rb.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

		// If the input is moving the player right and the player is facing left...
		if (horizontalAxis > 0 && !isFacingRight) {
			// ... flip the player.
			Flip ();
		}
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (horizontalAxis < 0 && isFacingRight) {
			// ... flip the player.
			Flip ();
		}

	}

	void Jump () {
		if (IsGrounded () && !isJumping) {
			// Add a vertical force to the player.
			rb.AddForce (new Vector2 (0f, jumpForce));
			animator.SetBool ("isJumping", true);
			isJumping = true;
			jumpCount++;
		} else if (isJumping && jumpCount < 2) {
			rb.AddForce (new Vector2 (0f, jumpForce));
			jumpCount++;
		}
	}
	private void Flip () {
		// Switch the way the player is labelled as facing.
		isFacingRight = !isFacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public bool IsGrounded () {
		return Physics2D.Linecast (transform.position,
			transform.position + Vector3.down * groundeCheckerOffset,
			1 << LayerMask.NameToLayer ("Ground"));
	}

	private void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.CompareTag ("Ground"))
			GetComponent<Animator> ().SetBool ("isJumping", false);
		isJumping = false;
		jumpCount = 0;
	}

	/// <summary>
	/// Callback to draw gizmos that are pickable and always drawn.
	/// </summary>
	void OnDrawGizmos () {
		if (IsGrounded ()) {
			Gizmos.color = Color.green;
		} else Gizmos.color = Color.red;
		Gizmos.DrawLine (transform.position, transform.position + Vector3.down * groundeCheckerOffset);
	}

	float FacingDirection () {
		return Mathf.Clamp (transform.localScale.x, -1, 1);
	}
}