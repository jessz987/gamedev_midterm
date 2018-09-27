using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// put this on a player with a RigidBody to move it
// this script does mouse look and WASD movement
public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 10f;
	
	// this variable will remember input and pass it to physics
	private Vector3 inputVector;
	
	
	void Update () {
		
		// MOUSE look: getting mouse input
		float mouseX = Input.GetAxis("Mouse X"); // horizontal mouse input
		float mouseY = Input.GetAxis("Mouse Y"); //  vertical mouse input
		
		// rotating the camera based on the above mouse input
		transform.Rotate(0f, mouseX, 0f); 
		Camera.main.transform.Rotate(-mouseY, 0f, 0f);
		
		// WASD movement
		float horizontal = Input.GetAxis("Horizontal"); // A/D, left/right
		float vertical = Input.GetAxis("Vertical"); // W/S, forward/back, up/down
		
		inputVector = transform.forward * vertical; // forward
		inputVector += transform.right * horizontal; // strafe
	}
	
	void FixedUpdate()
	{
		// override object's velocity with desired inputVector direction
		GetComponent<Rigidbody>().velocity = inputVector * moveSpeed + Physics.gravity * 0.5f;
	}
}
