using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingStoreScript : MonoBehaviour {
	// These bool variables get set to whethere the player has bought the colour ball yet
	bool pink;
	bool yellow;
	bool blue;

	// These are the buttons which get shown depending on if the player owns the ball
	[SerializeField]
	private Button Pink;

	[SerializeField]
	private Button Yellow;

	[SerializeField]
	private Button Blue;

	[SerializeField]
	private Button PinkDisabled;

	[SerializeField]
	private Button YellowDisabled;

	[SerializeField]
	private Button BlueDisabled;


	void Update() {
		// This loads all of the data which has been saved
		StoreClass data = SCSavingSystem.LoadData();
		pink = data.pinkBall;
		yellow = data.yellowBall;
		blue = data.blueBall;
		// We are individually checking if the player owns these colour balls
		if (pink == true) {
			// If the pink ball has been purchased set the pink button to false and the disabled button to active
			// This stops the player from purchasing that colour again
			Pink.gameObject.SetActive(false);
			PinkDisabled.gameObject.SetActive(true);
		}
		if (yellow == true) {
			// If the yellow ball has been purchased set the yellow button to false and the disabled button to active
			// This stops the player from purchasing that colour again
			Yellow.gameObject.SetActive(false);
			YellowDisabled.gameObject.SetActive(true);
		}
		if (blue == true) {
			// If the blue ball has been purchased set the blue button to false and the disabled button to active
			// This stops the player from purchasing that colour again
			Blue.gameObject.SetActive(false);
			BlueDisabled.gameObject.SetActive(true);
		}
	}

}
