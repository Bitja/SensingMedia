using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasToggle : MonoBehaviour {

    public Canvas StartCanvas;

    public void CanvasHide() {
        GameObject plane = GameObject.Find("PlaneStart");
        //plane.GetComponent<UnityEngine.UI.Text>().CrossFadeAlpha(1f, 1.5f, false);
        StartCanvas.enabled = false;
        plane.SetActive(false);
    }
}
