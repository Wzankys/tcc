using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "AttackStat", menuName = "Attack/Attack Stats", order = 1)]
public class AttackStats : ScriptableObject {
	public float damage;
	public float duration;
	public float cooldown;
	public bool invunerable;
	public string animation;
	public string keyAxis;
}