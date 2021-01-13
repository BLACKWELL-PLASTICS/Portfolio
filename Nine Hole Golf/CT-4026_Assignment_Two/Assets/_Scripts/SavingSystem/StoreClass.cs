using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This means that the class and its contents can be saved
[System.Serializable]
public class StoreClass {
	// these are the four variables which are being saved
	public bool pinkBall;
	public bool yellowBall;
	public bool blueBall;

	public int materialActive;
	// this class takes in the StoreScript class and sets these member variables to the variables within the StoreScript class
	public StoreClass(StoreScript sc) {
		pinkBall = sc.pinkBall;
		yellowBall = sc.yellowBall;
		blueBall = sc.blueBall;
		materialActive = sc.materialActive;
	}

}
