using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Attack", menuName = "Stats/Attack", order = 1)]
public class AttackStats : ScriptableObject {

	public float duration;
	public float atkCooldown;
	public bool invunerable;
	public string animation;
	public string keyAxis;
}