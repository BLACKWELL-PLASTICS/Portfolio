using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class SaveNameScript : MonoBehaviour {
	[SerializeField]
	private Text Name;
	[SerializeField]
	private Text Check;

	public string pName;

	private void Start() {
		// In start we are checking if this file exists, if it does exist than we load the next scene
		string path = Application.persistentDataPath + "/playerstats.bin";

		if (File.Exists(path)) {
			SceneManager.LoadScene("Menu");

		}
	}
	
	public void MoveScene() {
		// If the file doesnt exist than we check if the player has entered a name into the input field
		if (Name.text == "") {
			// If they haven't display this text
			Check.text = "Make Sure You have Entered a Name!";
		} else {
			// If they have, we call SaveData and load the next scene
			SaveData();
			SceneManager.LoadScene("Menu");
		}
	}

	// In SaveData we are calling the SaveData fucntion within the SaveSystem which sets the pName variable to the inputfields string
	public void SaveData() {
		pName = Name.text;

		SaveSystem.SaveData(this);
	}
}
