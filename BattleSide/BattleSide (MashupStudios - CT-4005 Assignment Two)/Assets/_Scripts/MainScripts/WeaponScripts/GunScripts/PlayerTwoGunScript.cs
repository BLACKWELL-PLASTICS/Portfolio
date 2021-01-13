// Gun Script:
// Created by Oliver Blackwell & controller system
// Functionality by Iain Farlow
// Created 25/05/2020
// Last Updated: 25/05/2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoGunScript : MonoBehaviour
{

    public GameObject player;

    private bool rightLeft = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetAxis("Horizontal_JoyOne") == -1)
        {
            this.gameObject.transform.position = new Vector2(player.gameObject.transform.position.x - 0.3f, player.gameObject.transform.position.y);
            this.gameObject.transform.localScale = new Vector2(-0.2f, 0.2f);
            rightLeft = false;
        }
        if (Input.GetAxis("Horizontal_JoyOne") == 1)
        {
            this.gameObject.transform.position = new Vector2(player.gameObject.transform.position.x + 0.3f, player.gameObject.transform.position.y);
            this.gameObject.transform.localScale = new Vector2(0.2f, 0.2f);
            rightLeft = true;
        }
        if (Input.GetButtonDown("Fire3_JoyOne") && player.GetComponent<InventoryScript>().Bullets > 0)
        {
            player.GetComponent<InventoryScript>().Bullets--;
            if (rightLeft)
            {
                Vector2 rayStart = new Vector2(this.gameObject.transform.position.x + 0.2f, this.gameObject.transform.position.y);
                RaycastHit2D rayHit = Physics2D.Raycast(rayStart, Vector2.right, 20.0f);
                Debug.DrawRay(rayStart, Vector2.right * 20.0f, Color.red);

                if (rayHit.collider != null)
                {
                    if (rayHit.transform.name == "Player1Invis" && Manager.instance.PlayerOneInvulnerable == false)
                    {
                        Manager.instance.PlayerOneHP -= 50.0f;
                    }
                    else if (rayHit.transform.name == "Player2Invis" && Manager.instance.PlayerTwoInvulnerable == false)
                    {
                        Manager.instance.PlayerTwoHP -= 50.0f;
                    }
                    else if (rayHit.transform.name == "Player3Invis" && Manager.instance.PlayerThreeInvulnerable == false)
                    {
                        Manager.instance.PlayerThreeHP -= 50.0f;
                    }
                    else if (rayHit.transform.name == "Player4Invis" && Manager.instance.PlayerFourInvulnerable == false)
                    {
                        Manager.instance.PlayerFourHP -= 50.0f;
                    }
                }
            }
            else
            {
                Vector2 rayStart = new Vector2(this.gameObject.transform.position.x - 0.2f, this.gameObject.transform.position.y);
                RaycastHit2D rayHit = Physics2D.Raycast(rayStart, Vector2.left, 20.0f);
                Debug.DrawRay(rayStart, Vector2.left * 20.0f, Color.red);

                if (rayHit.collider != null)
                {
                    if (rayHit.transform.name == "Player1" || rayHit.transform.name == "Player1Invis" && Manager.instance.PlayerOneInvulnerable == false)
                    {
                        Manager.instance.PlayerOneHP -= 50.0f;
                    }
                    else if (rayHit.transform.name == "Player2" || rayHit.transform.name == "Player2Invis" && Manager.instance.PlayerTwoInvulnerable == false)
                    {
                        Manager.instance.PlayerTwoHP -= 50.0f;
                    }
                    else if (rayHit.transform.name == "Player3" || rayHit.transform.name == "Player3Invis" && Manager.instance.PlayerThreeInvulnerable == false)
                    {
                        Manager.instance.PlayerThreeHP -= 50.0f;
                    }
                    else if (rayHit.transform.name == "Player4" || rayHit.transform.name == "Player4Invis" && Manager.instance.PlayerFourInvulnerable == false)
                    {
                        Manager.instance.PlayerFourHP -= 50.0f;
                    }
                }
            }
        }
    }
}
