using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour {
	// This is the script for all of the flags except the end flag
	[SerializeField]
	private GameObject Ball;

	[SerializeField]
	private GameObject NextSpawn;

	private Vector3 NextSpawnLocation;

	private void Start() {
		// set the new vector 3 spawn location to the next spawn game object set in the inspector
		NextSpawnLocation = NextSpawn.transform.position;
	}

	// when the ball enters the flag base
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			// destroy the ball and instantiate it at the next spawn location
			Destroy(GameObject.FindGameObjectWithTag("Player"), 0.0f);
			Ball = (GameObject)Instantiate(Ball, NextSpawnLocation, Quaternion.identity);
		}
	}

}
