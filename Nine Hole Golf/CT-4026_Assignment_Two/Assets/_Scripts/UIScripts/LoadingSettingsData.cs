using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadingSettingsData : MonoBehaviour {
	// This script loads the settings data and changes the brightness of the scene by accessing the light within the scene and changing their intensity
	private float brightnessLoaded;

	[SerializeField]
	private Light sceneLight;

	void Start() {
		// This loads all of the data which has been saved
		SettingsClass data = SettingsSaveSystem.LoadData();
		brightnessLoaded = data.brightness;
		// we are collecting the light object
		sceneLight = FindObjectOfType<Light>();
		// and changing its intensity to the variable loaded from the save file
		sceneLight.intensity = brightnessLoaded;

	}

}
