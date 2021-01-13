// Boom Timer
// Written by Iain Farlow
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomTimerScript : MonoBehaviour {
	float BoomTime = 0.4f;

	// Update is called once per frame

    //Timer to destroy the explosion animation
	void Update() {
		BoomTime -= Time.deltaTime;
		if (BoomTime <= 0.0f) {
			Destroy(gameObject);
		}
	}
}
