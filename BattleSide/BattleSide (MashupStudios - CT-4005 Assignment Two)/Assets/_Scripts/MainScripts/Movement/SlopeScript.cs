// Character Controler Script:
// Written by Iain Farlow
// Created 14/04/2020
// Last Updated: 18/04/2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeScript : MonoBehaviour {
    //Check in in slope trigger. Allows for player to move up slopes (if not present angle is too significant)
	void OnTriggerEnter2D(Collider2D collider) {
        //Check players tag
        if (collider.gameObject.tag == "Player")
        {
            //Check direction of slope
            if (this.gameObject.tag == "SlopeAreaRight")
            {
                //makes controller script change force to allow for slope to be easily moved on
                collider.GetComponent<CharacterControlerOneScript>().inTriggerRight = true;
            }
            else if (this.gameObject.tag == "SlopeAreaLeft")
            {
                collider.GetComponent<CharacterControlerOneScript>().inTriggerLeft = true;
            }
        }
        else if (collider.gameObject.tag == "Player2")
        {
            if (this.gameObject.tag == "SlopeAreaRight")
            {
                collider.GetComponent<CharacterControlerTwoScript>().inTriggerRight = true;
            }
            else if (this.gameObject.tag == "SlopeAreaLeft")
            {
                collider.GetComponent<CharacterControlerTwoScript>().inTriggerLeft = true;
            }
        }else if (collider.gameObject.tag == "Player3")
        {
            if (this.gameObject.tag == "SlopeAreaRight"){
                collider.GetComponent<CharacterControlerThreeScript>().inTriggerRight = true;
            }
            else if (this.gameObject.tag == "SlopeAreaLeft"){
                collider.GetComponent<CharacterControlerThreeScript>().inTriggerLeft = true;
            }
        }
        else if (collider.gameObject.tag == "Player3"){
            if (this.gameObject.tag == "SlopeAreaRight"){
                collider.GetComponent<CharacterControlerFourScript>().inTriggerRight = true;
            }
            else if (this.gameObject.tag == "SlopeAreaLeft"){
                collider.GetComponent<CharacterControlerFourScript>().inTriggerLeft = true;
            }
        }

    }
	void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			if (this.gameObject.tag == "SlopeAreaRight") {
				collider.GetComponent<CharacterControlerOneScript>().inTriggerRight = false;
			} else if (this.gameObject.tag == "SlopeAreaLeft") {
				collider.GetComponent<CharacterControlerOneScript>().inTriggerLeft = false;
			}
		} else if (collider.gameObject.tag == "Player 2") {
			if (this.gameObject.tag == "SlopeAreaRight") {
				collider.GetComponent<CharacterControlerTwoScript>().inTriggerRight = false;
			} else if (this.gameObject.tag == "SlopeAreaLeft") {
				collider.GetComponent<CharacterControlerTwoScript>().inTriggerLeft = false;
			}
		}else if (collider.gameObject.tag == "Player3")
        {
            if (this.gameObject.tag == "SlopeAreaRight"){
                collider.GetComponent<CharacterControlerTwoScript>().inTriggerRight = false;
            }
            else if (this.gameObject.tag == "SlopeAreaLeft"){
                collider.GetComponent<CharacterControlerTwoScript>().inTriggerLeft = false;
            }
        }else if (collider.gameObject.tag == "Player4"){
            if (this.gameObject.tag == "SlopeAreaRight") {
                collider.GetComponent<CharacterControlerTwoScript>().inTriggerRight = false;
            }
            else if (this.gameObject.tag == "SlopeAreaLeft"){
                collider.GetComponent<CharacterControlerTwoScript>().inTriggerLeft = false;
            }
        }

    }
}
