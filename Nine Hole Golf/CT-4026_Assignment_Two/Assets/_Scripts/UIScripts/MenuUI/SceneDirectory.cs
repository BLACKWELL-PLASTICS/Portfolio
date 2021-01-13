using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirectory : MonoBehaviour {
	// This loads the Space Scene
	public void SpaceCourse() {
		SceneManager.LoadScene(3);
	}

	// This loads the Mountain scene
	public void MountainCourse() {
		SceneManager.LoadScene(4);
	}
	
	// This loads the Lucky Shot Scene
	public void LuckyShot() {
		SceneManager.LoadScene(2);
	}

	// This loads the main menu scene and sets the timescale to 1 to make sure that the player can use the buttons
	public void Menu() {
		SceneManager.LoadScene("Menu");
		Time.timeScale = 1;
	}
	public void Quit() {
		Debug.Log("QUIT");
		Application.Quit(0);
	}
}
