using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour {

    public static bool mouseEnabled = true;

    public int id;

    private Color defaultColour;
    private Color selectedColour = Color.red;
    private Material mat;

	void Start () {
        mat = GetComponent<SpriteRenderer>().material;
        defaultColour = mat.color;
    }

    void OnCollisionEnter(Collision col) { //OnTouchDown() {
        if (col.gameObject.name == "CylinderMouse" && id==1) { 
            Handler.prepare();
            mouseEnabled = false;
        }
        else if (col.gameObject.name == "CylinderMouse" && id==2)
            Handler.end();          // fejl
        mat.color = selectedColour;
    }
    void OnCollisionExit(Collision col) {//OnTouchExit() {
        if (id == 0 && mouseEnabled)
            Handler.start();
        mat.color = defaultColour;
    }

    void Update() {
        mouseEnabled = true;
    }
}
