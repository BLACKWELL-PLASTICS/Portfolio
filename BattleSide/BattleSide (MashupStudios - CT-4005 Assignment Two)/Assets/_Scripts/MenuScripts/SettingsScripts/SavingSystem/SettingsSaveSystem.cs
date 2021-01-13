// Settings Save System
// Written by Oliver Blackwell
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SettingsSaveSystem {
	public static void SaveSettings(SettingsScript settingsScript) {
		// Create a binary formatter
		BinaryFormatter formatter = new BinaryFormatter();
		// create a path
		string path = Application.persistentDataPath + "/Settings.bin";
		// create a stream and a new file at that path
		FileStream stream = new FileStream(path, FileMode.Create);
		// create the data from the settingsData Class
		SettingsData data = new SettingsData(settingsScript);
		// serialise the data down the stream
		formatter.Serialize(stream, data);
		// close the stream
		stream.Close();
	}

	public static SettingsData LoadData() {
		// find the file at the path
		string path = Application.persistentDataPath + "/Settings.bin";
		// if file exists
		// else, if the file doesnt exist
		if (File.Exists(path)) {
			// create a new formatter
			BinaryFormatter formatter = new BinaryFormatter();
			// open a new file stream and read the data from the open file
			FileStream stream = new FileStream(path, FileMode.Open);
			// deserialize the data
			SettingsData data = formatter.Deserialize(stream) as SettingsData;
			// close the filestream
			stream.Close();
			// return the data
			return data;
		} else {
			// log an error saying the file isnt there
			Debug.LogError("Save File not found in " + path);
			// return null
			return null;
		}
	}

}
