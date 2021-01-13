using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WonScript : MonoBehaviour {
	// This script is called by the end flag of a course and if the player wins the luckyshot challenge
	// these variables had to be public so that the Coins and level class can access them for the save system to work
	public int pLevel;
	public int pCoins;

	public void Start() {
		// At the start the script trys to load the Coins and Level save file
		CoinsAndLevelClass tData = CLSaveSystem.LoadData();
		// we set the variables in this script to the loaded variables
		pLevel = tData.playerLevel;
		pCoins = tData.playerCoins;
	}

	public void SaveData() {
		// if the lucky shot scene is won, the player level goes up and 50 coins are added to the wallet
		++pLevel;
		pCoins += 50;
		// we then save the new numbers into the save file
		CLSaveSystem.SaveData(this);
		// and we return to the menu
		SceneManager.LoadScene("Menu");
	}

	public void CourseCompleted() {
		// if a course is completed the player level goes up and 200 coins are added to the wallet
		++pLevel;
		pCoins += 200;
		// we then save the new numbers into the save file
		CLSaveSystem.SaveData(this);
	}

	public void MakeAccount() {
		// this is called from the very first scene when the player sets their name their level and wallet are also created and saved 
		// so they can be acessed later on
		pLevel = 1;
		pCoins = 50;
		// we then save the original numbers into the save file
		CLSaveSystem.SaveData(this);
	}

	// PURCHASING BALLS IN THE STORE HAD TO BE DONE IN THIS SCRIPT BECAUSE OF THE CLASS TYPE
	// This function is called if the player has purchased the pink ball
	public void PurchasePinkBall() {
		if (pCoins >= 200) {
			// if the player has 200 coins or more in their wallet
			// we take those coins away and then save this
			pCoins -= 200;
			CLSaveSystem.SaveData(this);
		}
	}
	// This function is called if the player has purchased the yellow ball
	public void PurchaseYellowBall() {
		if (pCoins >= 200) {
			// if the player has 200 coins or more in their wallet
			// we take those coins away and then save this
			pCoins -= 200;
			CLSaveSystem.SaveData(this);
		}
	}
	// This function is called if the player has purchased the blue ball
	public void PurchaseBlueBall() {
		if (pCoins >= 200) {
			// if the player has 200 coins or more in their wallet
			// we take those coins away and then save this
			pCoins -= 200;
			CLSaveSystem.SaveData(this);
		}
	}
}
