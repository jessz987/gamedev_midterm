using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// put this on a pole  (make sure it's unactive)
// player will press E in pole trigger to make the poster on it active
public class HangPoster : MonoBehaviour {

	public Text uiTextThought;
	public Text uiTextControlHint;
	public GameObject poster;
	
	
	void OnTriggerEnter(Collider coll)
	{
		uiTextThought.text = ("okay, I can hang up a poster here");
		
		uiTextControlHint.gameObject.SetActive(true);
		uiTextControlHint.text = ("press E to interact");
		
		// press E to hang up the poster (set the poster game object as active)
		// put this in update instead, and then make setactive(false) in ontriggerexit
		// here instead, make a boolean true that you then change in update!
		if (Input.GetKey(KeyCode.E))
		{
			poster.gameObject.SetActive(true);
			uiTextControlHint.gameObject.SetActive(false);
		}
	}
}
