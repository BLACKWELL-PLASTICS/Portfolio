// Grenade Script:
// Written by Iain Farlow. Updated by Oliver Blackwell & updated for new health system and controller support
// Created: 30 / 01 / 2020
// Last Updated: 17/05/2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneGrenadeScript : MonoBehaviour {
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
		// oliver blackwell - i edited this to work with controler 
		if (Input.GetAxis("Horizontal") == -1) {
			rightLeft = false;
		}
		if (Input.GetAxis("Horizontal") == 1) {
			rightLeft = true;
		}
        //If fire button pressed and grenade is not alread in scene
		if (Input.GetButton("Fire2") && GameObject.Find("Grenade" + this.gameObject.name.ToString()).GetComponent<Rigidbody2D>() == null) {
            //get player position
			float lXPos = this.gameObject.transform.position.x;
			float lYPos = this.gameObject.transform.position.y;
            //check if facing left or right
			if (rightLeft) {
                //move grendade to facing side of player
				gNade.transform.position = new Vector2(lXPos + 0.2f, lYPos);
                //if the grenade doesn't have the boom script attach it and set variables
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
        //if fire button is released and grendades doesnt have collider but does have boom script
		if (Input.GetButtonUp("Fire2") && GameObject.Find("Grenade" + this.gameObject.name.ToString()).GetComponent<CircleCollider2D>() == null && GameObject.Find("Grenade" + this.gameObject.name.ToString()).GetComponent<BoomScript>() != null) {
            //get player position
			float lXPos = this.gameObject.transform.position.x;
			float lYPos = this.gameObject.transform.position.y;
            //check direction of pler
			if (rightLeft) {
                //add collider, rigidbody and apply force to grenade
				gNade.AddComponent<CircleCollider2D>();
				gNade.GetComponent<CircleCollider2D>().radius = 1.5f;
				gNade.AddComponent<Rigidbody2D>();
				gNade.GetComponent<Rigidbody2D>().gameObject.SetActive(true);
				gNade.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
				Vector2 gMovement = new Vector2(5, 2);
				gNade.GetComponent<Rigidbody2D>().AddForce(gMovement * 100);
			} else {
				gNade.AddComponent<CircleCollider2D>();
				gNade.GetComponent<CircleCollider2D>().radius = 1.5f;
				gNade.AddComponent<Rigidbody2D>();
				gNade.GetComponent<Rigidbody2D>().gameObject.SetActive(true);
				gNade.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
				Vector2 gMovement = new Vector2(-5, 2);
				gNade.GetComponent<Rigidbody2D>().AddForce(gMovement * 100);
			}
		}
	}
}
