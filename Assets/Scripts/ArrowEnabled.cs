using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// put this on an empty game object with a trigger collider
// when player triggers this, the home arrow will be enabled
public class ArrowEnabled : MonoBehaviour
{

	public Text uiTextArrow;
	public Text uiTextControlHint;

	public GameObject blackScreen;
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && !GameManager.arrowEnabled)
		{
			Debug.Log("arrow enabled script: on");
			GameManager.arrowEnabled = true;
			uiTextArrow.gameObject.SetActive(true);
		}
		else
		{
			Debug.Log("arrow enabled script: off");
			GameManager.arrowEnabled = false;
			uiTextArrow.gameObject.SetActive(false);
		}

		if (GameManager.fadeToBlack)
		{
			blackScreen.gameObject.SetActive(true);
			uiTextControlHint.gameObject.SetActive(true);
			uiTextControlHint.text = "press SPACE to continue...";
		}
	}
}
