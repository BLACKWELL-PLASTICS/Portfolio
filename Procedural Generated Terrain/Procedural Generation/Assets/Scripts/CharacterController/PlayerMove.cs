// Written by Oliver Blackwell
// Created on : 07 / 12 / 2020
// Last edited : 07 / 12 / 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <Summary>
// This contains the player Movement code
// to allow the player control of the characters movement
public class PlayerMove : MonoBehaviour {

    GameObject Terrain;

    // Creating a new Rigidbody
    Rigidbody rb;

    // Jumping force
    float jumpForce = 5f;

    // Start is called before the first frame update
    private void Start() {
        Terrain = GameObject.FindGameObjectWithTag("Terrain");
        // Setting the new Rigidbody to the players Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        // We set the x and y values depending on the returned value from getting the input axis
        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");
        // THIS WOULD BE USED IF CREATING A NORMAL CHARACTER CONTROLLER
            //// we then create the new position the player will move to
            //Vector3 moveTo = transform.right * xMovement + transform.forward * zMovement;
            //// and use the rigidbody to move the players position
            //rb.MovePosition(transform.position + moveTo.normalized * speed * Time.deltaTime);
        // I have done this so the map moves around the player which gives the illusion that the player is moving around the map
        if (xMovement > 0) {
            Terrain.GetComponent<PerlinNoiseTerrainGenerator>().offsetY += .5f * Time.deltaTime;
        }
        if (zMovement > 0) {
            Terrain.GetComponent<PerlinNoiseTerrainGenerator>().offsetX += .5f * Time.deltaTime;
        }
        if (xMovement < 0) {
            Terrain.GetComponent<PerlinNoiseTerrainGenerator>().offsetY -= .5f * Time.deltaTime;
        }
        if (zMovement < 0) {
            Terrain.GetComponent<PerlinNoiseTerrainGenerator>().offsetX -= .5f * Time.deltaTime;
        }

        // if the space bar is pressed,
        if (Input.GetKeyDown(KeyCode.Space)) {
            // the player jumps by adding force into the rigidbodys up value.
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
