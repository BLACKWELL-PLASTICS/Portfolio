// Character Controler 3 Script:
// Created by Oliver Blackwell & updated for controllers
//Base code by Iain Farlow for keyboard
// Created 12/05/2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlerThreeScript : MonoBehaviour {
	private Rigidbody2D rb2d;

	public bool inTriggerRight = false;
	public bool inTriggerLeft = false;
	public bool isGrounded = false;

	Animator animator;

	void Start() {
		// Gets the players rigidbody
		rb2d = GetComponent<Rigidbody2D>();
		// gets the players animator
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
		// if the player 3 is moving left
		if (Input.GetAxis("Horizontal_JoyTwo") == -1) {
			Vector2 movement = new Vector2(-5.0f, 0);
			if (inTriggerLeft == true) {
				movement = new Vector2(-5.0f, 8.0f);
			}
			rb2d.AddForce(movement);
			animator.SetBool("isWalkingLeft", true);
		} else {
			animator.SetBool("isWalkingLeft", false);
		}
		// if the player 3 is moving right
		if (Input.GetAxis("Horizontal_JoyTwo") == 1) {
			Vector2 movement = new Vector2(5.0f, 0);
			if (inTriggerRight == true) {
				movement = new Vector2(5.0f, 8.0f);
			}
			rb2d.AddForce(movement);
			animator.SetBool("isWalkingRight", true);
		} else {
			animator.SetBool("isWalkingRight", false);
		}
		// if the player 3 pressed A
		if (Input.GetButtonDown("Fire1_JoyTwo")) {
			if (isGrounded == true) {
				Vector2 movement = new Vector2(0, 300.0f);
				rb2d.AddForce(movement);
			}
		}
	}
}
