// Load Volume Setting
// Written by Oliver Blackwell
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadVolumeSettingsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		// this loads the data from the settings save file
		SettingsData data = SettingsSaveSystem.LoadData();
		// gets the audio source connected to this gameObject and sets its volume to what is in the settings
		GetComponent<AudioSource>().volume = data.m_volume;
    }

}
