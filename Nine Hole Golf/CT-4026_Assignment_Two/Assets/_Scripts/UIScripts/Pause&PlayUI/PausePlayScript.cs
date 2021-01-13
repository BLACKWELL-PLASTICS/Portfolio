using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePlayScript : MonoBehaviour {
	// This is a simple script which allows the player to pause and play the game 
	[SerializeField]
	private Button Pause;

	[SerializeField]
	private Button Play;

	[SerializeField]
	private Text PauseText;

	[SerializeField]
	private Button ReturnToMenu;

	// When this script is activated at the start of the level the time scale is set to 1
	private void Start() {
		Time.timeScale = 1;
	}

	// when the pause button is pressed this function is called
	public void OnPause() {
		// Sets the time scale to 0 so nothing moves and there are no reactions taking place
		Time.timeScale = 0;
		// Changes the pause button to a play button
		Pause.gameObject.SetActive(false);
		Play.gameObject.SetActive(true);

		// activates Pause UI
		PauseText.gameObject.SetActive(true);
		ReturnToMenu.gameObject.SetActive(true);
	}

	// When the play button is pressed this function is called
	public void OnPlay() {
		// Time scale is reset to 1
		Time.timeScale = 1;
		// changes the play button back to a pause button
		Pause.gameObject.SetActive(true);
		Play.gameObject.SetActive(false);

		// turns off Pause UI
		PauseText.gameObject.SetActive(false);
		ReturnToMenu.gameObject.SetActive(false);
	}

}
