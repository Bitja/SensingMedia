using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class mouseTut : MonoBehaviour {


	public static bool skammekrog;

	public float moveSpeed = 1.0f;


    private Renderer rend;
	public Color colorStart, colorEnd;
	public GameObject mouse;
	public GameObject distanceUnit;
	private float unitDistance;
	private float lerb1;

	void Start() {
		rend = GetComponentInChildren<Renderer>();
	}
	
	void Update () {
		//Debug.Log (CylFollowAni.tutorialState);
		rend.enabled = false;
		Color alphaColor = rend.material.color;

		if (CylFollowAni.tutorialState == 0 ||CylFollowAni.tutorialState == 1 ||CylFollowAni.tutorialState == 2||CylFollowAni.tutorialState == 3||CylFollowAni.tutorialState == 5) {
			alphaColor.a = 0.0f;//set alpha to 0
		}
		else if (CylFollowAni.tutorialState == 4) {
			rend.enabled = true;
			unitDistance = Vector3.Distance(mouse.transform.position, distanceUnit.transform.position);
			lerb1 = unitDistance-5.0f;
			//Debug.Log (lerb1);
			rend.material.color = Color.Lerp(colorStart, colorEnd, lerb1);
		
		}
	}
}
