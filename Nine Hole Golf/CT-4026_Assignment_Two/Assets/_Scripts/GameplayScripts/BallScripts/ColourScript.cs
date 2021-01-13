using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourScript : MonoBehaviour {
	[SerializeField]
	Material ballColour;

	// Start is called before the first frame update
	void Start() {
		// we load the data from the save file from the Store Save file
		StoreClass data = SCSavingSystem.LoadData();
		// using this data we then change the default colour to the RGB values set here
		if (data.materialActive == 0) {
			ballColour.color = Color.white;
		} else if (data.materialActive == 1) {
			ballColour.color = new Color(255, 0, 211);
		} else if (data.materialActive == 2) {
			ballColour.color = new Color(255, 236, 0);
		} else if (data.materialActive == 3) {
			ballColour.color = new Color(0, 54, 255);
		}
	}

}
