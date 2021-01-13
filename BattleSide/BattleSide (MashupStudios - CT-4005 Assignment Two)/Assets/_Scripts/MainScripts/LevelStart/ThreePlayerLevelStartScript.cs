// Three Player Level Start Script
// Created by Oliver Blackwell & updated for multiple levels
// Base Code by Iain Farlow
// Created : 20 / 05 / 2020
// Last Updated: 26/05/2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreePlayerLevelStartScript : MonoBehaviour {
    //Store objects pass to needed objects
    [SerializeField]
	public GameObject grenadePrfb;
	[SerializeField]
	public GameObject Explosion;

	[SerializeField]
	public GameObject Model1;
	[SerializeField]
	public GameObject Model2;
	[SerializeField]
	public GameObject Model3;
	[SerializeField]
	public GameObject Model4;

	GameObject Player1;
	GameObject Player1Invis1;
	GameObject Player1Invis2;
	GameObject Player2;
	GameObject Player2Invis1;
	GameObject Player2Invis2;
	GameObject Player3;
	GameObject Player3Invis1;
	GameObject Player3Invis2;

	int player1 = 0;
	int player2 = 0;
	int player3 = 0;

	// 1st Player
	[SerializeField]
	public Vector2 P1StartPos;
	[SerializeField]
	public Vector2 P1InvisStartPos1;
	[SerializeField]
	public Vector2 P1InvisStartPos2;

	// 2nd Player
	[SerializeField]
	public Vector2 P2StartPos;
	[SerializeField]
	public Vector2 P2InvisStartPos1;
	[SerializeField]
	public Vector2 P2InvisStartPos2;

	// 3rd Player 
	[SerializeField]
	public Vector2 P3StartPos;
	[SerializeField]
	public Vector2 P3InvisStartPos1;
	[SerializeField]
	public Vector2 P3InvisStartPos2;

    GameObject Player1Gun;
    GameObject Player1Knife;
    GameObject Player2Gun;
    GameObject Player2Knife;
    GameObject Player3Gun;
    GameObject Player3Knife;

    void Start() {
        //Get data from save system
        ChoiceData data = ChoiceSavingSystem.LoadData();
		player1 = data.playerOneChoice;
		player2 = data.playerTwoChoice;
		player3 = data.playerThreeChoice;

		// Player One Instantiation
		if (player1 == 1) {
			Player1 = (GameObject)Instantiate(Model1, P1StartPos, Quaternion.identity);
		} else if (player1 == 2) {
			Player1 = (GameObject)Instantiate(Model2, P1StartPos, Quaternion.identity);
		} else if (player1 == 3) {
			Player1 = (GameObject)Instantiate(Model3, P1StartPos, Quaternion.identity);
		} else if (player1 == 4) {
			Player1 = (GameObject)Instantiate(Model4, P1StartPos, Quaternion.identity);
		}
		Player1.name = "Player1"; //Change this for player name
		Player1.gameObject.tag = "Player";

        //Add scripts to character controller with designated variables
        Player1.AddComponent<CharacterControlerOneScript>();
		Player1.AddComponent<PlayerOneGrenadeScript>();
		Player1.GetComponent<PlayerOneGrenadeScript>().left = "a";
		Player1.GetComponent<PlayerOneGrenadeScript>().right = "d"; // Change each for designated control scheme
		Player1.GetComponent<PlayerOneGrenadeScript>().grenadePrfb = grenadePrfb;
		Player1.GetComponent<PlayerOneGrenadeScript>().Explosion = Explosion;
        //Get child of the object to add script to
        Player1Gun = Player1.gameObject.transform.GetChild(0).gameObject;
        Player1Gun.AddComponent<PlayerOneGunScript>();
        Player1Gun.GetComponent<PlayerOneGunScript>().player = Player1;
        Player1Knife = Player1.gameObject.transform.GetChild(1).gameObject;
        Player1Knife.AddComponent<PlayerOneKnifeScript>();
        Player1Knife.GetComponent<PlayerOneKnifeScript>().player = Player1;

        // Invis 1st Instantiation 
        if (player1 == 1) {
			Player1Invis1 = (GameObject)Instantiate(Model1, P1InvisStartPos1, Quaternion.identity);
		} else if (player1 == 2) {
			Player1Invis1 = (GameObject)Instantiate(Model2, P1InvisStartPos1, Quaternion.identity);
		} else if (player1 == 3) {
			Player1Invis1 = (GameObject)Instantiate(Model3, P1InvisStartPos1, Quaternion.identity);
		} else if (player1 == 4) {
			Player1Invis1 = (GameObject)Instantiate(Model4, P1InvisStartPos1, Quaternion.identity);
		}
        //make invis invisable
		Color Player1Colour = Player1Invis1.GetComponent<SpriteRenderer>().color;
		Player1Colour.a = 0f;
		Player1Invis1.GetComponent<SpriteRenderer>().color = Player1Colour;
		Player1Invis1.name = "Player1Invis"; // Change this for player name
		Player1Invis1.tag = "PlayerInvis"; // Change this for player name
		Player1Invis1.AddComponent<InvisableScript>();
		Player1Invis1.GetComponent<InvisableScript>().InvisShift = 30.0f;
		Player1Invis1.GetComponent<InvisableScript>().VisablePlayer = Player1;

		// Invis 2nd Instantiation
		if (player1 == 1) {
			Player1Invis2 = (GameObject)Instantiate(Model1, P1InvisStartPos2, Quaternion.identity);
		} else if (player1 == 2) {
			Player1Invis2 = (GameObject)Instantiate(Model2, P1InvisStartPos2, Quaternion.identity);
		} else if (player1 == 3) {
			Player1Invis2 = (GameObject)Instantiate(Model3, P1InvisStartPos2, Quaternion.identity);
		} else if (player1 == 4) {
			Player1Invis2 = (GameObject)Instantiate(Model4, P1InvisStartPos2, Quaternion.identity);
		}

		Player1Invis2.GetComponent<SpriteRenderer>().color = Player1Colour;
		Player1Invis2.name = "Player1Invis"; // Change this for player name
		Player1Invis2.tag = "PlayerInvis"; // Change this for player name
		Player1Invis2.AddComponent<InvisableScript>();
		Player1Invis2.GetComponent<InvisableScript>().InvisShift = 60.0f;
		Player1Invis2.GetComponent<InvisableScript>().VisablePlayer = Player1;

        // Player Two Instantiation (same as player one but with nessisary changes made for player 2)
        if (player2 == 1) {
			Player2 = (GameObject)Instantiate(Model1, P2StartPos, Quaternion.identity);
		} else if (player2 == 2) {
			Player2 = (GameObject)Instantiate(Model2, P2StartPos, Quaternion.identity);
		} else if (player2 == 3) {
			Player2 = (GameObject)Instantiate(Model3, P2StartPos, Quaternion.identity);
		} else if (player2 == 4) {
			Player2 = (GameObject)Instantiate(Model4, P2StartPos, Quaternion.identity);
		}
		Player2.name = "Player2"; //Change this for player name
		Player2.gameObject.tag = "Player2";
		Player2.AddComponent<CharacterControlerTwoScript>();
		Player2.AddComponent<PlayerTwoGrenadeScript>();
		Player2.GetComponent<PlayerTwoGrenadeScript>().grenadePrfb = grenadePrfb;
		Player2.GetComponent<PlayerTwoGrenadeScript>().Explosion = Explosion;
        Player2Gun = Player2.gameObject.transform.GetChild(0).gameObject;
        Player2Gun.AddComponent<PlayerTwoGunScript>();
        Player2Gun.GetComponent<PlayerTwoGunScript>().player = Player2;
        Player2Knife = Player2.gameObject.transform.GetChild(1).gameObject;
        Player2Knife.AddComponent<PlayerTwoKnifeScript>();
        Player2Knife.GetComponent<PlayerTwoKnifeScript>().player = Player2;

        //Invis 1st Instantiation 
        if (player2 == 1) {
			Player2Invis1 = (GameObject)Instantiate(Model1, P2InvisStartPos1, Quaternion.identity);
		} else if (player2 == 2) {
			Player2Invis1 = (GameObject)Instantiate(Model2, P2InvisStartPos1, Quaternion.identity);
		} else if (player2 == 3) {
			Player2Invis1 = (GameObject)Instantiate(Model3, P2InvisStartPos1, Quaternion.identity);
		} else if (player2 == 4) {
			Player2Invis1 = (GameObject)Instantiate(Model4, P2InvisStartPos1, Quaternion.identity);
		}
		Color Player2Colour = Player2Invis1.GetComponent<SpriteRenderer>().color;
		Player2Colour.a = 0f;
		Player2Invis1.GetComponent<SpriteRenderer>().color = Player2Colour;
		Player2Invis1.name = "Player2Invis"; //Change this for player name
		Player2Invis1.tag = "PlayerInvis";
		Player2Invis1.AddComponent<InvisableScript>();
		Player2Invis1.GetComponent<InvisableScript>().InvisShift = -30.0f;
		Player2Invis1.GetComponent<InvisableScript>().VisablePlayer = Player2;

		//Invis 2nd Instantiation 
		if (player2 == 1) {
			Player2Invis2 = (GameObject)Instantiate(Model1, P2InvisStartPos2, Quaternion.identity);
		} else if (player2 == 2) {
			Player2Invis2 = (GameObject)Instantiate(Model2, P2InvisStartPos2, Quaternion.identity);
		} else if (player2 == 3) {
			Player2Invis2 = (GameObject)Instantiate(Model3, P2InvisStartPos2, Quaternion.identity);
		} else if (player2 == 4) {
			Player2Invis2 = (GameObject)Instantiate(Model4, P2InvisStartPos2, Quaternion.identity);
		}
		Player2Invis2.GetComponent<SpriteRenderer>().color = Player2Colour;
		Player2Invis2.name = "Player2Invis"; //Change this for player name
		Player2Invis2.tag = "PlayerInvis";
		Player2Invis2.AddComponent<InvisableScript>();
		Player2Invis2.GetComponent<InvisableScript>().InvisShift = 30.0f;
		Player2Invis2.GetComponent<InvisableScript>().VisablePlayer = Player2;

        // Player Three Instantiation (same as player one but with nessisary changes made for player 3)
        if (player3 == 1) {
			Player3 = (GameObject)Instantiate(Model1, P3StartPos, Quaternion.identity);
		} else if (player3 == 2) {
			Player3 = (GameObject)Instantiate(Model2, P3StartPos, Quaternion.identity);
		} else if (player3 == 3) {
			Player3 = (GameObject)Instantiate(Model3, P3StartPos, Quaternion.identity);
		} else if (player3 == 4) {
			Player3 = (GameObject)Instantiate(Model4, P3StartPos, Quaternion.identity);
		}
		Player3.name = "Player3"; //Change this for player name
		Player3.gameObject.tag = "Player3";
		Player3.AddComponent<CharacterControlerThreeScript>();
		Player3.AddComponent<PlayerThreeGrenadeScript>();
		Player3.GetComponent<PlayerThreeGrenadeScript>().grenadePrfb = grenadePrfb;
		Player3.GetComponent<PlayerThreeGrenadeScript>().Explosion = Explosion;
        Player3Gun = Player3.gameObject.transform.GetChild(0).gameObject;
        Player3Gun.AddComponent<PlayerThreeGunScript>();
        Player3Gun.GetComponent<PlayerThreeGunScript>().player = Player3;
        Player3Knife = Player3.gameObject.transform.GetChild(1).gameObject;
        Player3Knife.AddComponent<PlayerThreeKnifeScript>();
        Player3Knife.GetComponent<PlayerThreeKnifeScript>().player = Player3;

        //Invis 1st Instantiation 
        if (player3 == 1) {
			Player3Invis1 = (GameObject)Instantiate(Model1, P3InvisStartPos1, Quaternion.identity);
		} else if (player3 == 2) {
			Player3Invis1 = (GameObject)Instantiate(Model2, P3InvisStartPos1, Quaternion.identity);
		} else if (player3 == 3) {
			Player3Invis1 = (GameObject)Instantiate(Model3, P3InvisStartPos1, Quaternion.identity);
		} else if (player3 == 4) {
			Player3Invis1 = (GameObject)Instantiate(Model4, P3InvisStartPos1, Quaternion.identity);
		}
		Color Player3Colour = Player3Invis1.GetComponent<SpriteRenderer>().color;
		Player3Colour.a = 0f;
		Player3Invis1.GetComponent<SpriteRenderer>().color = Player2Colour;
		Player3Invis1.name = "Player3Invis"; //Change this for player name
		Player3Invis1.tag = "PlayerInvis";
		Player3Invis1.AddComponent<InvisableScript>();
		Player3Invis1.GetComponent<InvisableScript>().InvisShift = -60.0f;
		Player3Invis1.GetComponent<InvisableScript>().VisablePlayer = Player3;


		//Invis 2nd Instantiation 
		if (player3 == 1) {
			Player3Invis2 = (GameObject)Instantiate(Model1, P3InvisStartPos2, Quaternion.identity);
		} else if (player3 == 2) {
			Player3Invis2 = (GameObject)Instantiate(Model2, P3InvisStartPos2, Quaternion.identity);
		} else if (player3 == 3) {
			Player3Invis2 = (GameObject)Instantiate(Model3, P3InvisStartPos2, Quaternion.identity);
		} else if (player3 == 4) {
			Player3Invis2 = (GameObject)Instantiate(Model4, P3InvisStartPos2, Quaternion.identity);
		}

		Player3Invis2.GetComponent<SpriteRenderer>().color = Player2Colour;
		Player3Invis2.name = "Player3Invis"; //Change this for player name
		Player3Invis2.tag = "PlayerInvis";
		Player3Invis2.AddComponent<InvisableScript>();
		Player3Invis2.GetComponent<InvisableScript>().InvisShift = -30.0f;
		Player3Invis2.GetComponent<InvisableScript>().VisablePlayer = Player3;
	}
}
