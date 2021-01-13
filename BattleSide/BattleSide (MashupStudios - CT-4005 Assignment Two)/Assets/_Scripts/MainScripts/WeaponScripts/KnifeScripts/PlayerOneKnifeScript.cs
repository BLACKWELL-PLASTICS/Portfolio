// Knife Script:
// Created by Oliver Blackwell & controller system
// Rotation Functionality by Iain Farlow
// Created 25/05/2020
// Last Updated: 25/05/2020

//Comments are in playerOneKnifescript
//Difference being the gameobject the script is orientated arround
//Controls are different

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneKnifeScript : MonoBehaviour {
	public GameObject player;
	private int knifeDamage = 10;
    private void Update()
    {
        //Check character direction
        if (Input.GetAxis("Horizontal") == -1)
        {
            //Move knife to the facing side
            this.gameObject.transform.position = new Vector2(player.gameObject.transform.position.x - 0.3f, player.gameObject.transform.position.y);
            //Chnage scale to "rotate" knife
            this.gameObject.transform.localScale = new Vector2(-0.2f, 0.2f);
        }
        if (Input.GetAxis("Horizontal") == 1)
        {
            this.gameObject.transform.position = new Vector2(player.gameObject.transform.position.x + 0.3f, player.gameObject.transform.position.y);
            this.gameObject.transform.localScale = new Vector2(0.2f, 0.2f);
        }
    }

    //Check if other gameobject is in knifes trigger box
	private void OnTriggerEnter2D(Collider2D collision) {
        //Check that objects name
		if (collision.gameObject.name == "Player1Invis") {
            //If object is a player invis object deal damage
			Manager.instance.PlayerOneHP -= knifeDamage;
		} else if (collision.gameObject.name == "Player2Invis") {
			Manager.instance.PlayerTwoHP -= knifeDamage;
		} else if (collision.gameObject.name == "Player3Invis") {
			Manager.instance.PlayerThreeHP -= knifeDamage;
		} else if (collision.gameObject.name == "Player4Invis") {
			Manager.instance.PlayerFourHP -= knifeDamage;
		}
	}
}
