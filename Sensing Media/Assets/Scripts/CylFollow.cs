using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CylFollow : MonoBehaviour {

    private Color defaultColour = Color.blue;
    private Color selectedColour = Color.green;
    private Material mat;
    private Vector3 moveR;
    private GameObject mTut, mStart;

    public GameObject objDialog, diaPanel, planeRune, pathButtonObj, transImage, circles;
    public Image imgBack;
    private Text dialog;
    public static int tutorialState = 0;

    void Start() {
        mat = GetComponent<Renderer>().material;
        defaultColour = mat.color;
        mStart = GameObject.Find("CylinderStart");
        mTut = GameObject.Find("CylinderFollow");
        moveR = new Vector3(5.0f, 0.0f, 0.0f);
        //planeRune.SetActive(false);
        dialog = objDialog.GetComponent<Text>();
        dialog.text = "Move the tourch (the one in our hand) on the circle.";
        pathButtonObj.SetActive(false);
        transImage.SetActive(false);
        circles.SetActive(false);
    }

    // TODO: animation? isPlaying
    void OnCollisionEnter(Collision col) {
        mat.color = selectedColour;
        if (col.gameObject.name == "CylinderMouseTut") {
            if (tutorialState == 0) {
                mTut.transform.position += moveR;
                tutorialState++;
            }
            if (tutorialState == 2) {
                mStart.SetActive(false);
                mTut.transform.position += moveR;
                tutorialState++;
            }
            if (tutorialState == 4) {
                pathButtonObj.SetActive(true);
                tutorialState++;
            }
        }

    }

    void OnCollisionExit(Collision col) {
        mat.color = defaultColour;
        if (col.gameObject.name == "CylinderMouseTut") {
            if (tutorialState == 1) {
                dialog.text = "Follow the blue circle.";
                tutorialState++;
            }
            if (tutorialState == 3) {
                dialog.text = "Notice how the tourch light changes near the blue circle.";
                mStart.SetActive(true);
                mStart.transform.position += moveR;
                tutorialState++;
            }

        }
    }

    public void pathState() {
        transImage.SetActive(true);
        mTut.SetActive(false);
        mStart.SetActive(false);
        dialog.enabled = false;
        diaPanel.SetActive(false);
        pathButtonObj.SetActive(false);
        //planeRune.SetActive(true);
        circles.SetActive(true);
        GameObject.Find("CylinderMouseTut").transform.position += new Vector3(0.0f, 50.0f, 0.0f); //moves mouse away from screen view
        imgBack.CrossFadeAlpha(0.0f, 2.0f, true);
        Debug.Log(1);
    }
}
