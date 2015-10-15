using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasToggle : MonoBehaviour {

    public Image imgStart;
    public Image imgBack;
    //public ParticleSystem ParticleDown;

    public void CanvasHide() {
        imgStart.CrossFadeAlpha(0.0f, 0.5f, true);
        imgBack.CrossFadeAlpha(0.0f, 2.0f, true);
        //ParticleDown.Clear(true);
        GameObject cyl = GameObject.Find("CylinderStart");
        cyl.SetActive(false);
        GameObject.Find("TextAnimation").SetActive(false);
    }
}
