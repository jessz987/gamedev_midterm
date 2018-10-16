using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// put this on a player with a RigidBody to move it
// this script does mouse look and WASD movement
public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 10f;
	public float lookSpeed = 100f;

	private float verticalLook = 0f;
	
	public Text uiTextNumPosters;
	public Text uiTextThought;

	public GameObject blackScreen;

	public GameObject spawnPointDownstairs;
	
	
	// this variable will remember input and pass it to physics
	private Vector3 inputVector;

	void Start()
	{
		GameManager.numTotalPosters = 10;
		GameManager.numPostersLeft = GameManager.numTotalPosters;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	
	void Update () {
		// UI always tells player # of posters left to put up
		uiTextNumPosters.text = "posters left: " + GameManager.numPostersLeft.ToString();
		
		// MOUSE look: getting mouse input
		float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * lookSpeed; // horizontal mouse movement
		float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * lookSpeed; // vertical mouse movement
		
		transform.Rotate(0f, mouseX, 0f); 
		
		verticalLook += -mouseY;
		verticalLook = Mathf.Clamp(verticalLook, -80f, 80f);
		Camera.main.transform.localEulerAngles = new Vector3(verticalLook, 0f, 0f);
		
		// CURSOR LOCK
		if (Input.GetMouseButtonDown(0)) // 0 = left-click
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false; 
		}
		
		// WASD movement
		float horizontal = Input.GetAxis("Horizontal"); // A/D, left/right
		float vertical = Input.GetAxis("Vertical"); // W/S, forward/back, up/down
		
		inputVector = transform.forward * vertical; // forward
		inputVector += transform.right * horizontal; // strafe
		
		// ENDING

		if (GameManager.monthLater && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))
		{
			blackScreen.gameObject.SetActive(false);
		}
		
		// CHEAT code: P to skip to all 20 posters up
		if (Input.GetKey(KeyCode.P))
		{
			GameManager.numPostersLeft = 0;
		}
		
		// once all posters all up, end game:
		if (GameManager.numPostersLeft <= 0 && !GameManager.fadeToBlack)
		{
			uiTextThought.text = "okay they're all up... i guess all i can do is go back home for now...";
			uiTextNumPosters.gameObject.SetActive(false);
			GameManager.fadeToBlack = true;
		}
		
		// CHEAT code: O to teleport downstairs
		if (Input.GetKey(KeyCode.O))
		{
			transform.position = spawnPointDownstairs.transform.position;
		}
	}
	
	void FixedUpdate()
	{
		// override object's velocity with desired inputVector direction
		GetComponent<Rigidbody>().velocity = inputVector * moveSpeed + Physics.gravity * 0.5f;
	}
}
