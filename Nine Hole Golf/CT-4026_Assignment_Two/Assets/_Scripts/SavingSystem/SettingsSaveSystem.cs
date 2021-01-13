﻿// THIS CODE HAS BEEN TAKEN FROM MY PREVIOUS ASSIGNMENT, i have edited it slightly to work with this new project.
// This code was written by Oliver Blackwell and was submitted as part of my CT-4026 Assignment One project on Thursday 5th December 2019
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SettingsSaveSystem {
	public static void SaveData(SliderScripts slider) {
		// I am creating a binary formatter which can be used
		BinaryFormatter formatter = new BinaryFormatter();

		// This is creating the binary file which can save to and i am choosing where the file is saved to aswell
		string path = Application.persistentDataPath + "/settingsdata.bin";

		// This is creating and opening a file stream
		FileStream stream = new FileStream(path, FileMode.Create);

		// this is all of the data to save
		SettingsClass data = new SettingsClass(slider);

		// This is serializing the data down the stream into binary and then closing the stream
		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static SettingsClass LoadData() {
		// This will find the path to the file i created
		string path = Application.persistentDataPath + "/settingsdata.bin";

		//This then checks if the file exists
		if (File.Exists(path)) {
			// Opening another formatter
			BinaryFormatter formatter = new BinaryFormatter();

			// Opening a stream to the same path, but using open rather than creating as i want to open the existing file
			FileStream stream = new FileStream(path, FileMode.Open);

			// This then converts the data back into a float and then closes the stream and returns the data to PlayerData
			SettingsClass data = formatter.Deserialize(stream) as SettingsClass;
			stream.Close();
			return data;
		} else {
			// This will happen if the brightness.bin file is not found
			Debug.LogError("FILE NOT FOUND IN " + path);
			return null;
		}

	}

}
