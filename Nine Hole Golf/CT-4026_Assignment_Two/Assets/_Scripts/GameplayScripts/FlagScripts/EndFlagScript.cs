using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndFlagScript : MonoBehaviour {
	// This is the script for the end flag

	[SerializeField]
	private GameObject WonScreen;

	// Update is called once per frame
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			// when the ball enters the end flag, set the timescale to 0 and set the wonscreen to active
			Time.timeScale = 0;
			WonScreen.SetActive(true);
		}
	}
}
