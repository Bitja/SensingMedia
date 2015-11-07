using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CylFollowAni : MonoBehaviour {

    private Vector3 moveR;
    private GameObject mTut, mStart;

	public GameObject objDialog, objDialog2, planeRune, pathButtonObj, transImage, circles, widget1, widget2, widget3, panel, runeBack, cylFollowAni;
    private Text dialog;
	private Text dialog2;
	public Image imgBack;
    public static int tutorialState = 0;

    void Start() {
        mStart = GameObject.Find("CylinderStart");
        mTut = GameObject.Find("CylinderFollow");
        moveR = new Vector3(5.0f, 0.0f, 0.0f);
        dialog = objDialog.GetComponent<Text>();
		dialog2 = objDialog2.GetComponent<Text>();
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
        dialog.text = "To unlock the rune, first I have to place my widget on the light. \n Like this!";
        mStart.SetActive(true);
        mTut.SetActive(true);
        
        Start();
        widget1.SetActive(true);
        runeBack.SetActive(true);
        panel.SetActive(true);
    }

    public void playAnimation() {
        dialog.text = "To unlock the rune, first I have to place my widget on the light. \n Like this!";
        widget1.SetActive(true);
        runeBack.SetActive(true);
        panel.SetActive(true);
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "CylinderMouseTut") {
            if (tutorialState == 0) {
				GradiantLamp.skammekrog = false;
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
				GradiantLamp.skammekrog = true;
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
				dialog.text = "Then I have to draw the rune, by dragging the widget across the stone.";
                widget2.SetActive(true);
                tutorialState++;
            }
            if (tutorialState == 3) {
                dialog.text = "And I have to continue drawing, all the way to the end. \n Look how the light changes! It's showing me the way.";
                widget3.SetActive(true);
                mStart.SetActive(true);
                mStart.transform.position += moveR;
                tutorialState++;

            }
        }
    }

    public void pathState() {
        dialog2.text = "Okay this is the real deal! I have to draw this rune starting from the left circle to the right. \n The light will help me stay on track.";
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
