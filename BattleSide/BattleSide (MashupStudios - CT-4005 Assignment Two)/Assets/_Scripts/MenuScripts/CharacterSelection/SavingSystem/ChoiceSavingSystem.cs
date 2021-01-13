// Choice Saving System
// Written by Oliver Blackwell
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class ChoiceSavingSystem {
	public static void SaveSettings(PlayerInput pio) {
		// create a binary formatter
		BinaryFormatter formatter = new BinaryFormatter();
		// create a filepath
		string path = Application.persistentDataPath + "/PlayerChoice.bin";
		// create a filestream give it the new path and create the file
		FileStream stream = new FileStream(path, FileMode.Create);
		// choice data equalse new data from the player input class
		ChoiceData data = new ChoiceData(pio);
		// serialise data down the stream
		formatter.Serialize(stream, data);
		// close the stream
		stream.Close();
	}

	public static ChoiceData LoadData() {
		// find file
		string path = Application.persistentDataPath + "/PlayerChoice.bin";
		// if file exists
		// else, if the file does not exist
		if (File.Exists(path)) {
			// create a formatter
			BinaryFormatter formatter = new BinaryFormatter();
			// create a filestream and open the file
			FileStream stream = new FileStream(path, FileMode.Open);
			// deserialise data
			ChoiceData data = formatter.Deserialize(stream) as ChoiceData;
			// close stream
			stream.Close();
			//return data
			return data;
		} else {
			// log an error
			Debug.LogError("Save File not found in " + path);
			// return null
			return null;
		}
	}
}
