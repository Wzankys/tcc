﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAttack : MonoBehaviour {

	public AttackStats attack;
	private Animator animator;
	private float cooldown;
	private bool canAttack = true;
	// Start is called before the first frame update
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		//if (!attack) return;
		Attack ();
	}

	void Attack () { 
		if (Input.GetKeyDown(KeyCode.Z)) {
            animator.SetTrigger("AttackB");
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer==12)
		{
            Debug.Log("deu boa colisao");
		}
	}
  
}