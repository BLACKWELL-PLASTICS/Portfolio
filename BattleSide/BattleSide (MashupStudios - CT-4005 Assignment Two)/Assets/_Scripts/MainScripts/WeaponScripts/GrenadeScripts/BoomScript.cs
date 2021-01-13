// Boom Script:
// Written by Iain Farlow updated by Oliver Blackwell
// Created: 04 / 02 / 2020
// Last Updated: 24/05/2020
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoomScript : MonoBehaviour {
	private float radius = 1.5f;

	private float fuseTimer = 3.0f;

	float DMGBase = 10.0f;

	float DMGMultiply = 10.0f;

	public Vector2 storagePosition;
	public GameObject Explosion;
	public

	void Update() {
        //Tick down time still explosion
		fuseTimer -= Time.deltaTime;
		if (fuseTimer <= 0) {
            //Get the grenades position before explosion
			float ExpXPos = this.transform.position.x;
			float ExpYPos = this.transform.position.y;
			Vector2 explosionPos = new Vector2(ExpXPos, ExpYPos);
            //Create the explosion animation
			Instantiate(Explosion, explosionPos, Quaternion.identity);
            //Create circle to check whats in explosion radius
			Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);
            //goes through each object
			foreach (Collider2D hit in colliders) {
                //Get that
				float HitXPos = hit.transform.position.x;
				float HitYPos = hit.transform.position.y;
				float HitXDist = ExpXPos - HitXPos;
				float HitYDist = ExpYPos - HitYPos;
				float DMGDistance = Mathf.Sqrt((HitXDist * HitXDist) + (HitXDist * HitXDist));
				float DMGResult = DMGBase + (DMGMultiply * ((radius + 2) - DMGDistance));

				if (hit.gameObject.tag == "PlayerInvis" || hit.gameObject.tag == "Player") {
					// Oliver Blackwell - I edited this script to work with the singleton
					if (hit.name == "Player1" || hit.name == "Player1Invis" && Manager.instance.PlayerOneInvulnerable == false) {
                        //lower players health
						Manager.instance.PlayerOneHP -= DMGResult;
					} else if (hit.name == "Player2" || hit.name == "Player2Invis" && Manager.instance.PlayerTwoInvulnerable == false) {
						Manager.instance.PlayerTwoHP -= DMGResult;
					} else if (hit.name == "Player3" || hit.name == "Player3Invis" && Manager.instance.PlayerThreeInvulnerable == false) {
						Manager.instance.PlayerThreeHP -= DMGResult;
					} else if (hit.name == "Player4" || hit.name == "Player4Invis" && Manager.instance.PlayerFourInvulnerable == false) {
						Manager.instance.PlayerFourHP -= DMGResult;
					}
				}
			}
            //After grendaed explodes destroy this script
            this.transform.position = storagePosition;
            Destroy(this.GetComponent<BoomScript>());
            Destroy(this.GetComponent<CircleCollider2D>());
            Destroy(this.GetComponent<Rigidbody2D>());
        }
	}
}