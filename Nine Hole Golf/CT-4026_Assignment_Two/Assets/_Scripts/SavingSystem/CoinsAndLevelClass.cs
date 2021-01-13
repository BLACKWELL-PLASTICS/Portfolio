using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This means that the class and its contents can be saved
[System.Serializable]
public class CoinsAndLevelClass {
	// these are the two variables which are being saved
	public int playerLevel;
	public int playerCoins;

	// this class takes in the WonScript class and sets these member variables to the variables within the WonScript class
	public CoinsAndLevelClass(WonScript ws) {
		playerLevel = ws.pLevel;
		playerCoins = ws.pCoins;

	}
}
