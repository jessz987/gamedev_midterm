using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatScript : MonoBehaviour {

	
	public Text uiTextThought;
	public Text uiTextControlHint;
	
	
	public GameObject cat;
	public GameObject spotlight;

	private bool canHug;
	
	
	void Update () {
		if (GameManager.numPostersLeft <= 0)
		{
			cat.gameObject.SetActive(true);
		}

		if (canHug && Input.GetKey(KeyCode.E))
		{
			spotlight.gameObject.SetActive(true);
			uiTextControlHint.gameObject.SetActive(false);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (GameManager.numPostersLeft <= 0)
		{
			uiTextThought.text = "oh my god! pumpkin! you're back! i missed you so much... i'm so glad you're safe.";
			uiTextControlHint.text = "press E to hug pumpkin";
			uiTextControlHint.gameObject.SetActive(true);
			canHug = true;
		}
	}
}
