using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZMovingFloor : MonoBehaviour {
	[SerializeField]
	float MaxZ;

	[SerializeField]
	float MinZ;

	[SerializeField]
	float BobSpeed;


	// Update is called once per frame
	void Update() {
		// this checks if the z position is within, equal to or larger than the max or min z position
		if (transform.position.z >= MaxZ || transform.position.z <= MinZ) {
			// if true change the bob speed to positive or negative
			BobSpeed *= -1.0f;
		}
		// move the platform according to the bobspeed multiplied by deltatime
		transform.position += new Vector3(0.0f, 0.0f, BobSpeed * Time.deltaTime);
	}
}
