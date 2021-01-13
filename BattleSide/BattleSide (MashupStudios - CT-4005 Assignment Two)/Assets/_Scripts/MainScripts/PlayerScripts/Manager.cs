// Manager Script
// Written by Oliver Blackwell
// 23 / 05 / 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
	// this manager is being used as a singleton approach to the health and invulnarability
	// this instance is being used to access all of the public varuiables
	public static Manager instance = null;

	public float PlayerOneHP;
	public float PlayerTwoHP;
	public float PlayerThreeHP;
	public float PlayerFourHP;

	public bool PlayerOneInvulnerable;
	public bool PlayerTwoInvulnerable;
	public bool PlayerThreeInvulnerable;
	public bool PlayerFourInvulnerable;

	// on awake create one instance of this class
	private void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
	}
}
