using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lampGlow : MonoBehaviour {

    public Color colorStart = Color.white;
    public Color colorMiddle = Color.blue;
    public Color colorEnd = Color.black;
    private Renderer rend;
    public float intencity;
    public bool isOn = true;

    public void toggle(bool b) {
        isOn = b;
    }
    void Start() {
        rend = GetComponentInChildren<Renderer>();
    }

    void Update() {
        rend.enabled = false;
        if (isOn && PathTracer.nearestP <= 0.99) { // from start to middle
            rend.enabled = true;
            rend.material.color = Color.Lerp(colorStart, colorMiddle, PathTracer.nearestP * 100);
        }
        else if (isOn && PathTracer.nearestP >= 1) { // from middle to end
            rend.enabled = true;
            rend.material.color = Color.Lerp(colorMiddle, colorEnd, PathTracer.nearestP * 100);
        }
    }
}