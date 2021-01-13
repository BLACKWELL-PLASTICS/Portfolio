// Pause Play Script
// Written by Oliver Blackwell
// Created 24 / 05 / 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePlayScript : MonoBehaviour {
	[SerializeField]
	GameObject PauseScreen;

	// Start is called before the first frame update
	void Start() {
		PauseScreen.SetActive(false);
	}

	// Update is called once per frame
	void Update() {
		// if the pause button is pressed and the pause screen isn't active, pause the time, and activate the pause screen
		// else if the pause button is pressed and the pause screen is active, set time equal to 1, and deactivate the pause screen
		if (Input.GetButtonDown("Submit") && PauseScreen.activeInHierarchy == false) {
			// Pause screen set active
			PauseScreen.SetActive(true);
			// pause time
			Time.timeScale = 0.0f;
		} else if (Input.GetButtonDown("Submit") && PauseScreen.activeInHierarchy == true) {
			// Pause screen set false
			PauseScreen.SetActive(false);
			// Time back to normal
			Time.timeScale = 1.0f;
		}

		// if the pause screen is active, and the A button is pressed, reload the scene and set time euqal to 1
		if (Input.GetButtonDown("Fire1") && PauseScreen.activeInHierarchy == true) {
			// Reload this scene
			SceneManager.LoadScene(SceneManager.GetActiveScene().name.ToString());
			// Time to normal
			Time.timeScale = 1.0f;
		}
		// if the pause screen is active, and the B button is pressed, load the menu scene and set time equal to 1
		if (Input.GetButtonDown("Fire2") && PauseScreen.activeInHierarchy == true) {
			// load menu scene
			SceneManager.LoadScene(0);
			// Time back to normal
			Time.timeScale = 1.0f;
		}

	}
}
