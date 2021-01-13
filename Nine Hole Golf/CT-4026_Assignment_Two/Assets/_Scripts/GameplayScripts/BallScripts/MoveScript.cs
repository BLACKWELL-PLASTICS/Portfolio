using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {
	[SerializeField]
	private GameObject Ball;

	[SerializeField]
	private GameObject CameraHolder;

	private float powerScaller = 2.0f;

	float xDownPosition = 0.0f;
	float yDownPosition = 0.0f;

	public void Update() {
		// We collect the ridgedbody from the ball
		Rigidbody ballRigidBody = Ball.GetComponent<Rigidbody>();
		// check if the ball is not moving by checking the ridgidbodys velocity is at 0
		if (ballRigidBody.velocity.x == 0f && ballRigidBody.velocity.y == 0f && ballRigidBody.velocity.z == 0f
			&& ballRigidBody.angularVelocity.x == 0f && ballRigidBody.angularVelocity.y == 0f && ballRigidBody.angularVelocity.z == 0f) {
			// then get the rigidbody of the camera holder 
			Rigidbody cameraHolderRigidBody = CameraHolder.GetComponent<Rigidbody>();
			// create a new vector 3 so that the ball is then upright after being hit and then rotate it
			Vector3 ballUpright = new Vector3(ballRigidBody.transform.eulerAngles.x, 0, ballRigidBody.transform.eulerAngles.z);
			Ball.transform.Rotate(ballUpright);
			// then do the same thing for the camera holder
			Vector3 cameraHolderRigidBodyUpPositionright = new Vector3(-cameraHolderRigidBody.transform.eulerAngles.x, 0, -cameraHolderRigidBody.transform.eulerAngles.z);
			cameraHolderRigidBody.transform.Rotate(cameraHolderRigidBodyUpPositionright);

			// when the screen is clicked take the x and y value of the position on the screen
			if (Input.GetMouseButtonDown(0)) {
				xDownPosition = -Input.mousePosition.x;
				yDownPosition = -Input.mousePosition.y;
			}
			// when the screen stops taking input take the x and y value of the position on the screen
			if (Input.GetMouseButtonUp(0)) {
				float xUpPosition = -Input.mousePosition.x;
				float yUpPosition = -Input.mousePosition.y;
				
				// then minus the down and up positions of the x and y and then use them to create a new vector 3 for a new position
				float xVectorLength = xDownPosition - xUpPosition;
				float yVectorLength = yDownPosition - yUpPosition;
				Vector3 ballDirection = new Vector3(xVectorLength, 0, yVectorLength);
				// add force to the ball in the new direction created by the calculations
				ballRigidBody.AddForce(ballDirection * powerScaller);

			}
		}
	}
}
