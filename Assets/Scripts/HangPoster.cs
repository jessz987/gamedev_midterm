using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// put this on a pole  (make sure related poster is unactive)
// player will press E in pole trigger to make the poster on it active
public class HangPoster : MonoBehaviour {

	public GameObject poster;

	private bool InPosterTrigger;
	private bool CanHangPoster;
	private bool PosterUp;
	
	public Text uiTextThought;
	public Text uiTextControlHint;

	void Start()
	{
		InPosterTrigger = false;
		CanHangPoster = false;
		PosterUp = false;
	}

	void Update()
	{
		// if player is in trigger, bool changed so can hang poster
		if (InPosterTrigger)
		{
			if (Input.GetKey(KeyCode.E))
			{
				CanHangPoster = true;
			}
		}
		
		// if bool is true (from pressing E in trigger), poster goes up
		// uiText is also updated, and player can no longer interact with the poster
		if (CanHangPoster)
		{
			poster.gameObject.SetActive(true);
			uiTextControlHint.gameObject.SetActive(false);
			PosterUp = true;

			
			uiTextThought.text = "alright... next poster.";
		}
	}
	
	void OnTriggerEnter(Collider coll)
	{
		// once poster is up, can no longer interact with it
		if (!PosterUp && GameManager.foodBowlPlaced)
		{
			uiTextThought.text = ("okay, I can hang up a poster here");
		
			uiTextControlHint.gameObject.SetActive(true);
			uiTextControlHint.text = ("press E to interact");
		}
		
		InPosterTrigger = true;
	}

	private void OnTriggerExit(Collider other)
	{
		CanHangPoster = false;
		InPosterTrigger = false;
		
		GameManager.numPostersLeft--;
	}
}
