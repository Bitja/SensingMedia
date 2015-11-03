using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewLevel : MonoBehaviour {
	public Texture2D[] myTextures = new Texture2D[1];
    public static Texture2D CurrentTex;
    private static Renderer rend;
    public static Texture2D clone;

	public static GameObject fadePlane1, fadePlane2, fadePlane3, fadePlane4;
	public static Image imageFadePlane1, imageFadePlane2, imageFadePlane3, imageFadePlane4;
 
    void Start (){
		rend = GetComponent<Renderer>();
		fadePlane1 = GameObject.Find ("ImagePlaneFade1");
		fadePlane2 = GameObject.Find ("ImagePlaneFade2");
		fadePlane3 = GameObject.Find ("ImagePlaneFade3");
		fadePlane4 = GameObject.Find ("ImagePlaneFade4");

		
		imageFadePlane1 = fadePlane1.GetComponent<Image>();
		imageFadePlane2 = fadePlane2.GetComponent<Image>();
		imageFadePlane3 = fadePlane3.GetComponent<Image>();
		imageFadePlane4 = fadePlane4.GetComponent<Image>();


		imageFadePlane1.enabled = false;
		imageFadePlane2.enabled = false;
		imageFadePlane3.enabled = false;
		imageFadePlane4.enabled = false;

		//myFadeTextures.enabled = false;
    }
	
	
	public void ChangeToTutorialScene(int sceneToChangeTo){
		CurrentTex = myTextures[sceneToChangeTo]; 
		rend.material.mainTexture = CurrentTex; 
		clone = Instantiate(CurrentTex);
		GetComponent<Renderer>().material.mainTexture = clone;
		PathTracer.toggle(false);
		Handler.reset();
		PathTracer.guiTime.enabled = false; 
		PathTracer.guiScore.enabled = false; 
	}

    public void ChangeToScene(int sceneToChangeTo){

        PathTracer.guiTime.enabled = false;
        PathTracer.guiScore.enabled = false;
		PathTracer.guiScoreBox.enabled = false;

		PathTracer.path1.SetActive (false);
		PathTracer.path2.SetActive (false);
		PathTracer.path3.SetActive (false);
		PathTracer.path4.SetActive (false);
		PathTracer.path5.SetActive (false);

		imageFadePlane1.enabled = false;
		imageFadePlane2.enabled = false;
		imageFadePlane3.enabled = false;
		imageFadePlane4.enabled = false;
	
		if (sceneToChangeTo == 1) {
			imageFadePlane1.enabled = true;
			imageFadePlane1.CrossFadeAlpha (0.0f, 2.0f, true);
		}
		else if (sceneToChangeTo == 2) {
			imageFadePlane2.enabled = true;
			imageFadePlane2.CrossFadeAlpha (0.0f, 2.0f, true);
		} 
		else if (sceneToChangeTo == 3) {
			imageFadePlane3.enabled = true;
			imageFadePlane3.CrossFadeAlpha (0.0f, 2.0f, true);
		} 
		else if (sceneToChangeTo == 4) {
			imageFadePlane4.enabled = true;
			imageFadePlane4.CrossFadeAlpha (0.0f, 2.0f, true);
		}
		Debug.Log("Preparing...");
		CurrentTex = myTextures[sceneToChangeTo];
	
        rend.material.mainTexture = CurrentTex; 

        clone = Instantiate(CurrentTex);
        GetComponent<Renderer>().material.mainTexture = clone;
        PathTracer.toggle(false);
        Handler.reset();
	//	myFadeTextures[sceneToChangeTo].enabled = true;
	//	myFadeTextures[sceneToChangeTo].CrossFadeAlpha(0.0f, 2.0f, true);
    }
}