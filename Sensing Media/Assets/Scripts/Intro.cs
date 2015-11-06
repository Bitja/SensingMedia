using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Intro : MonoBehaviour {
	//Storyboards
	public Texture2D[] storyTextures = new Texture2D[3];
	private int currentStory = -1;
	private int totalStory = 2;//REMEMBER TO CHANGE THIS TO FIT # OF IMAGES
	public static Texture2D CurrentTex;
	private static Renderer rend;



	void Start (){
		rend = GetComponent<Renderer> ();
		rend.material.mainTexture = storyTextures[0];

	}

	public void nextStoryboard() {

		if (currentStory < totalStory) {
			currentStory++;
			CurrentTex = storyTextures [currentStory]; 
			rend.material.mainTexture = CurrentTex; 
		} 
		else {
			GameObject.Find("IntroNext").SetActive(false);
			GameObject.Find("StartTutorial").SetActive(true);
		}
	}
	
}
