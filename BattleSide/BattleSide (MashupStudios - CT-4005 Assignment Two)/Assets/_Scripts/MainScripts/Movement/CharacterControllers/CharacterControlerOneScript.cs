// Character Controler Script:
// Written by Iain Farlow updated by Oliver Blackwell
// Created 27 / 01 / 2020
// Last Updated: 12/05/2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlerOneScript : MonoBehaviour {
	private Rigidbody2D rb2d;

	public bool inTriggerRight = false;
	public bool inTriggerLeft = false;
	public bool isGrounded = false;

	Animator animator;

	void Start() {
		// gets the players ridgidbody
		rb2d = GetComponent<Rigidbody2D>();
		// get the players animator
		animator = GetComponent<Animator>();
	}

    //Check if on the ground to prevent double jump (but still allow 'climb')
    void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Ground") {
			isGrounded = true;
		}
	}
	void OnCollisionExit2D(Collision2D collision) {
		if (collision.gameObject.tag == "Ground") {
			isGrounded = false;
		}
	}

	// Update is called once per frame
	void Update() {
		// if the player is moving left
		if (Input.GetAxis("Horizontal") == -1) {
			Vector2 movement = new Vector2(-5.0f, 0);
			if (inTriggerLeft == true) {
				movement = new Vector2(-5.0f, 8.0f);
			}
			rb2d.AddForce(movement);
			animator.SetBool("isWalkingLeft", true);
		} else {
			animator.SetBool("isWalkingLeft", false);
		}
		// if the player is moving right
		if (Input.GetAxis("Horizontal") == 1) {
			Vector2 movement = new Vector2(5.0f, 0);
			if (inTriggerRight == true) {
				movement = new Vector2(5.0f, 8.0f);
			}
			rb2d.AddForce(movement);
			animator.SetBool("isWalkingRight", true);
		} else {
			animator.SetBool("isWalkingRight", false);
		}
		// if the player pressed A
		if (Input.GetButtonDown("Fire1")) {
			if (isGrounded == true) {
				Vector2 movement = new Vector2(0, 300.0f);
				rb2d.AddForce(movement);
			}
		}
	}
}
