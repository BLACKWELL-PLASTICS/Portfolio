// Written by Oliver Blackwell
// Created on : 07 / 12 / 2020
// Last edited : 07 / 12 / 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <Summary>
// This contains the player Looking code
// to allow the player control of the characters vision
public class PlayerLook : MonoBehaviour {
    // Creating a new Transform, it is serialized so it appears within the Unity UI
    [SerializeField] Transform cam;
    // float variables to control vision
    float sensitivity = 50f;
    float headRotation = 0f;
    float headRotationLimit = 90f;

    // Start is called before the first frame update
    void Start() {
        // This locks the cursor into the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        // This hides the cursor from view.
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        // We take in the axis input from the mouse and to add smoothness, we multiply it by our sensitivity variable and time.deltaTime
        float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime * -1f;
        transform.Rotate(0f, x, 0f);
        headRotation += y;
        headRotation = Mathf.Clamp(headRotation, -headRotationLimit, headRotationLimit);
        cam.localEulerAngles = new Vector3(headRotation, 0f, 0f);
    }
}
