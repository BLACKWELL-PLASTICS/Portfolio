// Settings Screen Directory
// Written by Oliver Blackwell
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreenDirectory : MonoBehaviour {
	// Settings Screen
	[SerializeField]
	GameObject General;
	[SerializeField]
	GameObject Display;
	[SerializeField]
	GameObject Sound;

	// Back To Menu
	[SerializeField]
	GameObject mainMenu;

	// Update is called once per frame
	void Update() {
		// if A is pressed
		// else if B is pressed
		// else if X is pressed
		// else if Y is pressed
		if (Input.GetButtonDown("Fire1")) {
			// General settings show
			General.SetActive(true);
			Display.SetActive(false);
			Sound.SetActive(false);
		} else if (Input.GetButtonDown("Fire2")) {
			// Display settings show
			General.SetActive(false);
			Display.SetActive(true);
			Sound.SetActive(false);
		} else if (Input.GetButtonDown("Fire3")) {
			// Sound settings show
			General.SetActive(false);
			Display.SetActive(false);
			Sound.SetActive(true);
		} else if (Input.GetButtonDown("Jump")) {
			// return to menu
			mainMenu.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
