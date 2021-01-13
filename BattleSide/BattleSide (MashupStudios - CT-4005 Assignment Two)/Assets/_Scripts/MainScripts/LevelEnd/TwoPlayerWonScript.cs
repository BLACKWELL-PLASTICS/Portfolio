// Two Player Won Script
// Written by Oliver Blackwell
// 24 / 05 / 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TwoPlayerWonScript : MonoBehaviour
{
	[SerializeField]
	GameObject WonScreen;

	[SerializeField]
	Text FirstPlace;
	[SerializeField]
	Text SecondPlace;

	GameObject PlayerOne;
	GameObject PlayerTwo;
	private void Start() {
		// This finds the players
		PlayerOne = GameObject.Find("Player");
		PlayerTwo = GameObject.Find("Player2");
	}
	// Update is called once per frame
	void Update()
    {
		// if Player 1 dies first
		// else if Player 2 dies first
		if (Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerTwoHP > 0) {
			// Destroy Player One
			Destroy(PlayerOne, 0.0f);
			// Won Screen Set True
			WonScreen.SetActive(true);
			// Set text components
			FirstPlace.text = "1st Place - Player 2";
			SecondPlace.text = "2nd Place - Player 1";
			// Set Timescale to 0
			Time.timeScale = 0.0f;
		} else if (Manager.instance.PlayerTwoHP <= 0 && Manager.instance.PlayerOneHP > 0) {
			// Destroy Player Two
			Destroy(PlayerTwo, 0.0f);
			// Won Screen Set true
			WonScreen.SetActive(true);
			// Set text components
			FirstPlace.text = "1st Place - Player 1";
			SecondPlace.text = "2nd Place - Player 2";
			// Set Timescale to 0
			Time.timeScale = 0.0f;
		}

		// if x is pressed and won screen is active
		if (Input.GetButtonDown("Fire2") && WonScreen.activeInHierarchy == true) {
			// Load Menu Scene
			SceneManager.LoadScene(0);
			Time.timeScale = 1.0f;
		}
	}
}
