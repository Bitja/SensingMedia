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

    void OnTouchDown() {
        if (id == 1)
        {
            Handler.prepare();
            mouseEnabled = false;
        }
        else if (id == 2)
            Handler.end();
        mat.color = selectedColour;
    }
    void OnTouchExit() {
        if (id == 0 && mouseEnabled)
            Handler.start();
        mat.color = defaultColour;
    }

    void Update()
    {
        mouseEnabled = true;
        /*if (ChangeScene.changedScene) {
            mouseEnabled = false;
        }*/

    }
}
