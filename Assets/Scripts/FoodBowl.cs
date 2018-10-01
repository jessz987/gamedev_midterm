using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class FoodBowl : MonoBehaviour
{
	private bool inBowlTrigger;
	
	public Text uiTextThought;
	public Text uiTextControlHint;
	public Text uiTextPosterCount;

	private MeshRenderer mRender;
	
	void Start ()
	{
		GameManager.foodBowlPlaced = false;
		mRender = GetComponent<MeshRenderer>();
	}
	
	void Update () {
		if (inBowlTrigger && Input.GetKey(KeyCode.E))
		{
			mRender.enabled = true;
			GameManager.foodBowlPlaced = true;
			uiTextControlHint.gameObject.SetActive(false);

			uiTextThought.text = "okay, now I can put up some lost cat posters. i have 20 posters to put up... " +
			                     "i guess those grey poles are the best place to put them.";
			
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
