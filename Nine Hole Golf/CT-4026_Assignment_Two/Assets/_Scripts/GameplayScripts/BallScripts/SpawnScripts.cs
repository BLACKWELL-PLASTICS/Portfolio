using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScripts : MonoBehaviour {
	// this uses serialized fields so it shows the variables in the unity inspector
	[SerializeField]
	GameObject SpawnPoint;

	[SerializeField]
	GameObject Ball;

	Vector3 position;
	void Awake() {
		// when this script activates, the vector 3 position is set to the spawnpoint objects position
		position = SpawnPoint.transform.position;
		// then we instantiate the Ball prefab at the spawnpoint postion
		Instantiate(Ball, position, Quaternion.identity);
	}

}
