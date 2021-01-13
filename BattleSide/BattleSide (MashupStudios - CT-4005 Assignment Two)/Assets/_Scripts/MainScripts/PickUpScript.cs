// Pick Up Script:
// Written by Iain Farlow, Edited by Oliver Blackwell
// Created 29/04/2020
// Last Updated: 25/05/2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour {

	GameObject[] TPObjects;

    //Check if trigger is entered
	void OnTriggerEnter2D(Collider2D collider) {
        //Check if object is a player object
		if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "Player2" || collider.gameObject.tag == "Player3" || collider.gameObject.tag == "Player3") {
            //Check that the pickup is
			if (this.gameObject.name == "Bullets") {
                //Get the collided player's inventory script and increade bullet count
				collider.gameObject.GetComponent<InventoryScript>().Bullets += 3;
                //Restrict max bullets to 10
				if (collider.gameObject.GetComponent<InventoryScript>().Bullets > 10) {
					collider.gameObject.GetComponent<InventoryScript>().Bullets = 10;
				}

                //Destroy scripts and object
				GameObject Tp = GameObject.Find(this.tag.ToString());
				Destroy(Tp.GetComponent<TeleporterScript>());
				Destroy(gameObject);
			} else if (this.gameObject.name == "Shield") { //If sheild
				if (collider.gameObject.GetComponent<ShieldScript>() == null) {
                    //Add shield script
					collider.gameObject.AddComponent<ShieldScript>();
					GameObject Tp = GameObject.Find(this.tag.ToString());
					Destroy(Tp.GetComponent<TeleporterScript>());
					Destroy(gameObject);
				}
			} else if (this.gameObject.name == "Health") {
				// Oliver Blackwell - editied to work with Singleton
				// if the player 1 picks up the health pickup
				// else if the player 2 picks up the health pickup
				// else if the player 3 picks up the health pickup
				// else if the player 4 picks up the health pickup
				if (collider.gameObject.name == "Player1") {
					// add 30 to the players health 
					Manager.instance.PlayerOneHP += 30.0f;
					// if the players health is above 100
					if (Manager.instance.PlayerOneHP > 100.0f) {
						// set the players health to 100
						Manager.instance.PlayerOneHP = 100.0f;
					}
				} else if (collider.gameObject.name == "Player2") {
					// add 30 to the players health 
					Manager.instance.PlayerTwoHP += 30.0f;
					// if the players health is above 100
					if (Manager.instance.PlayerTwoHP > 100.0f) {
						// set the players health to 100
						Manager.instance.PlayerTwoHP = 100.0f;
					}
				} else if (collider.gameObject.name == "Player3") {
					// add 30 to the players health 
					Manager.instance.PlayerThreeHP += 30.0f;
					// if the players health is above 100
					if (Manager.instance.PlayerThreeHP > 100.0f) {
						// set the players health to 100
						Manager.instance.PlayerThreeHP = 100.0f;
					}
				} else if (collider.gameObject.name == "Player 4") {
					// add 30 to the players health 
					Manager.instance.PlayerFourHP += 30.0f;
					// if the players health is above 100
					if (Manager.instance.PlayerFourHP > 100.0f) {
						// set the players health to 100
						Manager.instance.PlayerFourHP = 100.0f;
					}
				}

				GameObject Tp = GameObject.Find(this.tag.ToString());
				Destroy(Tp.GetComponent<TeleporterScript>());
				Destroy(gameObject);

			} else if (this.gameObject.name == "Gun") {
                //Set the current weapon to gun
				collider.gameObject.GetComponent<InventoryScript>().currentWeapon = "Gun";
				GameObject Tp = GameObject.Find(this.tag.ToString());
				Destroy(Tp.GetComponent<TeleporterScript>());
				Destroy(gameObject);
			} else if (this.gameObject.gameObject.name == "Knife") {
                //Set the current weapon to knife
				collider.gameObject.GetComponent<InventoryScript>().currentWeapon = "Knife";
				GameObject Tp = GameObject.Find(this.tag.ToString());
				Destroy(Tp.GetComponent<TeleporterScript>());
				Destroy(gameObject);
			}

            //Destroy the related pickup objects
			TPObjects = GameObject.FindGameObjectsWithTag(this.gameObject.tag);
			foreach (GameObject TPObject in TPObjects) {
				Destroy(TPObject);
			}
		}
	}
}
