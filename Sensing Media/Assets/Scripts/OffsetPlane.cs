using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OffsetPlane : MonoBehaviour {
	public GameObject plane;
	
	
	void Start(){
		
		plane.SetActive(false);
		
	}
	public void PlaneActive() {	
		plane.SetActive(true);
		
	}
	public void PlaneInactive() {	
		plane.SetActive(false);
	}
}