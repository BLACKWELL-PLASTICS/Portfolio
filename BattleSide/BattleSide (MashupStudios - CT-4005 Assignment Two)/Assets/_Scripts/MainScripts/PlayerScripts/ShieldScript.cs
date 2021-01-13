// Shield Script:
// Written by Iain Farlow Updated by Oliver Blackwell
// Created 29/04/2020
// Last Updated: 29/04/2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {
	float InvunrabiltyTime = 5.0f;

	// Update is called once per frame
	void Update() {
		InvunrabiltyTime -= Time.deltaTime;
		if (InvunrabiltyTime > 0.0f) {
			// this is set up to work with the Manager Singleton 
			if (gameObject.name == "Player1") {
                //Sets health script so player does not take damage
				Manager.instance.PlayerOneInvulnerable = true;
			} else if (gameObject.name == "Player2") {
				Manager.instance.PlayerTwoInvulnerable = true;
			} else if (gameObject.name == "Player3") {
				Manager.instance.PlayerThreeInvulnerable = true;
			} else if (gameObject.name == "Player4") {
				Manager.instance.PlayerFourInvulnerable = true;
			}
		} else {
			Manager.instance.PlayerOneInvulnerable = false;
			Manager.instance.PlayerTwoInvulnerable = false;
			Manager.instance.PlayerThreeInvulnerable = false;
			Manager.instance.PlayerFourInvulnerable = false;
			Destroy(this);
		}
	}
}
