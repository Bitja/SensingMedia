using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GradiantLamp : MonoBehaviour {

    public Color colorStart, colorMiddle, colorMiddle2, colorEnd;

    private Renderer rend;
    public bool isOn = false;
	public bool skammekrog = false;
		public float moveSpeed = 1.0f;

	public float threshold2 = 1.8F;
 
	private float closestDistance = 200;
	private float[] unitDistances = new float[30];//remember to change this to number of squares
	float distance;
    public GameObject mouse;
    private float newLerb;
	public static float mirrorLerb;
	public List<GameObject> distanceUnits= new List<GameObject>();
    

    public void toggleOn() {
        isOn = true;
    }
	public void toggleOff() {
		isOn = false;
	}
	public void changeToAlpha(){

		if (skammekrog == false) {
			//mouse.layer = LayerMask.NameToLayer ("IgnoreLight");
			skammekrog = true;
			
		} 
		else {
			//mouse.layer = LayerMask.NameToLayer ("mouseLight");
			skammekrog = false;
		}
	}



    void Start() {
      	rend = GetComponentInChildren<Renderer>();


		//mouse = GameObject.Find("CylinderMouse");
    }

    void Update() {
		Color alphaColor = rend.material.color;
		rend.enabled = false;

		if (skammekrog == false) {
			if (isOn && PathTracer.nearestP < 1) {
				//Debug.Log ("hi");
				rend.enabled = true;
				rend.material.color = Color.Lerp (colorStart, colorMiddle, PathTracer.nearestP);
			} else if (isOn && PathTracer.nearestP >= 1) {
				for (int i = 0; i < distanceUnits.Count; i++) {
					unitDistances [i] = Vector3.Distance (mouse.transform.position, distanceUnits [i].transform.position);				 
				}
				for (int i = 0; i < unitDistances.Length; i++) {
					if (unitDistances [i] < closestDistance) {
						closestDistance = unitDistances [i];
					}
				}
				//Debug.Log(closestDistance);
				newLerb = closestDistance / threshold2;
				rend.enabled = true;
				rend.material.color = Color.Lerp (colorMiddle2, colorEnd, newLerb);
				closestDistance = 200;
			}
		} 
		else if (skammekrog == true) {

			alphaColor.a = 0.0f;//set alpha to 0
			if (isOn && PathTracer.nearestP >= 1) {
				for (int i = 0; i < distanceUnits.Count; i++) {
					unitDistances [i] = Vector3.Distance (mouse.transform.position, distanceUnits [i].transform.position);				 
				}
				for (int i = 0; i < unitDistances.Length; i++) {
					if (unitDistances [i] < closestDistance) {
						closestDistance = unitDistances [i];
					}
				}
				mirrorLerb = closestDistance / threshold2;
				Debug.Log (mirrorLerb);
			}
			closestDistance = 200;
		}

	}
}