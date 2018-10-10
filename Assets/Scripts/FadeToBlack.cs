﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// put this on a hollow sphere surrounding the camera
public class FadeToBlack : MonoBehaviour
{
	private MeshRenderer myRenderer;

	public GameObject player;
	public GameObject spawnPoint;
	public GameObject stairFence;
	
	public Text uiTextControlHint;
	public Text uiTextThought;
	
	
	void Update () {
		if (GameManager.fadeToBlack && Input.GetKey(KeyCode.Space))
		{
			player.transform.position = spawnPoint.transform.position;
			stairFence.gameObject.SetActive(true);
			uiTextControlHint.gameObject.SetActive(false);
			uiTextThought.text = "1 month later...";
			GameManager.monthLater = true;
		}
	}
}
