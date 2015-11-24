using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Infotoggle : MonoBehaviour {

	public GameObject infoTextObject, infoPanelObject, infoTextlvl1Object;
    public static GameObject infoButton, infoImage1, infoImage2, infoImage3, infoImage4, infoImage5, levelNameObj;
    public GameObject cube1, cube2, cube3, cube4, cube5;
	public static Image infoPanel;
	public static Text infoText, infoTextlvl1, lvlName;
	private int infoNr;

    void Start () {
		infoNr = StartMenu.testState;
		Debug.Log ("infoNr = " + infoNr);
		infoButton = GameObject.Find ("InfoButton");
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

 /*       cube1 = GameObject.Find("cube (1)");
        cube2 = GameObject.Find("cube (2)");
        cube3 = GameObject.Find("cube (3)");
        cube4 = GameObject.Find("cube (4)");
        cube5 = GameObject.Find("cube (5)");
        */
        cube1.SetActive(false);
        cube2.SetActive(false);
        cube3.SetActive(false);
        cube4.SetActive(false);
        cube5.SetActive(false);

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
        levelNameObj.SetActive(true);

        if (PathTracer.currentLevel == 0) {
			infoText.text = "Hello world";
            //infoTextlvl1.text = "Keep your eyes open for the line, it will disappear!";
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
				infoText.text = "<b>LENS</b> \nFor your next task, use the magic lens.";
                lvlName.text = "LENS";
                infoTextlvl1.text = "Keep your eyes open for the line, it will disappear!";
                infoImage1.SetActive (true);
                cube1.SetActive(false);
                cube2.SetActive(false);
                cube3.SetActive(false);
                cube4.SetActive(false);
                cube5.SetActive(false);
                infoNr++;
				Debug.Log ("2: infoNr = " + infoNr);

			}
			else if (infoNr == 2) {
				infoTextlvl1.enabled = false;
				infoText.text = "<b>FINGER OFFSET</b> \nFor your next task, the light feedback will have an offset from you finger.";
                lvlName.text = "FINGER OFFSET";
                infoImage2.SetActive (true);
                cube1.SetActive(false);
                cube2.SetActive(false);
                cube3.SetActive(false);
                cube4.SetActive(false);
                cube5.SetActive(false);
                infoNr++;
				Debug.Log ("3: infoNr = " + infoNr);

			}
			else if (infoNr == 3) {
				infoTextlvl1.enabled = false;
				infoText.text = "<b>GEM CORNER</b> \nFor your next task, use the magic gem with the light feedback in the corner.";
                lvlName.text = "GEM CORNER";
                infoImage3.SetActive (true);
                cube1.SetActive(true);
                cube2.SetActive(true);
                cube3.SetActive(true);
                cube4.SetActive(true);
                cube5.SetActive(true);
                infoNr++;
			}		
			else if (infoNr == 4) {
				infoTextlvl1.enabled = false;
				infoText.text = "<b>FINGER CORNER</b> \nFor your next task, use your finger with the light feedback in the corner.";
                lvlName.text = "FINGER CORNER";
                infoImage4.SetActive (true);
                cube1.SetActive(true);
                cube2.SetActive(true);
                cube3.SetActive(true);
                cube4.SetActive(true);
                cube5.SetActive(true);
                infoNr++;
			}
			else if (infoNr == 5) {
				infoTextlvl1.enabled = false;
				infoText.text = "<b>GEM OFFSET</b> \nFor your next task, the light feedback will have an offset from the magic gem.";
                lvlName.text = "GEM OFFSET";
                infoImage5.SetActive (true);
                cube1.SetActive(false);
                cube2.SetActive(false);
                cube3.SetActive(false);
                cube4.SetActive(false);
                cube5.SetActive(false);
                infoNr++;
			}

		}



        
	}
}
