using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GradiantLamp : MonoBehaviour {

    public Color colorStart, colorMiddle, colorMiddle2, colorEnd;

    public static Text guiSlider;
    public GameObject sliderObject;
    private Renderer rend;
    public bool isOn = true;
	public float threshold2 = 1.8F;
 
	private float closestDistance = 200;
	private float[] unitDistances = new float[17];//remember to change this to number of squares
	float distance;
    private GameObject mouse;
    private float newLerb;
	public List<GameObject> distanceUnits= new List<GameObject>();
    

    public void toggle(bool b) {
        isOn = b;
    }
	public void slider2(float t){
		threshold2 = t;
        guiSlider.text = "Threshold: " + t;
    }
    void Start() {
        rend = GetComponentInChildren<Renderer>();
        mouse = GameObject.Find("MouseGradient");
        guiSlider = sliderObject.GetComponent<Text>();
    }

    void Update() {
		rend.enabled = false;
	
		if (isOn && PathTracer.nearestP < 1) {
			rend.enabled = true;
			rend.material.color = Color.Lerp (colorStart, colorMiddle, PathTracer.nearestP);
		} 
		else if (isOn && PathTracer.nearestP >= 1) {
			for (int i = 0; i < distanceUnits.Count; i++) {
				unitDistances[i] = Vector3.Distance(mouse.transform.position, distanceUnits[i].transform.position);				 
			}
			for (int i = 0; i < unitDistances.Length; i++) {
				if (unitDistances [i] < closestDistance) {
					closestDistance = unitDistances[i];
				}
			}
			newLerb = closestDistance/threshold2;
			rend.enabled = true;
			rend.material.color = Color.Lerp (colorMiddle2, colorEnd,newLerb);
			closestDistance = 200;
		}

	}
}