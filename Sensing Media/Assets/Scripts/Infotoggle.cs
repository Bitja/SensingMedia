using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Infotoggle : MonoBehaviour {

	public GameObject infoTextObject, infoPanelObject;
	public static GameObject infoButton;
	public static Image infoPanel;
	public static Text infoText;



	void Start () {
		infoButton = GameObject.Find ("InfoButton");
		infoText = infoTextObject.GetComponent<Text>();
		infoPanel = infoPanelObject.GetComponent<Image>();

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
			infoText.text = "Use widget with light in corner";
		}
		else if (PathTracer.currentLevel == 2) {
			infoText.text = "Use fingertouch with offset lamp";
		}
		else if (PathTracer.currentLevel == 3) {
			infoText.text = "Use fingertouch with lamp in corner";
		}		
		else if (PathTracer.currentLevel == 4) {
			infoText.text = "Use fingertouch with lamp in corner";
		}
		else if (PathTracer.currentLevel == 5) {
			infoText.text = "Thank you";
		}

	}
}
