// Activate Settings
// Written by Oliver Blackwell
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateSettings : MonoBehaviour {
	[SerializeField]
	public Text FPSCounter;
	private int targetVSync = 30;
	private int targetNormal = 60;
	private int avgFrameRate;

	// Start is called before the first frame update
	public void Start() {
		SettingsData data = SettingsSaveSystem.LoadData();
		// VSync - Setting FPS targets
		if (data.m_vSync == true) {
			QualitySettings.vSyncCount = 1;
			Application.targetFrameRate = targetVSync;
		} else {
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = targetNormal;
		}
	}

	// Update is called once per frame
	void Update() {
		SettingsData data = SettingsSaveSystem.LoadData();

		// VSync
		if (data.m_vSync == true) {
			if (Application.targetFrameRate != targetVSync) {
				Application.targetFrameRate = targetVSync;
			}
		} else {
			QualitySettings.vSyncCount = 0;
			if (Application.targetFrameRate != targetNormal) {
				Application.targetFrameRate = targetNormal;
			}
		}
		// FPS counter
		if (data.m_FPSCounter == false) {
			FPSCounter.gameObject.SetActive(false);
		} else {
			FPSCounter.gameObject.SetActive(true);
			float current = 0;
			current = Time.frameCount / Time.time;
			avgFrameRate = (int)current;
			FPSCounter.text = "FPS : " + avgFrameRate;
		}
	}
}
