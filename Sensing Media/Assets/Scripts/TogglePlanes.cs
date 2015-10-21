using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TogglePlanes : MonoBehaviour {

	public Image plane;


	void Start(){

		plane.enabled = false;

	}
	public void PlaneShow() {	
		plane.enabled = true;
	}
	public void PlaneHide() {	
		plane.enabled = false;
		
		
	}
}
