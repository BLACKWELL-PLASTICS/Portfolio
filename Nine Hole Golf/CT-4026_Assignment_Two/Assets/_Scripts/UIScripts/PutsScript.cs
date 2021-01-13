using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutsScript : MonoBehaviour {
	// This is a simple script to count the amount of puts the player has done while in game
	// This has been added so that the player can keep track of how well they are completing the level
	[SerializeField]
	private Text txt_putCount;

	private int putCount = 0;

	public void Update() {
		if (Input.GetTouch(0).phase == TouchPhase.Ended) {
			putCount++;
		}
		txt_putCount.text = "Puts : " + putCount;
	}
}
