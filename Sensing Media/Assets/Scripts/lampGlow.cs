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
        if (isOn && PathTracer.nearestP <= 0.49) { // from start to middle
            Debug.Log("start ->");
            rend.enabled = true;
            rend.material.color = Color.Lerp(colorStart, colorMiddle, PathTracer.nearestPdelta * 100);
            Debug.Log("-> middle");
        }
        else if (isOn && PathTracer.nearestP >= 0.5) { // from middle to end
            Debug.Log("middle ->");
            rend.enabled = true;
            rend.material.color = Color.Lerp(colorMiddle, colorEnd, PathTracer.nearestPdelta * 100);
            Debug.Log("-> end");
        }

    }
}