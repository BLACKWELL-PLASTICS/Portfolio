// Four Player Won Script
// Written by Oliver Blackwell
// 24 / 05 / 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FourPlayerWonScript : MonoBehaviour
{
	[SerializeField]
	GameObject WonScreen;

	[SerializeField]
	Text FirstPlace;
	[SerializeField]
	Text SecondPlace;
	[SerializeField]
	Text ThirdPlace;
	[SerializeField]
	Text FourthPlace;

	GameObject PlayerOne;
	GameObject PlayerTwo;
	GameObject PlayerThree;
	GameObject PlayerFour;

	private void Start() {
		// This finds the player objects
		PlayerOne = GameObject.Find("Player");
		PlayerTwo = GameObject.Find("Player2");
		PlayerThree = GameObject.Find("Player3");
		PlayerFour = GameObject.Find("Player4");
	}

	// Update is called once per frame
	void Update()
    {
		// If Player 1 dies first
			// if player 2 dies second
				// if player 3 dies third
				// else if player 4 dies third
			// if player 3 dies second
				// if player 2 dies third
				// else if player 4 dies third
			// if player 4 dies second
				// if player 2 dies third
				// else if player 3 dies third
		// If player 2 dies first
			// if player 1 dies second
				// if player 3 dies third
				// else if player 4 dies third
			// if player 3 dies second
				// if player 1 dies third
				// else if player 4 dies third
			// if player 4 dies second
				// if player 1 dies third
				// else if player 3 dies third
		// if Player 3 dies first
			// if player 1 dies second
				// if player 2 dies third
				// else if player 4 dies third
			// if player 2 dies second
				// if player 1 dies third
				// else if player 4 dies third
			// if player 4 dies second
				// if player 1 dies third
				// else if player 2 dies third
		// if player 4 dies first
			// if player 1 dies second
				// if player 2 dies third
				// else if player 3 dies third
			// if player 2 dies second
				// if player 1 dies third
				// else if player 3 dies third
			// if player 3 dies second
				// if player 1 dies third
				// else if player 2 dies third
		
		// IF PLAYER ONE DIES FIRST
		if (Manager.instance.PlayerOneHP <= 0) {
			FourthPlace.text = "4th Place - Player 1";
			Destroy(PlayerOne, 0.0f);
			if (Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerTwoHP <= 0) {
				ThirdPlace.text = "3rd Place - Player 2";
				Destroy(PlayerTwo, 0.0f);
				if (Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerTwoHP <= 0 && Manager.instance.PlayerThreeHP <= 0) {
					Destroy(PlayerThree, 0.0f);
					SecondPlace.text = "2nd Place - Player 3";
					FirstPlace.text = "1st Place - Player 4";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				} else if (Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerTwoHP <= 0 && Manager.instance.PlayerFourHP <= 0) {
					Destroy(PlayerFour, 0.0f);
					SecondPlace.text = "2nd Place - Player 4";
					FirstPlace.text = "1st Place - Player 3";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				}
			} else if (Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerThreeHP <= 0) {
				ThirdPlace.text = "3rd Place - Player 3";
				Destroy(PlayerThree, 0.0f);
				if (Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerTwoHP <= 0) {
					Destroy(PlayerTwo, 0.0f);
					SecondPlace.text = "2nd Place - Player 2";
					FirstPlace.text = "1st Place - Player 4";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				} else if (Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerFourHP <= 0) {
					Destroy(PlayerFour, 0.0f);
					SecondPlace.text = "2nd Place - Player 4";
					FirstPlace.text = "1st Place - Player 2";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				}
			} else if (Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerFourHP <= 0) {
				ThirdPlace.text = "3rd Place - Player 4";
				Destroy(PlayerFour, 0.0f);
				if (Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerFourHP <= 0 && Manager.instance.PlayerTwoHP <= 0) {
					Destroy(PlayerTwo, 0.0f);
					SecondPlace.text = "2nd Place - Player 2";
					FirstPlace.text = "1st Place - Player 3";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				} else if (Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerFourHP <= 0 && Manager.instance.PlayerThreeHP <= 0) {
					Destroy(PlayerThree, 0.0f);
					SecondPlace.text = "2nd Place - Player 3";
					FirstPlace.text = "1st Place - Player 2";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				}
			}
			// IF PLAYER TWO DIES FIRST
		} else if (Manager.instance.PlayerTwoHP <= 0) {
			FourthPlace.text = "4th Place - Player 2";
			Destroy(PlayerTwo, 0.0f);
			if (Manager.instance.PlayerTwoHP <= 0 && Manager.instance.PlayerOneHP <= 0) {
				ThirdPlace.text = "3rd Place - Player 1";
				Destroy(PlayerOne, 0.0f);
				if (Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerTwoHP <= 0 && Manager.instance.PlayerThreeHP <= 0) {
					Destroy(PlayerThree, 0.0f);
					SecondPlace.text = "2nd Place - Player 3";
					FirstPlace.text = "1st Place - Player 4";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				} else if (Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerTwoHP <= 0 && Manager.instance.PlayerFourHP <= 0) {
					Destroy(PlayerFour, 0.0f);
					SecondPlace.text = "2nd Place - Player 4";
					FirstPlace.text = "1st Place - Player 3";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				}
			} else if (Manager.instance.PlayerTwoHP <= 0 && Manager.instance.PlayerThreeHP <= 0) {
				ThirdPlace.text = "3rd Place - Player 3";
				Destroy(PlayerThree, 0.0f);
				if (Manager.instance.PlayerTwoHP <= 0 && Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerOneHP <= 0) {
					Destroy(PlayerOne, 0.0f);
					SecondPlace.text = "2nd Place - Player 1";
					FirstPlace.text = "1st Place - Player 4";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				} else if (Manager.instance.PlayerTwoHP <= 0 && Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerFourHP <= 0) {
					Destroy(PlayerFour, 0.0f);
					SecondPlace.text = "2nd Place - Player 4";
					FirstPlace.text = "1st Place - Player 1";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				}
			} else if (Manager.instance.PlayerTwoHP <= 0 && Manager.instance.PlayerFourHP <= 0) {
				ThirdPlace.text = "3rd Place - Player 4";
				Destroy(PlayerFour, 0.0f);
				if (Manager.instance.PlayerTwoHP <= 0 && Manager.instance.PlayerFourHP <= 0 && Manager.instance.PlayerOneHP <= 0) {
					Destroy(PlayerOne, 0.0f);
					SecondPlace.text = "2nd Place - Player 1";
					FirstPlace.text = "1st Place - Player 3";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				} else if (Manager.instance.PlayerTwoHP <= 0 && Manager.instance.PlayerFourHP <= 0 && Manager.instance.PlayerThreeHP <= 0) {
					Destroy(PlayerTwo, 0.0f);
					SecondPlace.text = "2nd Place - Player 3";
					FirstPlace.text = "1st Place - Player 1";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				}
			}
			// IF PLAYER THREE DIES FIRST
		} else if (Manager.instance.PlayerThreeHP <= 0) {
			FourthPlace.text = "4th Place - Player 3";
			Destroy(PlayerThree, 0.0f);
			if (Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerOneHP <= 0) {
				ThirdPlace.text = "3rd Place - Player 1";
				Destroy(PlayerOne, 0.0f);
				if (Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerTwoHP <= 0) {
					Destroy(PlayerTwo, 0.0f);
					SecondPlace.text = "2nd Place - Player 2";
					FirstPlace.text = "1st Place - Player 4";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				} else if (Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerFourHP <= 0) {
					Destroy(PlayerFour, 0.0f);
					SecondPlace.text = "2nd Place - Player 4";
					FirstPlace.text = "1st Place - Player 2";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				}
			} else if (Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerTwoHP <= 0) {
				ThirdPlace.text = "3rd Place - Player 2";
				Destroy(PlayerTwo, 0.0f);
				if (Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerOneHP <= 0) {
					Destroy(PlayerOne, 0.0f);
					SecondPlace.text = "2nd Place - Player 1";
					FirstPlace.text = "1st Place - Player 4";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				} else if (Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerFourHP <= 0) {
					Destroy(PlayerFour, 0.0f);
					SecondPlace.text = "2nd Place - Player 4";
					FirstPlace.text = "1st Place - Player 1";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				}
			} else if (Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerFourHP <= 0) {
				ThirdPlace.text = "3rd Place - Player 4";
				Destroy(PlayerFour, 0.0f);
				if (Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerFourHP <= 0 && Manager.instance.PlayerOneHP <= 0) {
					Destroy(PlayerOne, 0.0f);
					SecondPlace.text = "2nd Place - Player 1";
					FirstPlace.text = "1st Place - Player 2";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				} else if (Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerFourHP <= 0 && Manager.instance.PlayerTwoHP <= 0) {
					Destroy(PlayerTwo, 0.0f);
					SecondPlace.text = "2nd Place - Player 2";
					FirstPlace.text = "1st Place - Player 1";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				}
			}
			// IF PLAYER FOUR DIES FIRST
		} else if (Manager.instance.PlayerFourHP <= 0) {
			FourthPlace.text = "4th Place - Player 4";
			Destroy(PlayerFour, 0.0f);
			if (Manager.instance.PlayerFourHP <= 0 && Manager.instance.PlayerOneHP <= 0) {
				ThirdPlace.text = "3rd Place - Player 1";
				Destroy(PlayerOne, 0.0f);
				if (Manager.instance.PlayerFourHP <= 0 && Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerTwoHP <= 0) {
					Destroy(PlayerTwo, 0.0f);
					SecondPlace.text = "2nd Place - Player 2";
					FirstPlace.text = "1st Place - Player 3";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				} else if (Manager.instance.PlayerFourHP <= 0 && Manager.instance.PlayerOneHP <= 0 && Manager.instance.PlayerThreeHP <= 0) {
					Destroy(PlayerThree, 0.0f);
					SecondPlace.text = "2nd Place - Player 3";
					FirstPlace.text = "1st Place - Player 2";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				}
			} else if (Manager.instance.PlayerFourHP <= 0 && Manager.instance.PlayerTwoHP <= 0) {
				ThirdPlace.text = "3rd Place - Player 2";
				Destroy(PlayerTwo, 0.0f);
				if (Manager.instance.PlayerFourHP <= 0 && Manager.instance.PlayerTwoHP <= 0 && Manager.instance.PlayerOneHP <= 0) {
					Destroy(PlayerOne, 0.0f);
					SecondPlace.text = "2nd Place - Player 1";
					FirstPlace.text = "1st Place - Player 3";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				} else if (Manager.instance.PlayerFourHP <= 0 && Manager.instance.PlayerTwoHP <= 0 && Manager.instance.PlayerThreeHP <= 0) {
					Destroy(PlayerThree, 0.0f);
					SecondPlace.text = "2nd Place - Player 3";
					FirstPlace.text = "1st Place - Player 1";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				}
			} else if (Manager.instance.PlayerFourHP <= 0 && Manager.instance.PlayerThreeHP <= 0) {
				ThirdPlace.text = "3rd Place - Player 3";
				Destroy(PlayerThree, 0.0f);
				if (Manager.instance.PlayerFourHP <= 0 && Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerOneHP <= 0) {
					Destroy(PlayerOne, 0.0f);
					SecondPlace.text = "2nd Place - Player 1";
					FirstPlace.text = "1st Place - Player 2";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				} else if (Manager.instance.PlayerFourHP <= 0 && Manager.instance.PlayerThreeHP <= 0 && Manager.instance.PlayerTwoHP <= 0) {
					Destroy(PlayerTwo, 0.0f);
					SecondPlace.text = "2nd Place - Player 2";
					FirstPlace.text = "1st Place - Player 1";
					WonScreen.SetActive(true);
					Time.timeScale = 0.0f;
				}
			}
		}

		// if x is pressed and won screen is active
		if (Input.GetButtonDown("Fire3") && WonScreen.activeInHierarchy == true) {
			// load menu scene
			SceneManager.LoadScene(0);
			Time.timeScale = 1.0f;
		}
	}
}
