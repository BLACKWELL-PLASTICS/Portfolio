// Grenade Script 3
// Written by Oliver Blackwell & updated for new health system and controller support
// Base code by Iain Farlow
// Created 17/05/2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Comments are in playerOneGrendadescript
//Difference being the gameobject the script is orientated arround
//Controls are different
public class PlayerThreeGrenadeScript : MonoBehaviour {
	public string left;
	public string right;
	public GameObject grenadePrfb;
	public GameObject Explosion;

	private bool rightLeft = true;

	GameObject gNade;
	Vector2 StoragePos;

	void Start() {
		float lXPos = this.gameObject.transform.position.x;
		float lYPos = this.gameObject.transform.position.y;
		StoragePos = new Vector2(lXPos, lYPos + 30.0f);
		gNade = (GameObject)Instantiate(grenadePrfb, StoragePos, Quaternion.identity);
		gNade.name = "Grenade" + this.name.ToString();
	}

	void Update() {
		if (Input.GetAxis("Horizontal_JoyTwo") == -1) {
			rightLeft = false;
		}
		if (Input.GetAxis("Horizontal_JoyTwo") == 1) {
			rightLeft = true;
		}
		if (Input.GetButton("Fire2_JoyTwo") && GameObject.Find("Grenade" + this.gameObject.name.ToString()).GetComponent<Rigidbody2D>() == null) {
			float lXPos = this.gameObject.transform.position.x;
			float lYPos = this.gameObject.transform.position.y;
			if (rightLeft) {
				gNade.transform.position = new Vector2(lXPos + 0.2f, lYPos);
				if (GameObject.Find("Grenade" + this.name.ToString()).GetComponent<BoomScript>() == null) {
					gNade.AddComponent<BoomScript>();
					gNade.GetComponent<BoomScript>().storagePosition = StoragePos;
					gNade.GetComponent<BoomScript>().Explosion = Explosion;
				}
			} else {
				gNade.transform.position = new Vector2(lXPos - 0.2f, lYPos);
				if (GameObject.Find("Grenade" + this.name.ToString()).GetComponent<BoomScript>() == null) {
					gNade.AddComponent<BoomScript>();
					gNade.GetComponent<BoomScript>().storagePosition = StoragePos;
					gNade.GetComponent<BoomScript>().Explosion = Explosion;
				}
			}
		}
		if (Input.GetButtonUp("Fire2_JoyTwo")) {
			float lXPos = this.gameObject.transform.position.x;
			float lYPos = this.gameObject.transform.position.y;
			if (rightLeft) {
				gNade.AddComponent<CircleCollider2D>();
				gNade.GetComponent<CircleCollider2D>().radius = 1.5f;
				gNade.AddComponent<Rigidbody2D>();
				gNade.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
				Vector2 gMovement = new Vector2(5, 2);
				gNade.GetComponent<Rigidbody2D>().AddForce(gMovement * 100);
			} else {
				gNade.AddComponent<CircleCollider2D>();
				gNade.GetComponent<CircleCollider2D>().radius = 1.5f;
				gNade.AddComponent<Rigidbody2D>();
				gNade.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
				Vector2 gMovement = new Vector2(-5, 2);
				gNade.GetComponent<Rigidbody2D>().AddForce(gMovement * 100);
			}
		}
	}
}
