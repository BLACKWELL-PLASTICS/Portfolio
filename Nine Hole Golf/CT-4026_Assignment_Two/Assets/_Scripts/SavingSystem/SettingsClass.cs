using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This means that the class and its contents can be saved
[System.Serializable]
public class SettingsClass {
	// this is the one variable which is being saved
	public float brightness;

	// this class takes in the SliderScripts class and sets the member variable to the variable within the SliderScripts class
	public SettingsClass(SliderScripts slider) {
		brightness = slider.brightnessLevel;
	}
}
