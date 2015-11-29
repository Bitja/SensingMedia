using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Infotoggle : MonoBehaviour {

	public GameObject infoTextObject, infoPanelObject, infoTextlvl1Object;
    public static GameObject infoButton, infoButton2, infoButton3, infoButton4, infoButton5, infoImage1, infoImage2, infoImage3, infoImage4, infoImage5, levelNameObj;
	public static Image infoPanel;
	public static Text infoText, infoTextlvl1, lvlName;
	private int infoNr;

    void Start () {
		infoButton = GameObject.Find ("InfoButton");
        infoButton2 = GameObject.Find("InfoButton2");
        infoButton3 = GameObject.Find("InfoButton3");
        infoButton4 = GameObject.Find("InfoButton4");
        infoButton5 = GameObject.Find("InfoButton5");

        infoText = infoTextObject.GetComponent<Text>();
        infoTextlvl1 = infoTextlvl1Object.GetComponent<Text>();
        infoPanel = infoPanelObject.GetComponent<Image>();

        levelNameObj = GameObject.Find("LevelName");
        levelNameObj.SetActive(false);
        lvlName = levelNameObj.GetComponent<Text>();

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
        infoButton2.SetActive(false);
        infoButton3.SetActive(false);
        infoButton4.SetActive(false);
        infoButton5.SetActive(false);

        infoText.enabled = false;
        infoTextlvl1.enabled = false;
        infoPanel.enabled = false;
	
	}

	public static void showInfoButton(){
        if (PathTracer.currentLevel == 1)
            infoButton.SetActive(true);
        else if (PathTracer.currentLevel == 2)
            infoButton2.SetActive(true);
        else if (PathTracer.currentLevel == 3)
            infoButton3.SetActive(true);
        else if (PathTracer.currentLevel == 4)
            infoButton4.SetActive(true);
        else if (PathTracer.currentLevel == 5)
            infoButton5.SetActive(true);
        //        infoButton.SetActive (true);
	}

	public void showInfo(){

        infoNr = ChangePath.typeOfPath;
        infoButton.SetActive (false);
        infoButton2.SetActive(false);
        infoButton3.SetActive(false);
        infoButton4.SetActive(false);
        infoButton5.SetActive(false);

        infoText.enabled = true;
        infoTextlvl1.enabled = true;
        infoPanel.enabled = true;
        levelNameObj.SetActive(true);

        if (PathTracer.currentLevel == 0) {
			infoText.text = "Hello world";
            //infoTextlvl1.text = "Keep your eyes open for the line, it will disappear!";
            //infoImage1.SetActive(true);
		}
		else if (PathTracer.currentLevel == 6) {
			infoTextlvl1.enabled = false;
			infoText.text = "That was it for the test. Thank you for your participation.";
		}
		else if(PathTracer.currentLevel <= 5 && PathTracer.currentLevel >= 1){
          //  if (infoNr >5)
			//	infoNr = 1;

			if (infoNr == 1) {
				infoText.text = "<color=black>LENS </color>\nFor your next task, use the magic lens.";
                lvlName.text = "LENS";
                infoTextlvl1.text = "Keep your eyes open for the line, it will disappear!";
                infoImage1.SetActive (true);
				Debug.Log ("1: infoNr = " + infoNr);

			}
			else if (infoNr == 2) {
				infoTextlvl1.enabled = false;
				infoText.text = "<color=black>FINGER OFFSET</color> \nFor your next task, the light feedback will have an offset from you finger.";
                lvlName.text = "FINGER OFFSET";
                infoImage2.SetActive (true);
				Debug.Log ("2: infoNr = " + infoNr);

			}
			else if (infoNr == 3) {
                infoTextlvl1.enabled = false;
                infoText.text = "<color=black>FINGER CORNER</color> \nFor your next task, use your finger with the light feedback in the corner.";
                lvlName.text = "FINGER CORNER";
                infoImage3.SetActive(true);
            }
            else if (infoNr == 4) {
                infoTextlvl1.enabled = false;
                infoText.text = "<color=black>GEM OFFSET</color> \nFor your next task, the light feedback will have an offset from the magic gem.";
                lvlName.text = "GEM OFFSET";
                infoImage4.SetActive(true);
            }
			else if (infoNr == 5) {
                infoTextlvl1.enabled = false;
                infoText.text = "<color=black>GEM CORNER</color> \nFor your next task, use the magic gem with the light feedback in the corner.";
                lvlName.text = "GEM CORNER";
                infoImage5.SetActive(true);
            }

		}



        
	}
}
