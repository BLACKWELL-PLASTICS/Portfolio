// Settings Data
// Written by Oliver Blackwell
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsData {

	// Vsync Setting
	public bool m_vSync;

	// FPS Counter;
	public bool m_FPSCounter;

	// Volume Setting
	public float m_volume;

	public SettingsData(SettingsScript settings) {
		m_vSync = settings.is_vSync;
		m_FPSCounter = settings.is_FPSCounter;
		m_volume = settings.volume;
	}
}
