using UnityEngine;
using System.Collections;

public class ToggleTutorial : MonoBehaviour {
	public GameObject tutorial;
	private bool IsEnabled = true;

	public void TutorialHide() {
		if (IsEnabled == true) {
			tutorial.SetActive (false);
			IsEnabled = false;
		} 
		else if (IsEnabled == false) {
			tutorial.SetActive (true);
			IsEnabled = true;
		}

	}
}
