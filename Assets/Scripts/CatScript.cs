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

	private float timer = 2f;
	public float totalTimeToBlack = 2f;
	private bool timerCanStart = false;

	public GameObject BlackScreen;
	
	
	void Update () {
		if (GameManager.numPostersLeft <= 0)
		{
			cat.gameObject.SetActive(true);
		}

		if (canHug && Input.GetKey(KeyCode.E))
		{
			spotlight.gameObject.SetActive(true);
			uiTextControlHint.gameObject.SetActive(false);

			timer = totalTimeToBlack;
			timerCanStart = true;
			Debug.Log("timer set");
		}

		if (timer > 0 && timerCanStart)
		{
			timer -= Time.deltaTime;
			Debug.Log("timer counting down: " + timer.ToString());
		}

		if (timer <= 0 && timerCanStart)
		{
			BlackScreen.gameObject.SetActive(true);
			uiTextControlHint.gameObject.SetActive(true);
			uiTextControlHint.text = "THE END";
			uiTextThought.gameObject.SetActive(false);
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
