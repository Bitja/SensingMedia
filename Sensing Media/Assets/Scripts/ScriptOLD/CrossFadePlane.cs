using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrossFadePlane : MonoBehaviour {

	public Image plane;
	
	void Start(){
		plane.enabled = false;
	}
	public void PlaneFadeIn() {	
		plane.enabled = true;
		plane.CrossFadeAlpha(0.0f, 2.0f, true);

	}
	public void PlaneFadeOut() {	
		plane.CrossFadeAlpha(0.0f, 0.0f, false);
		plane.enabled = false;
	}
}
