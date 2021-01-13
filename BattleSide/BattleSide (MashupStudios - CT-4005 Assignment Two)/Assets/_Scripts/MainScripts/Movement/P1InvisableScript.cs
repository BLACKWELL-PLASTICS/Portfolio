// P2 Invisible Script:
// Written by Oliver Blackwell
// 27 / 01 / 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1InvisableScript : MonoBehaviour {
	[SerializeField]
	public GameObject VisablePlayer;

	// Update is called once per frame
	void Update() {
		this.transform.position = new Vector2(VisablePlayer.transform.position.x + 30, VisablePlayer.transform.position.y);
	}
}
