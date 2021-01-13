// Inventory Script:
// Rewritten by Oliver Blackwell
// Created 29/04/2020
// Last Updated: 20/05/2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour {
	public string currentWeapon;
	public int Bullets;

	public GameObject Gun;
	public GameObject Knife;

	void Update() {
		// if the current weapon is a knife
		if (currentWeapon == "Knife") {
			// knife object is set to true
			Knife.SetActive(true);
			// gun object is set to false
			Gun.SetActive(false);
		}

		// if the current weapon is a gun
		if (currentWeapon == "Gun") {
			// gun object is set to true
			Gun.SetActive(true);
			// knife object is set to false
			Knife.SetActive(false);
		}
	}
}
