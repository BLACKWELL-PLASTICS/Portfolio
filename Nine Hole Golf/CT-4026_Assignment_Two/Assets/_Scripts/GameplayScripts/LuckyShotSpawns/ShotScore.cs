using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScore : MonoBehaviour {
	[SerializeField]
	GameObject WonScreen;

	[SerializeField]
	GameObject LossScreen;

	private int counter = 0;

	// if the ball collides into the pad then set the won screen to active
	// and set the timescale to 0 so there can be no more input to the ball
	public void OnTriggerEnter(Collider other) {
		WonScreen.SetActive(true);
		Time.timeScale = 0;

	}

	private void Update() {
		// if there is an click on screen, the counter increases
		if (Input.GetMouseButtonUp(0)) {
			counter++;
		}
		// if the counter is at 2, and the wonscreen isnt active
		if (counter == 2 && WonScreen.activeInHierarchy == false) {
			// set timescale to 0 and set the loss screen to inactive
			Time.timeScale = 0;
			LossScreen.SetActive(true);
		}
	}
}
