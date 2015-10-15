using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GradientColor : MonoBehaviour {

    public Color colorStart;
    public Color colorMiddle;
    public Color colorEnd;
    public float drawDistance = 5; // distance: middle -> end colour
    public float intencity;

    private bool isOn = false;
    private Renderer rend;
    private GameObject distance01;
    private GameObject mouseCol;
    private float newLerb;
    public int threshold2 = 0;
    
    // PathTracer.width is the 1st threshold,
    // and newLerp is the 2nd threshold.

    public void toggle(bool b) {
        isOn = b;
    }
    void Start() {
        rend = GetComponentInChildren<Renderer>();
        distance01 = GameObject.Find("Distance01");
        mouseCol = GameObject.Find("MouseColour");
        threshold2 = PathTracer.width;
    }

    void OnTriggerEnter(Collider info) {
        if (info.tag == "Player") rend.material.color = colorEnd;
    }

    void Update() {
        rend.enabled = false;
        if (isOn && PathTracer.nearestP <= 0.99) {
            rend.enabled = true;
            rend.material.color = Color.Lerp(colorStart, colorMiddle, PathTracer.nearestP);
        }
        else if (isOn && PathTracer.nearestP >= 1) {
            // if collision (with edgecollider?) : change color to red or?

            
            float distance = Vector3.Distance(mouseCol.transform.position, distance01.transform.position);
            newLerb = distance / drawDistance;
            rend.enabled = true;
            rend.material.color = Color.Lerp(colorMiddle, colorEnd, newLerb);
        }
    }
}