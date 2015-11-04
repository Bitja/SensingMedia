using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CylFollowAni : MonoBehaviour {

    private Vector3 moveR;
    private GameObject mTut, mStart;

    public GameObject objDialog, planeRune, pathButtonObj, transImage, circles, widget1, widget2, widget3, panel, runeBack, cylFollowAni;
    private Text dialog;
    public Image imgBack;
    public static int tutorialState = 0;

    void Start() {
        mStart = GameObject.Find("CylinderStart");
        mTut = GameObject.Find("CylinderFollow");
        moveR = new Vector3(5.0f, 0.0f, 0.0f);
        dialog = objDialog.GetComponent<Text>();
        pathButtonObj.SetActive(false);
        transImage.SetActive(false);
        circles.SetActive(false);
        widget1.SetActive(false);
        widget2.SetActive(false);
        widget3.SetActive(false);
        imgBack.enabled = false;
        PathTracer.guiScore.enabled = false;
        PathTracer.guiTime.enabled = false;
        runeBack.SetActive(false);
        panel.SetActive(false);
        cylFollowAni.SetActive(false);
    }

    public void restartTutorial() {
        if (tutorialState == 2) {
            mTut.transform.position -= moveR;
        }
        else if (tutorialState >= 3) {
            mTut.transform.position -= moveR * 2;
            mStart.transform.position -= moveR;
        }
        // the following order matters: Start() at the button with widget1 after!
        tutorialState = 0;
        dialog.enabled = true;
        dialog.text = "Imitate the animation with the tangible widget. \n Firstly, place it on the touch screen.";
        mStart.SetActive(true);
        mTut.SetActive(true);
        
        Start();
        widget1.SetActive(true);
        runeBack.SetActive(true);
        panel.SetActive(true);
    }

    public void playAnimation() {
        dialog.text = "Imitate the animation with the tangible widget. \n Firstly, place it on the touch screen.";
        widget1.SetActive(true);
        runeBack.SetActive(true);
        panel.SetActive(true);
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "CylinderMouseTut") {
            if (tutorialState == 0) {
                mTut.transform.position += moveR;
                cylFollowAni.SetActive(true);
                widget1.SetActive(false);
                tutorialState++;
            }
            if (tutorialState == 2) {
                mStart.SetActive(false);
                widget2.SetActive(false);
                mTut.transform.position += moveR;
                tutorialState++;
            }
            if (tutorialState == 4) {
                dialog.text = "";
                mStart.SetActive(false);
                widget3.SetActive(false);
                pathButtonObj.SetActive(true);
                tutorialState++;
            }
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject.name == "CylinderMouseTut") {
            if (tutorialState == 1) {
                dialog.text = "Drag it to the blue circle.";
                widget2.SetActive(true);
                tutorialState++;
            }
            if (tutorialState == 3) {
                dialog.text = "Now, drag it to the next blue circle. \n Notice how the widget light changes near the blue circle.";
                widget3.SetActive(true);
                mStart.SetActive(true);
                mStart.transform.position += moveR;
                tutorialState++;
            }
        }
    }

    public void pathState() {
        dialog.text = "Drag the widget along the line from the left circle to the right. \n Notice how the ligth changes, when you leave the path.";
        imgBack.enabled = true;
        transImage.SetActive(true);
        panel.SetActive(false);
        mTut.SetActive(false);
        mStart.SetActive(false);
        pathButtonObj.SetActive(false);
        circles.SetActive(true);
        GameObject.Find("CylinderMouseTut").transform.position += new Vector3(0.0f, 50.0f, 0.0f); //moves mouse away from screen view
        imgBack.CrossFadeAlpha(0.0f, 2.0f, true);
        tutorialState++;
    }
}
