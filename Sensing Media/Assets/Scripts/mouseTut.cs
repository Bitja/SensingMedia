using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class mouseTut : MonoBehaviour {

    private Renderer rend;

    float distance;
    public GameObject mouse;
    public GameObject distanceUnit;
    private float unitDistance;
    private float lerb1;
    private float lerb2;

    public Color colorStart, colorMiddle, colorMiddle2, colorEnd;
    public float threshold2 = 1.8F;

    private float closestDistance = 200;
    private float[] unitDistances = new float[30];//remember to change this to number of squares
 

    private float newLerb;
    public List<GameObject> distanceUnits = new List<GameObject>();

    void Start () {
        rend = GetComponentInChildren<Renderer>();
    }

    void Update() {
        if (CylFollowAni.tutorialState <= 2) {
            rend.material.color = colorStart;
        }
        if (CylFollowAni.tutorialState == 4 || CylFollowAni.tutorialState == 5) {
            unitDistance = Vector3.Distance(mouse.transform.position, distanceUnit.transform.position);
            //Debug.Log(unitDistance);
            if (unitDistance < 5.6) {
                rend.material.color = colorStart;
            }
            else if (unitDistance < 7) {
                lerb1 = unitDistance / 9.0f;
                rend.material.color = Color.Lerp(colorStart, colorEnd, lerb1);
            }
            else if (unitDistance >= 7)
                rend.material.color = colorEnd;
          
        }
        else if (CylFollowAni.tutorialState >=6) {
            rend.enabled = false;

            if (PathTracer.nearestP < 1) {
                rend.enabled = true;
                rend.material.color = Color.Lerp(colorStart, colorMiddle, PathTracer.nearestP);
            }
            else if (PathTracer.nearestP >= 1) {
                for (int i = 0; i < distanceUnits.Count; i++) {
                    unitDistances[i] = Vector3.Distance(mouse.transform.position, distanceUnits[i].transform.position);
                }
                for (int i = 0; i < unitDistances.Length; i++) {
                    if (unitDistances[i] < closestDistance) {
                        closestDistance = unitDistances[i];
                    }
                }
                newLerb = (closestDistance / threshold2) - 1;
                rend.enabled = true;
                rend.material.color = Color.Lerp(colorMiddle2, colorEnd, newLerb);
                closestDistance = 200;
            }
        }
    }
}
