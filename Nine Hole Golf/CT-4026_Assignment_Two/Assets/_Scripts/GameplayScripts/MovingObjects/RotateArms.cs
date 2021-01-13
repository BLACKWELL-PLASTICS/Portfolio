using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArms : MonoBehaviour {
	// this simple script just rotates the arms around at the speed specified multiplied by the delatime variable
	public int speed;
	// Update is called once per frame
	void Update() {
		transform.Rotate(0, speed * Time.deltaTime, 0);
	}
}
