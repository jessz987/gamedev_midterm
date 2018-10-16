using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class FoodBowl : MonoBehaviour
{
	private bool inBowlTrigger;

	public GameObject bowl;

	public GameObject fenceWall;
	
	public Text uiTextThought;
	public Text uiTextControlHint;
	public Text uiTextPosterCount;

	private MeshRenderer mRender;
	
	void Start ()
	{
		GameManager.foodBowlPlaced = false;
	}
	
	void Update () {
		if (inBowlTrigger && Input.GetKey(KeyCode.E))
		{
			bowl.gameObject.SetActive(true);
			GameManager.foodBowlPlaced = true;
			uiTextControlHint.gameObject.SetActive(false);
			fenceWall.gameObject.SetActive(false);

			uiTextThought.text = "okay, now I can put up some lost cat posters. i have 10 posters to put up... " +
			                     "the grey poles downstairs seem like the best place to put them.";
			
			uiTextPosterCount.gameObject.SetActive(true);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		inBowlTrigger = true;
		
		if (!GameManager.foodBowlPlaced && !GameManager.foodBowlPlaced)
		{
			uiTextThought.text = "if I put his food here, maybe he can find his way back...";
			
			uiTextControlHint.gameObject.SetActive(true);
			uiTextControlHint.text = "press E to place bowl on the floor";
		}
	}

	private void OnTriggerExit(Collider other)
	{
		inBowlTrigger = false;
	}
}
