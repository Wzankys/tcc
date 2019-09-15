using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Stats", menuName = "Stats/Stats", order = 1)]
public class Stats : ScriptableObject {
	private float healthPoints = 100.0f;
	private float reiatsuPoints = 100.0f;

	public float reiatsuRechargeRate;

	public float resistence;
	public float magicalResist;

	public float damage;
	public float magicalDamage;
}