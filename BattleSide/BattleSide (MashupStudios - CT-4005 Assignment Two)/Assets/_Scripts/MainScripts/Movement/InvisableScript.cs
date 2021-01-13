// Invisable Script
// Created by Iain Farlow
// Base Code by Oli Blackwell
// Created 14/04/2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisableScript : MonoBehaviour {
	public GameObject VisablePlayer;
	public float InvisShift;

	// Update is called once per frame
	void Update() {
        //move depending on visable players location
		this.transform.position = new Vector2(VisablePlayer.transform.position.x + InvisShift, VisablePlayer.transform.position.y);
	}
}