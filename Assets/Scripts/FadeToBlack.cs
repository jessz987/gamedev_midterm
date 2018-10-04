using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
	private MeshRenderer myRenderer;
	
	void Start ()
	{
		myRenderer = GetComponent<MeshRenderer>();
	}
	
	void Update () {
		if (GameManager.fadeToBlack)
		{
			
		}
	}
}
