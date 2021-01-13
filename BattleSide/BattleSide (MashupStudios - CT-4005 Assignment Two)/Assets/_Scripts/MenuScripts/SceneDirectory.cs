// Scene Directory Script:
// Written by Oliver Blackwell
// Last Updated : 20 / 05 / 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneDirectory : MonoBehaviour {
	[SerializeField]
	Button play;

	[SerializeField]
	GameObject MainMenu;
	[SerializeField]
	GameObject SettingsScreen;
	[SerializeField]
	GameObject DNDL;


	void Update() {
		// if the lead player presses A and the play button is interactible
		// else if the lead player presses B
		// else if the lead player presses Y
		if (Input.GetButtonDown("Fire1") && play.interactable == true) {
			// Dont Destory this object on load
			DontDestroyOnLoad(DNDL);
			// load character selection screen
			SceneManager.LoadScene(1);
		} else if (Input.GetButtonDown("Fire2")) {
			// settings scren is activated
			SettingsScreen.SetActive(true);
			// main menu screen is deactivated
			MainMenu.SetActive(false);
		} else if (Input.GetButtonDown("Jump")) {
			// send a debug message
			Debug.Log("QUIT GAME");
			// Quit the application
			Application.Quit(0);
		}
	}

	// Returns to Menu from character selection
	public void ReturnToMenu() {
		SceneManager.LoadScene(0);
	}

}
