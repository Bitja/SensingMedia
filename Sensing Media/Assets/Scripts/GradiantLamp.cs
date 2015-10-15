using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GradiantLamp : MonoBehaviour {

    public Color colorStart = Color.white;
    public Color colorMiddle = Color.blue;
    public Color colorEnd = Color.black;
    private Renderer rend;
    public float intencity;
    public bool isOn = true;
    private GameObject distance01;

    public void toggle(bool b) {
        isOn = b;
    }
    void Start() {
        rend = GetComponentInChildren<Renderer>();
        distance01 = GameObject.Find("Distance01");
    }

    void Update() {
        rend.enabled = false;
        Debug.Log(PathTracer.nearestP);
        if (isOn && PathTracer.nearestP <= 1) {
            Debug.Log("start ->");
            rend.enabled = true;
            rend.material.color = Color.Lerp(colorStart, colorMiddle, PathTracer.nearestP);
            Debug.Log("-> middle");
        }
        else {
            
            float distance = Vector3.Distance(Input.mousePosition, distance01.transform.position);
            float maxDistance = 10;
            float newLerb = distance / maxDistance;
            rend.material.color = Color.Lerp(colorMiddle, colorEnd, newLerb);
        }
              
       

    }
}