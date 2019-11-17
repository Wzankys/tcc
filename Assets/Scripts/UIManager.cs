using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public Slider hpUI;
	public Slider hpUI2;
	public Slider reiatsuUI;
	public Slider reiatsuUI2;
	public Image playerImg, playerImg2;

	public Stats[] stats;

	// Start is called before the first frame update
	void Start () {
		SetupStats ();
		OrderStats ();
		SetupHealthBar ();
	}
	private void SetupStats () {
		stats = FindObjectsOfType<Stats> ();
		foreach (var stat in stats) {
			stat.OnTakeDamage += OnPlayerTakeDamage;
			stat.OnChargeReiatsu += OnPlayerChargeReiatsu;
		}
	}
	private void OrderStats () {
		if (stats[0].playerId != 1) {
			Stats player1Stats = stats[1];
			stats[1] = stats[0];
			stats[0] = player1Stats;
		}
	}

	public void OnPlayerTakeDamage (Stats playerStats, Player enemy) {
		Slider playerBar = playerStats.playerId == 1 ? hpUI : hpUI2;
		UpdateBar (playerBar, (int) playerStats.healthPoints);
	}
	public void OnPlayerChargeReiatsu (Stats playerStats) {
		Slider playerBar = playerStats.playerId == 1 ? reiatsuUI : reiatsuUI2;
		UpdateBar (playerBar, (int) playerStats.reiatsuPoints);
	}

	public void SetupHealthBar () {
		hpUI.maxValue = stats[0].maxHealthPoints;
		hpUI.value = hpUI.maxValue;

		hpUI2.maxValue = stats[1].maxHealthPoints;
		hpUI2.value = hpUI2.maxValue;

		reiatsuUI.maxValue = 100;
		reiatsuUI.value = stats[0].reiatsuPoints;

		reiatsuUI2.maxValue = 100;
		reiatsuUI.value = stats[1].reiatsuPoints;
	}
	public void UpdateBar (Slider bar, int value) {
		bar.value = value;
	}

	public void UpdateHP1 (int qntd) {
		hpUI.value = qntd;
	}
	public void UpdateHP2 (int qntd) {
		hpUI2.value = qntd;
	}
}