using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploadingPyramid : MonoBehaviour {
	public float explosionForce = 10;
	public float explosionRadius = 15;

	private void Start() {

		// This creates an array of the objects which are in the bombs radius from its position
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

		foreach (Collider collider in colliders) {
			//within this loop, it will check for a RidgidBody on a collider from the Collider array 
			Rigidbody r = collider.GetComponent<Rigidbody>();
			if (r != null) {
				//this will create the explosion and add force to the componants close by
				r.AddExplosionForce(explosionForce, transform.position, explosionRadius, 0, ForceMode.Impulse);
			}
			//once completed, the bomb will destroy and no longer exist
			Destroy(gameObject);
		}

	}

}
