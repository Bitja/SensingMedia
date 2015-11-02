using UnityEngine;
using System.Collections;

public class mouseTutAni : MonoBehaviour {

    public Color colorStart, colorEnd;
    public GameObject mouse;
    public GameObject distanceUnit;
    private float unitDistance;
    private float lerb1;
    private Renderer rend;

    void Start() {
        rend = GetComponentInChildren<Renderer>();
    }

    void Update () {
        if (CylFollowAni.tutorialState == 4 || CylFollowAni.tutorialState == 5) {
            unitDistance = Vector3.Distance(mouse.transform.position, distanceUnit.transform.position);
            if (unitDistance < 3) {
                rend.material.color = colorStart;
            }
            else if (unitDistance < 5) {
                lerb1 = unitDistance / 5.0f;
                rend.material.color = Color.Lerp(colorStart, colorEnd, lerb1);
            }
            else if (unitDistance >= 5) {
                rend.material.color = colorEnd;
            }  
        }
    }
}
