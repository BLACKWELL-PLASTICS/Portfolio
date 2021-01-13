// Player Input
// Written by Oliver Blackwell
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour {
	public int PlayerChoiceOne = 0;
	public int PlayerChoiceTwo = 0;
	public int PlayerChoiceThree = 0;
	public int PlayerChoiceFour = 0;
	GameObject DNDL;
	int playersActive;

	private void Start() {
		DNDL = GameObject.FindGameObjectWithTag("DNDL");
		playersActive = DNDL.GetComponent<ControllersActive>().playersActive;
		Debug.Log(playersActive.ToString());
	}

	// Update is called once per frame
	void Update() {
		// if A is pressed
		// else if B is pressed
		// else if x is pressed
		// else if y is pressed
		if (Input.GetButton("Fire1")) {
			PlayerChoiceOne = 1;
		} else if (Input.GetButton("Fire2")) {
			PlayerChoiceOne = 2;
		} else if (Input.GetButton("Fire3")) {
			PlayerChoiceOne = 3;
		} else if (Input.GetButton("Jump")) {
			PlayerChoiceOne = 4;
		}
		// if A is pressed
		// else if B is pressed
		// else if x is pressed
		// else if y is pressed
		if (Input.GetButton("Fire1_JoyOne")) {
			PlayerChoiceTwo = 1;
		} else if (Input.GetButton("Fire2_JoyOne")) {
			PlayerChoiceTwo = 2;
		} else if (Input.GetButton("Fire3_JoyOne")) {
			PlayerChoiceTwo = 3;
		} else if (Input.GetButton("Jump_JoyOne")) {
			PlayerChoiceTwo = 4;
		}

		// if A is pressed
		// else if B is pressed
		// else if x is pressed
		// else if y is pressed
		if (Input.GetButton("Fire1_JoyTwo")) {
			PlayerChoiceThree = 1;
		} else if (Input.GetButton("Fire2_JoyTwo")) {
			PlayerChoiceThree = 2;
		} else if (Input.GetButton("Fire3_JoyTwo")) {
			PlayerChoiceThree = 3;
		} else if (Input.GetButton("Jump_JoyTwo")) {
			PlayerChoiceThree = 4;
		}

		// if A is pressed
		// else if B is pressed
		// else if x is pressed
		// else if y is pressed
		if (Input.GetButton("Fire1_JoyThree")) {
			PlayerChoiceFour = 1;
		} else if (Input.GetButton("Fire2_JoyThree")) {
			PlayerChoiceFour = 2;
		} else if (Input.GetButton("Fire3_JoyThree")) {
			PlayerChoiceFour = 3;
		} else if (Input.GetButton("Jump_JoyThree")) {
			PlayerChoiceFour = 4;
		}

		// if all choices have been made and the players active is set to 4, save the choices and load a four player level
		// else if all choices have been made and the players active is set to 3, save the choices and load a three player level
		// else if all choices have been made and the players active is set to 2, save the choices and load a two player level
		if (PlayerChoiceOne != 0 && PlayerChoiceTwo != 0 && PlayerChoiceThree != 0 && PlayerChoiceFour != 0 && playersActive == 4) {
			Save();
			LoadFourPlayer();
		} else if (PlayerChoiceOne != 0 && PlayerChoiceTwo != 0 && PlayerChoiceThree != 0 && PlayerChoiceFour == 0 && playersActive == 3) {
			Save();
			LoadThreePlayer();
		} else if (PlayerChoiceOne != 0 && PlayerChoiceTwo != 0 && PlayerChoiceThree == 0 && PlayerChoiceFour == 0 && playersActive == 2) {
			Save();
			LoadTwoPlayer();
		}
	}

	void Save() {
		// Calls the Saving systems save function and save these variables
		PlayerChoiceOne = PlayerChoiceOne * 1;
		PlayerChoiceTwo = PlayerChoiceTwo * 1;
		PlayerChoiceThree = PlayerChoiceThree * 1;
		PlayerChoiceFour = PlayerChoiceFour * 1;
		ChoiceSavingSystem.SaveSettings(this);
	}
	void LoadTwoPlayer() {
		// Creates a random int 
		int i = Random.Range(2, 4);
		// Destroy the DNDL object
		Destroy(DNDL, 0.0f);
		// Loads the scene depending on the random int
		SceneManager.LoadScene(i);
	}
	void LoadThreePlayer() {
		// Creates a random int 
		int i = Random.Range(5, 7);
		// Destroy the DNDL object
		Destroy(DNDL, 0.0f);
		// Loads the scene depending on the random int
		SceneManager.LoadScene(i);
	}
	void LoadFourPlayer() {
		// Creates a random int 
		int i = Random.Range(8, 10);
		// Destroy the DNDL object
		Destroy(DNDL, 0.0f);
		// Loads the scene depending on the random int
		SceneManager.LoadScene(i);
	}
}
