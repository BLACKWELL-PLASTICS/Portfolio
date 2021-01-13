// Three Player Won Script
// Written by Oliver Blackwell
// 24 / 05 / 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ThreePlayerWonScript : MonoBehaviour
{
	[SerializeField]
	GameObject WonScreen;

	[SerializeField]
	Text FirstPlace;
	[SerializeField]
	Text SecondPlace;
	[SerializeField]
	Text ThirdPlace;

	GameObject PlayerOne;
	GameObject PlayerTwo;
	GameObject PlayerThree;

	private void Start() {
		// This finds the player objects
		PlayerOne = GameObject.Find("Player");
		PlayerTwo = GameObject.Find("Player2");
		PlayerThree = GameObject.Find("Player3");
	}
	// Update is called once per frame
	void Update() {
		// if player 1 Dies first
			// If player 2 dies second
			// else if player 3 dies second
		// Else if Player 2 dies first
			// If player 1 dies second
			// else if player 3 dies second
		// else if player 3 dies first
			// if player 1 dies second
			// else if player 2 dies second
		if (Manager.instance.PlayerOneHP <= 0) {
			// Set text components
			ThirdPlace.text = "3rd Place - Player 1";
			// Destroy player 1
			Destroy(PlayerOne, 0.0f);
			if (Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerTwoHP <= 0) {
				// Set text components
				SecondPlace.text = "2nd Place - Player 2";
				// destroy player 2
				Destroy(PlayerTwo, 0.0f);
				FirstPlace.text  = "1st Place - Player 3";
				// won screen set active
				WonScreen.SetActive(true);
				// timescale set to 0
				Time.timeScale = 0.0f;
			} else if (Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerThreeHP <= 0) {
				// Set text components
				SecondPlace.text = "2nd Place - Player 3";
				// destroy player 3
				Destroy(PlayerThree, 0.0f);
				FirstPlace.text = "1st Place - Player 2";
				// won screen set active
				WonScreen.SetActive(true);
				// timescale set to 0
				Time.timeScale = 0.0f;
			}
		} else if (Manager.instance.PlayerTwoHP <= 0) {
			// Set text components
			ThirdPlace.text = "3rd Place - Player 2";
			// Destroy player 2
			Destroy(PlayerTwo, 0.0f);
			if (Manager.instance.PlayerTwoHP <= 0 && Manager.instance.PlayerOneHP <= 0) {
				// Set text components
				SecondPlace.text = "2nd Place - Player 1";
				// destroy player 1
				Destroy(PlayerOne, 0.0f);
				FirstPlace.text = "1st Place - Player 3";
				// won screen set active
				WonScreen.SetActive(true);
				// timescale set to 0
				Time.timeScale = 0.0f;
			} else if (Manager.instance.PlayerTwoHP <= 0 && Manager.instance.PlayerThreeHP <= 0) {
				// Set text components
				SecondPlace.text = "2nd Place - Player 3";
				// destroy player 3
				Destroy(PlayerThree, 0.0f);
				FirstPlace.text = "1st Place - Player 1";
				// won screen set active
				WonScreen.SetActive(true);
				// timescale set to 0
				Time.timeScale = 0.0f;
			}
		} else if (Manager.instance.PlayerThreeHP <= 0) {
			// Set text components
			ThirdPlace.text = "3rd Place - Player 3";
			// destroy player 3
			Destroy(PlayerThree, 0.0f);
			if (Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerOneHP <= 0) {
				// Set text components
				SecondPlace.text = "2nd Place - Player 1";
				// destroy player 1
				Destroy(PlayerOne, 0.0f);
				FirstPlace.text = "1st Place - Player 2";
				// won screen set active
				WonScreen.SetActive(true);
				// timescale set to 0
				Time.timeScale = 0.0f;
			} else if (Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerTwoHP <= 0) {
				// Set text components
				SecondPlace.text = "2nd Place - Player 2";
				// destroy player 2
				Destroy(PlayerTwo, 0.0f);
				FirstPlace.text = "1st Place - Player 1";
				// won screen set active
				WonScreen.SetActive(true);
				// timescale set to 0
				Time.timeScale = 0.0f;
			}
		}

		// if x is pressed and won screen is active
		if (Input.GetButtonDown("Fire3") && WonScreen.activeInHierarchy == true) {
			// load menu scene
			SceneManager.LoadScene(0);
			Time.timeScale = 1.0f;
		}
	}
}
