using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Intro : MonoBehaviour {
	public Texture2D[] storyTextures = new Texture2D[1];
	private int currentStory = 0;
	public static Texture2D CurrentTex;
	private static Renderer rend;


	void Start (){
		rend = GetComponent<Renderer> ();
		rend.material.mainTexture = storyTextures[0];
	}

	public void nextStoryboard() {
		currentStory++;
		CurrentTex = storyTextures[currentStory]; 
		rend.material.mainTexture = CurrentTex; 
	}
	public void lastStoryboard(){

	}
}
