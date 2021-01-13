using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour {
	// This is the store script 
	[SerializeField]
	GameObject Menu;

	[SerializeField]
	GameObject Settings;

	[SerializeField]
	GameObject Store;

	[SerializeField]
	Button PinkBall;

	[SerializeField]
	Button YellowBall;

	[SerializeField]
	Button BlueBall;

	[SerializeField]
	Dropdown ActiveMaterial;

	public int materialActive;

	public bool pinkBall;
	public bool yellowBall;
	public bool blueBall;

	public int pCoins;

	public void Start() {
		// At the start i am loading the player wallet to access the amount of coins stored
		CoinsAndLevelClass tData = CLSaveSystem.LoadData();
		pCoins = tData.playerCoins;
		// If the player coins is less than 200, all the buttons are not interactable
		if (pCoins < 200) {
			PinkBall.interactable = false;
			YellowBall.interactable = false;
			BlueBall.interactable = false;
		}

		StoreClass data = SCSavingSystem.LoadData();
		// i then load the store data
		if (data == null) {
			// if there is no store data you cannot interact with the dropdown list
			ActiveMaterial.interactable = false;
			// the material active variable is set to 0
			materialActive = 0;
			// and we create the save file
			SCSavingSystem.SaveData(this);
		}

		// if it is not null these variables are set
		pinkBall = data.pinkBall;
		yellowBall = data.yellowBall;
		blueBall = data.blueBall;
		materialActive = data.materialActive;
		// these variables then change the material which is being used
		if (materialActive == 0) {
			ActiveMaterial.value = 0;
		} else if (materialActive == 1) {
			ActiveMaterial.value = 1;
		} else if (materialActive == 2) {
			ActiveMaterial.value = 2;
		} else if (materialActive == 3) {
			ActiveMaterial.value = 3;
		}
	}
	// this is called when the player returns to the menu
	public void Return() {

		Store.SetActive(false);
		Settings.SetActive(false);
		Menu.SetActive(true);
	}
	// this is called when the player opens the stor
	public void Open() {

		Store.SetActive(true);
		Settings.SetActive(false);
		Menu.SetActive(false);
	}

	public void Update() {
		// at the start of every frame we load the coins and level aswell as the store data
		CoinsAndLevelClass tData = CLSaveSystem.LoadData();
		pCoins = tData.playerCoins;

		StoreClass data = SCSavingSystem.LoadData();

		if (data != null) {
			// if there is no store data we stop the user from using the dropdown
			ActiveMaterial.interactable = true;
		}
		// else set the varaibles to to true or false if they have been bought
		pinkBall = data.pinkBall;
		yellowBall = data.yellowBall;
		blueBall = data.blueBall;

		if (pCoins < 200) {
		// if the player cannot buy the balls due to lack of money they cannot interact with the buttons
			PinkBall.interactable = false;
			YellowBall.interactable = false;
			BlueBall.interactable = false;
		}
		// we then save what the active material is
		if (ActiveMaterial.value == 0) {
			materialActive = 0;
			SCSavingSystem.SaveData(this);
		}
		if (ActiveMaterial.value == 1 && pinkBall == true) {
			materialActive = 1;
			SCSavingSystem.SaveData(this);
		}
		if (ActiveMaterial.value == 2 && yellowBall == true) {
			materialActive = 2;
			SCSavingSystem.SaveData(this);
		}
		if (ActiveMaterial.value == 3 && blueBall == true) {
			materialActive = 3;
			SCSavingSystem.SaveData(this);
		}
		// and then after saving the material active variable we set the dropdown value to display which one is active
		if (materialActive == 0) {
			ActiveMaterial.value = 0;
		} else if (materialActive == 1) {
			ActiveMaterial.value = 1;
		} else if (materialActive == 2) {
			ActiveMaterial.value = 2;
		} else if (materialActive == 3) {
			ActiveMaterial.value = 3;
		}
	}
	// this function is called when the pink ball is bought
	public void PinkBallBought() {
		// we set the pinkball bool to true and then Save this
		pinkBall = true;
		SCSavingSystem.SaveData(this);
	}
	public void YellowBallBought() {
		// we set the yellowball bool to true and then Save this
		yellowBall = true;
		SCSavingSystem.SaveData(this);
	}
	public void BlueBallBought() {
		// we set the blueball bool to true and then Save this
		blueBall = true;
		SCSavingSystem.SaveData(this);
	}
}
