// Choice Data
// Writen by Oliver Blackwell
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class is serilizable
[System.Serializable]
public class ChoiceData {
	// create the ints for the players choice
	public int playerOneChoice;
	public int playerTwoChoice;
	public int playerThreeChoice;
	public int playerFourChoice;

	// pass in the PlayerInput data
	public ChoiceData(PlayerInput pio) {
		// the serializable ints in this class are set to the ints passed in
		playerOneChoice = pio.PlayerChoiceOne;
		playerTwoChoice = pio.PlayerChoiceTwo;
		playerThreeChoice = pio.PlayerChoiceThree;
		playerFourChoice = pio.PlayerChoiceFour;
	}
}
