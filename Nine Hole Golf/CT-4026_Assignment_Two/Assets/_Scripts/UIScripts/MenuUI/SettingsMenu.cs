using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {
	[SerializeField]
	private GameObject MainMenu;
	[SerializeField]
	private GameObject SettingsScreen;
	// This turns on the settings screen when the settings button is pressed
	public void Settings() {
		MainMenu.SetActive(false);
		SettingsScreen.SetActive(true);
	}
	// this turns off the settings screen and turns on the main menu screen
	public void Return() {
		MainMenu.SetActive(true);
		SettingsScreen.SetActive(false);
	}
}
