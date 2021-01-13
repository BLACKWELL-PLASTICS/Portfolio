using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

	[SerializeField]
	GameObject SpawnOne;
	[SerializeField]
	GameObject SpawnTwo;
	[SerializeField]
	GameObject SpawnThree;
	[SerializeField]
	GameObject SpawnFour;
	[SerializeField]
	GameObject SpawnFive;

	[SerializeField]
	GameObject SpawnObject;

	// Start is called before the first frame update
	void Awake() {
		// When the lucky shot scene loads, set the timescale to 1
		Time.timeScale = 1;
		// then choose which spawn the pad will spawn at
		int spawnChoice = Random.Range(0, 4);
		// once chosen move the pad onto the new spawn point position
		if (spawnChoice == 0) {
			SpawnObject.transform.position = SpawnOne.transform.position;
		} else if (spawnChoice == 1) {
			SpawnObject.transform.position = SpawnTwo.transform.position;
		} else if (spawnChoice == 2) {
			SpawnObject.transform.position = SpawnThree.transform.position;
		} else if (spawnChoice == 3) {
			SpawnObject.transform.position = SpawnFour.transform.position;
		} else if (spawnChoice == 4) {
			SpawnObject.transform.position = SpawnFive.transform.position;
		}
	}
}
