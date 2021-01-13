// Settings Script
// Written by Oliver Blackwell
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour {
	public Toggle vSync;
	public bool is_vSync;

	public Toggle FPSCounter;
	public bool is_FPSCounter;

	public Slider volumeSlider;
	public float volume;

	string ResToString(Resolution res) {
		return res.width + " x " + res.height;
	}

	private void Update() {
		// if the vSync toggle is on
		// else, if the vSync toggle is off
		if (vSync.isOn == true) {
			//isVSync is true
			is_vSync = true;
		} else {
			//isVSync is false
			is_vSync = false;
		}
		// if the FPS Counter toggle is on
		// else, if the FPS Counter toggle is off
		if (FPSCounter.isOn == true) {
			// isFPSCounter is true
			is_FPSCounter = true;
		} else {
			// isFPSCounter is false
			is_FPSCounter = false;
		}

		// volume equals volumeslider value
		volume = volumeSlider.value;

		LoadSettings();
	}

	// saves the isFPSCounter bool
	public void SaveFPSCounter() {
		if (FPSCounter.isOn == true) {
			is_FPSCounter = true;
		} else if (FPSCounter.isOn == false) {
			is_FPSCounter = false;
		}
		SettingsSaveSystem.SaveSettings(this);
	}
	// saves the isVsync bool

	public void SaveVsync() {
		if (vSync.isOn == true) {
			is_vSync = true;
		} else if (vSync.isOn == false) {
			is_vSync = false;
		}
		SettingsSaveSystem.SaveSettings(this);
	}
	// Saves the volume value
	public void SaveVolume() {
		volume = volumeSlider.value;
		SettingsSaveSystem.SaveSettings(this);
	}
	// loads the settings
	public void LoadSettings() {
		SettingsData data = SettingsSaveSystem.LoadData();
		vSync.isOn = data.m_vSync;
		FPSCounter.isOn = data.m_FPSCounter;
		volumeSlider.value = data.m_volume;
	}
}
