using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour {
	private Animation anim;
	[SerializeField]
	private GameObject door;

	private void Start() {
		// This will set then anim variable to the Animation on the Door GameObject
		anim = door.GetComponent<Animation>();
	}

	// when the trigger enters the collider, the animation will play
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			anim.Play();
		}
	}
}
