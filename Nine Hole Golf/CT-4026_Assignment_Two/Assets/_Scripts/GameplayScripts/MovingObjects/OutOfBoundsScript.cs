using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsScript : MonoBehaviour {
	[SerializeField]
	private GameObject Ball;

	[SerializeField]
	private GameObject BackToSpawn;

	private Vector3 SpawnLocation;

	private void Start() {
		// when the script is started, it sets the vector 3 variable to the spawn position
		SpawnLocation = BackToSpawn.transform.position;
	}
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			// when the ball enters the sand destory the ball
			Destroy(GameObject.FindGameObjectWithTag("Player"), 0.0f);
			// instantiate it again at the spawn position
			Ball = (GameObject)Instantiate(Ball, SpawnLocation, Quaternion.identity);
			// add the movescript onto the ball to make sure there is no glitches with no movement
			MoveScript Ms = Ball.GetComponent<MoveScript>();
			Ms.enabled = true;

		}
	}
}
