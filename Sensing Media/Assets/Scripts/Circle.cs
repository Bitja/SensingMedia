﻿using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour {

    public static bool mouseEnabled = true;

    public int id;

    //private Color defaultColour;
    //private Color selectedColour = Color.red;
    //private Material mat;

	void Start () {
        //mat = GetComponent<SpriteRenderer>().material;
        //defaultColour = mat.color;
    }

    void OnCollisionEnter(Collision col) { //OnTouchDown() {
		if (col.gameObject.name == "CylinderMouse" && id==1
		    ||col.gameObject.name == "CylinderMouse2" && id==1
		    ||col.gameObject.name == "CylinderMouse3" && id==1
		    ||col.gameObject.name == "CylinderMouse4" && id==1
            || col.gameObject.name == "CylinderMouseTut" && id == 1) {
            Handler.prepare();
            mouseEnabled = false;
        }
       
        //mat.color = selectedColour;
    }
    void OnCollisionExit(Collision col) {//OnTouchExit() {
        if (id == 0 && mouseEnabled)
            Handler.start();
        else if (col.gameObject.name == "CylinderMouse" && id == 2
		         ||col.gameObject.name == "CylinderMouse2" && id == 2
		         ||col.gameObject.name == "CylinderMouse3" && id == 2
		         ||col.gameObject.name == "CylinderMouse4" && id == 2
                 || col.gameObject.name == "CylinderMouseTut" && id == 2) // moved here to cheat the delay! BUT: I can make it draw a bit more in the delay, just a tiny bit.
            Handler.end();
        //mat.color = defaultColour;
    }

    void Update() {
        mouseEnabled = true;
    }
}
