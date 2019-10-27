using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AttackStats {
	[Header ("Attack Stats")]
	public float duration;
	public float cooldown;
	public float damage;
	public bool invunerable;
	public string animationName;
	public string keyAxis;
}