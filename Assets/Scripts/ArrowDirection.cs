using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// usage: put this on an arrow that is a child of the main camera on the player
// intent: will point the arrow in the direction of home when E is pressed
public class ArrowDirection : MonoBehaviour
{

	public GameObject homeDoor;
	//public GameObject player;

	//private Vector3 homePosition;
	//private Vector3 playerPosition;
	//private Vector3 arrowVector;

	private MeshRenderer meshrenderer;

	void Start ()
	{
		meshrenderer = GetComponent<MeshRenderer>();

		/*
		 homePosition = homeDoor.transform.position;
		playerPosition = player.transform.position;

		arrowVector = homePosition - playerPosition;
		*/
	}
	
	void Update () {
		// this line below makes the arrow start off pointing correctly, but doesn't update when you move around
		//transform.forward = arrowVector;

		transform.LookAt(homeDoor.transform.position);
		
		if (Input.GetKey(KeyCode.F))
		{
			meshrenderer.enabled = true;
		}
		else
		{
			meshrenderer.enabled = false;
		}
	}
}
