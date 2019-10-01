using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	public Stats playerStats;
	// Start is called before the first frame update
	void Start () {
		playerStats = Instantiate (playerStats);
	}

	// Update is called once per frame
	void Update () {

	}
}