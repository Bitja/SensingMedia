using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GradiantLamp : MonoBehaviour {

    public Color colorStart;
    public Color colorMiddle;
    public Color colorEnd;
    private Renderer rend;
    public float intencity;
    public bool isOn = true;
    private GameObject distance01;
    private GameObject mouse;
    private float newLerb;
    public float drawDistance = 5; // middle colour
    public Vector3[] distanceBoxes = new Vector3[3];
    //private float distance;

    public void toggle(bool b) {
        isOn = b;
    }
    void Start() {
        rend = GetComponentInChildren<Renderer>();
        distance01 = GameObject.Find("Distance01");
        mouse = GameObject.Find("MouseGradient");
    }

    void Update() {
        rend.enabled = false;
        
        if (isOn && PathTracer.nearestP <= 0.99) {
            rend.enabled = true;
            rend.material.color = Color.Lerp(colorStart, colorMiddle, PathTracer.nearestP);
            //Debug.Log("<0.99" + rend.material.color);
        }
        else if (isOn && PathTracer.nearestP >= 1) {
            /*for (int i = 0; i < distanceBoxes.Length; i++) {
                distance01.transform.position = distanceBoxes[i];
                distance = Vector3.Distance(mouse.transform.position, distance01.transform.position);
            }*/

            float distance = Vector3.Distance(mouse.transform.position, distance01.transform.position);
            newLerb = distance / drawDistance;
            rend.enabled = true;
            rend.material.color = Color.Lerp(colorMiddle, colorEnd, PathTracer.nearestP);
            //Debug.Log(">1"+rend.material.color);
        }
    }
}