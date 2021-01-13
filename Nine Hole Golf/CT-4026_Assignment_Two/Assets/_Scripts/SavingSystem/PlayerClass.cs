using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This means that the class and its contents can be saved
[System.Serializable]
public class PlayerClass {
	// this is the one variable which is being saved

	public string playerName;
	// this class takes in the SaveNameScript class and sets the member variable to the variable within the SaveNameScript class

	public PlayerClass(SaveNameScript name) {
		playerName = name.pName;
	}
}
