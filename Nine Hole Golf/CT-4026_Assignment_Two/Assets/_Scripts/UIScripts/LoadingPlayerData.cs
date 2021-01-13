using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPlayerData : MonoBehaviour {
	// This script loads the Player Save data including their name, level and coins they have earned
	[SerializeField]
	private Text Name;

	[SerializeField]
	private Text Level;

	[SerializeField]
	private Text Coins;

	[SerializeField]
	Button SpaceLevel;

	[SerializeField]
	Button JungleLevel;

	void Update() {
		// This loads all of the data which has been saved in the player save file
		PlayerClass data = SaveSystem.LoadData();
		// this loads all of the data which has been saved in the coins and level save file
		CoinsAndLevelClass tData = CLSaveSystem.LoadData();

		// This sets the text variables to the vairables loaded from the save files
		Name.text = "Name : " + data.playerName;
		Level.text = "Level : " + tData.playerLevel;
		Coins.text = "Coins : " + tData.playerCoins;

		// This changes the availability of levels due to the player level
		// This is because the higher the level the more difficult they are
		if (tData.playerLevel >= 1) {
			SpaceLevel.interactable = true;
		} else {
			SpaceLevel.interactable = false;
		}
		if (tData.playerLevel >= 2) {
			JungleLevel.interactable = true;
		} else {
			JungleLevel.interactable = false;
		}
	}

}
