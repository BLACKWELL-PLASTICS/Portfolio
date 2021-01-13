// Controllers Active Script:
// Written by Oliver Blackwell
// Created : 23 / 05 / 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllersActive : MonoBehaviour {
	[SerializeField]
	Button play;
	[SerializeField]
	Text txt_playersActive;

	// Stops the variable being seen in the Unity Editor
	[System.NonSerialized]
	public int playersActive = 1;

	// bools checking on how many players are active
	bool playerTwoActive = false;
	bool playerThreeActive = false;
	bool playerFourActive = false;

	// Start is called before the first frame update
	void Start() {
		// the text is set to show how many players are active
		txt_playersActive.text = playersActive.ToString() + " : Players Active";
		// play button is set to uninteractible
		play.interactable = false;
	}

	// Update is called once per frame
	void Update() {
		// if a second controller clicks A
		// else if a third controller clicks A
		// else if a fourth controller clicks A
		// else if playersActive is bigger or equal to 2 
		if (Input.GetButtonDown("Fire1_JoyOne") && playerTwoActive == false) {
			// Add one to players active
			playersActive++;
			// the play button becomes interactible
			play.interactable = true;
			// playerTwo bool is set to true
			playerTwoActive = true;
		} else if (Input.GetButtonDown("Fire1_JoyTwo") && playerThreeActive == false) {
			// add one to players active
			playersActive++;
			// playerthree bool is set to true
			playerThreeActive = true;
		} else if (Input.GetButtonDown("Fire1_JoyThree") && playerFourActive == false) {
			// add one to players active
			playersActive++;
			// playerfour bool is set to true
			playerFourActive = true;
		} else if (playersActive >= 2) {
			// the play button becomes interactible
			play.interactable = true;
		}
		// the text is set to show how many players are active
		txt_playersActive.text = playersActive.ToString() + " : Players Active";
	}
}