// Knife Script:
// Created by Oliver Blackwell & controller system
// Rotation Functionality by Iain Farlow
// Created 25/05/2020
// Last Updated: 25/05/2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Comments are in playerOneKnifescript
//Difference being the gameobject the script is orientated arround
//Controls are different
public class PlayerThreeKnifeScript : MonoBehaviour {
	public GameObject player;
	private int knifeDamage = 10;

    private void Update()
    {
        if (Input.GetAxis("Horizontal_JoyTwo") == -1)
        {
            this.gameObject.transform.position = new Vector2(player.gameObject.transform.position.x - 0.3f, player.gameObject.transform.position.y);
            this.gameObject.transform.localScale = new Vector2(-0.2f, 0.2f);
        }
        if (Input.GetAxis("Horizontal_JoyTwo") == 1)
        {
            this.gameObject.transform.position = new Vector2(player.gameObject.transform.position.x + 0.3f, player.gameObject.transform.position.y);
            this.gameObject.transform.localScale = new Vector2(0.2f, 0.2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {

		if (collision.gameObject.name == "Player1Invis") {
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
