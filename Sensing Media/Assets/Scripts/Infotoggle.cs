using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Infotoggle : MonoBehaviour {

	public GameObject infoTextObject, infoPanelObject, infoTextlvl1Object;
	public static GameObject infoButton,infoImage1,infoImage2,infoImage3,infoImage4,infoImage5;
	public static Image infoPanel;
	public static Text infoText, infoTextlvl1;
	private int infoNr;

    void Start () {
		infoNr = StartMenu.testState;
		Debug.Log ("infoNr = " + infoNr);
		infoButton = GameObject.Find ("InfoButton");
		infoText = infoTextObject.GetComponent<Text>();
        infoTextlvl1 = infoTextlvl1Object.GetComponent<Text>();
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
        infoTextlvl1.enabled = false;
        infoPanel.enabled = false;
	
	}

	public static void showInfoButton(){
		infoButton.SetActive (true);
	}

	public void showInfo(){
		infoButton.SetActive (false);
		infoText.enabled = true;
        infoTextlvl1.enabled = true;
        infoPanel.enabled = true;
		
		if (PathTracer.currentLevel == 0) {
			infoText.text = "Hello world";
            infoTextlvl1.text = "Keep our eyes open for the line, it will disappear!";
            infoImage1.SetActive(true);
		}
		else if (PathTracer.currentLevel == 6) {
			infoTextlvl1.enabled = false;
			infoText.text = "That was it for the test. Thank you for your participation.";
		}
		else if(PathTracer.currentLevel <= 5 && PathTracer.currentLevel >= 1){
			
			if(infoNr >5)
				infoNr = 1;

			if (infoNr == 1) {
				infoText.text = "For your next task, use the magic lens.";
				infoTextlvl1.text = "Keep our eyes open for the line, it will disappear!";
				infoImage1.SetActive (true);
				infoNr++;
				Debug.Log ("2: infoNr = " + infoNr);

			}
			else if (infoNr == 2) {
				infoTextlvl1.enabled = false;
				infoText.text = "For your next task, use your finger and the light next to it.";
				infoImage2.SetActive (true);
				infoNr++;
				Debug.Log ("3: infoNr = " + infoNr);

			}
			else if (infoNr == 3) {
				infoTextlvl1.enabled = false;
				infoText.text = "For your next task, use the magic gem and the light in the corner.";
				infoImage3.SetActive (true);
				infoNr++;
			}		
			else if (infoNr == 4) {
				infoTextlvl1.enabled = false;
				infoText.text = "For your next task, use your finger and the light in the corner.";
				infoImage4.SetActive (true);
				infoNr++;
			}
			else if (infoNr == 5) {
				infoTextlvl1.enabled = false;
				infoText.text = "For your next task, use the magic gem and the light next to it.";
				infoImage5.SetActive (true);
				infoNr++;
			}

		}



        
	}
}
