using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Infotoggle : MonoBehaviour {

	public GameObject infoTextObject, infoPanelObject;
	public static GameObject infoButton,infoImage1,infoImage2,infoImage3,infoImage4,infoImage5;
	public static Image infoPanel;
	public static Text infoText;



	void Start () {
		infoButton = GameObject.Find ("InfoButton");
		infoText = infoTextObject.GetComponent<Text>();
		infoPanel = infoPanelObject.GetComponent<Image>();

		infoImage1 = GameObject.Find ("InfoImage1");
		infoImage2 = GameObject.Find ("InfoImage2");
		infoImage3 = GameObject.Find ("InfoImage3");
		infoImage4 = GameObject.Find ("InfoImage4");
		infoImage5 = GameObject.Find ("InfoImage5");

		infoImage1.SetActive (false);
		infoImage2.SetActive (false);
		infoImage3.SetActive (false);
		infoImage4.SetActive (false);
		infoImage5.SetActive (false);

		infoButton.SetActive(false);
		infoText.enabled = false;
		infoPanel.enabled = false;
	
	}

	public static void showInfoButton(){
		infoButton.SetActive (true);
	}

	public void showInfo(){
		infoButton.SetActive (false);
		infoText.enabled = true;
		infoPanel.enabled = true;
		
		if (PathTracer.currentLevel == 0) {
			infoText.text = "Hello world";
		}
		else if (PathTracer.currentLevel == 1) {
			infoText.text = "For your next task, use the transparent widget.";
			infoImage1.SetActive (true);
		}
		else if (PathTracer.currentLevel == 2) {
			infoText.text = "For your next task, use your finger and the light following it.";
			infoImage2.SetActive (true);
		}
		else if (PathTracer.currentLevel == 3) {
			infoText.text = "For your next task, use the solid widget and the light in the corner.";
			infoImage3.SetActive (true);
		}		
		else if (PathTracer.currentLevel == 4) {
			infoText.text = "For your next task, use your finger and the light in the corner.";
			infoImage4.SetActive (true);
		}
		else if (PathTracer.currentLevel == 5) {
			infoText.text = "For your next task, use the solid widget and the light following it.";
			infoImage5.SetActive (true);
		}
		else if (PathTracer.currentLevel == 6) {
			infoText.text = "That was it for the test. Thank you for your participation.";
		}

	}
}
