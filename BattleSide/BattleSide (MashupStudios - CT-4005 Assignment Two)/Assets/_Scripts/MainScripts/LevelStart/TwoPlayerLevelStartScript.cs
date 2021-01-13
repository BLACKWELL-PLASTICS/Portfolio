// Level Start Script:
// Written by Iain Farlow updated by Oliver Blackwell
// Created 27 / 01 / 2020
// Last Updated: 26/05/2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerLevelStartScript : MonoBehaviour {
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
	GameObject Player1Invis;
	GameObject Player2;
	GameObject Player2Invis;

	int player1;
	int player2;
	[SerializeField]
	public Vector2 P1StartPos;
	[SerializeField]
	public Vector2 P1InvisStartPos;
	[SerializeField]
	public Vector2 P2StartPos;
	[SerializeField]
	public Vector2 P2InvisStartPos;

	GameObject Player1Gun;
	GameObject Player1Knife;
	GameObject Player2Gun;
	GameObject Player2Knife;

	// Start is called before the first frame update
	void Start() {
        //Get data from save system
		ChoiceData data = ChoiceSavingSystem.LoadData();
		player1 = data.playerOneChoice;
		player2 = data.playerTwoChoice;

		// Player1 Instantiation
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
		// Invis Instantiation 
		// Change Model to desired model
		if (player1 == 1) {
			Player1Invis = (GameObject)Instantiate(Model1, P1InvisStartPos, Quaternion.identity);
		} else if (player1 == 2) {
			Player1Invis = (GameObject)Instantiate(Model2, P1InvisStartPos, Quaternion.identity);
		} else if (player1 == 3) {
			Player1Invis = (GameObject)Instantiate(Model3, P1InvisStartPos, Quaternion.identity);
		} else if (player1 == 4) {
			Player1Invis = (GameObject)Instantiate(Model4, P1InvisStartPos, Quaternion.identity);
		}
        //Make invis invisable
		Color Player1Colour = Player1Invis.GetComponent<SpriteRenderer>().color;
		Player1Colour.a = 0f;
		Player1Invis.GetComponent<SpriteRenderer>().color = Player1Colour;
		Player1Invis.name = "Player1Invis"; // Change this for player name
		Player1Invis.tag = "PlayerInvis"; // Change this for player name
		Player1Invis.AddComponent<InvisableScript>();
        //Offset invis object
		Player1Invis.GetComponent<InvisableScript>().InvisShift = 30.0f;
		Player1Invis.GetComponent<InvisableScript>().VisablePlayer = Player1;

		//Player2 Instantiation (same as player one but with nessisary changes made for player 2)

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
		//Invis Instantioation  
		if (player2 == 1) {
			Player2Invis = (GameObject)Instantiate(Model1, P2InvisStartPos, Quaternion.identity);
		} else if (player2 == 2) {
			Player2Invis = (GameObject)Instantiate(Model2, P2InvisStartPos, Quaternion.identity);
		} else if (player2 == 3) {
			Player2Invis = (GameObject)Instantiate(Model3, P2InvisStartPos, Quaternion.identity);
		} else if (player2 == 4) {
			Player2Invis = (GameObject)Instantiate(Model4, P2InvisStartPos, Quaternion.identity);
		}
		Color Player2Colour = Player2Invis.GetComponent<SpriteRenderer>().color;
		Player2Colour.a = 0f;
		Player2Invis.GetComponent<SpriteRenderer>().color = Player2Colour;
		Player2Invis.name = "Player2Invis"; //Change this for player name
		Player2Invis.tag = "PlayerInvis";
		Player2Invis.AddComponent<InvisableScript>();
		Player2Invis.GetComponent<InvisableScript>().InvisShift = -30.0f;
		Player2Invis.GetComponent<InvisableScript>().VisablePlayer = Player2;
	}
}