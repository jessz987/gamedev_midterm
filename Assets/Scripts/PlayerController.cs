using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// put this on a player with a RigidBody to move it
// this script does mouse look and WASD movement
public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 10f;
	
	public Text uiTextNumPosters;
	public Text uiTextThought;
	public Text uiTextControlHint;
	
	
	// this variable will remember input and pass it to physics
	private Vector3 inputVector;

	void Start()
	{
		GameManager.numTotalPosters = 20;
		GameManager.numPostersLeft = GameManager.numTotalPosters;
	}
	
	
	void Update () {
		// UI always tells player # of posters left to put up
		uiTextNumPosters.text = "posters left: " + GameManager.numPostersLeft.ToString();
		
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
		
		// ENDING
		// cheat code: P to skip to all 20 posters up
		if (Input.GetKey(KeyCode.P))
		{
			GameManager.numPostersLeft = 0;
			// once all posters all up, end game:
			if (GameManager.numPostersLeft <= 0)
			{
				uiTextThought.text = "okay they're all up... i guess all i can do is go back home for now...";
				uiTextNumPosters.gameObject.SetActive(false);
				uiTextControlHint.gameObject.SetActive(false);
			}
		}
		
		
	}
	
	void FixedUpdate()
	{
		// override object's velocity with desired inputVector direction
		GetComponent<Rigidbody>().velocity = inputVector * moveSpeed + Physics.gravity * 0.5f;
	}
}
