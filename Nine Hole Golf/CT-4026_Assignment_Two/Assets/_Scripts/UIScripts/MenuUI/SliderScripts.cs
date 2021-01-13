using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScripts : MonoBehaviour {
	[SerializeField]
	private Slider brightnessSlider;

	public float brightnessLevel = 0.0f;

	private float brightnessLoaded;

	void Start() {
		// At the start the script trys to load the settings save file
		SettingsClass data = SettingsSaveSystem.LoadData();
		brightnessLoaded = data.brightness;
		// if there is a save file, then the slider value is set to the variable which is loaded from the save file
		brightnessSlider.value = brightnessLoaded;

	}

	// When the slider value is changed this function is called
	public void SaveData() {
		// we set the public variable in the settings class of brightnessLevel to the sliders value
		brightnessLevel = brightnessSlider.value;
		// and call the SaveData function of the SettingsSaveSystem class
		SettingsSaveSystem.SaveData(this);
	}
}
