using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public void ChangeToState(int sceneToStateNr){
		if (sceneToStateNr == 0) {
			Application.LoadLevel ("State1");
		} 
		else if (sceneToStateNr == 1) {
		}
		else if (sceneToStateNr == 2) {
		}
		else if (sceneToStateNr == 3) {
		}
		else if (sceneToStateNr == 4) {
		}
	}	
}
	
