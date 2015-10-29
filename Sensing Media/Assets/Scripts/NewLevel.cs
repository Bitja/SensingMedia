using UnityEngine;
using System.Collections;

public class NewLevel : MonoBehaviour {
	public Texture2D[] myTextures = new Texture2D[1];
    public static Texture2D CurrentTex;
    private static Renderer rend;
    public static Texture2D clone;
 
    void Start (){
		rend = GetComponent<Renderer>();
    }

    public void ChangeToScene(int sceneToChangeTo){
<<<<<<< HEAD
        CurrentTex = myTextures[sceneToChangeTo]; 
=======
        PathTracer.guiTime.enabled = false;
        PathTracer.guiScore.enabled = false;
		PathTracer.guiScoreBox.enabled = false;

		PathTracer.path2.SetActive (false);
		PathTracer.path3.SetActive (false);
		PathTracer.path4.SetActive (false);

		imageFadePlane1.enabled = false;
		imageFadePlane2.enabled = false;
		imageFadePlane3.enabled = false;
		imageFadePlane4.enabled = false;

		if (sceneToChangeTo == 0) {
			Debug.Log ("changing scene");
			imageFadePlane1.enabled = true;
			imageFadePlane1.CrossFadeAlpha (0.0f, 2.0f, true);
			Debug.Log ("Fading");
		}
		else if (sceneToChangeTo == 1) {
			imageFadePlane2.enabled = true;
			imageFadePlane2.CrossFadeAlpha (0.0f, 2.0f, true);
		} 
		else if (sceneToChangeTo == 2) {
			imageFadePlane3.enabled = true;
			imageFadePlane3.CrossFadeAlpha (0.0f, 2.0f, true);
		} 
		else if (sceneToChangeTo == 3) {
			imageFadePlane4.enabled = true;
			imageFadePlane4.CrossFadeAlpha (0.0f, 2.0f, true);
		}

		CurrentTex = myTextures[sceneToChangeTo];
>>>>>>> Mette_Line
        rend.material.mainTexture = CurrentTex; 
        clone = Instantiate(CurrentTex);
        GetComponent<Renderer>().material.mainTexture = clone;
        PathTracer.toggle(false);
        Handler.reset();
<<<<<<< HEAD
        PathTracer.guiTime.enabled = false; 
        PathTracer.guiScore.enabled = false; 
=======
	//	myFadeTextures[sceneToChangeTo].enabled = true;
	//	myFadeTextures[sceneToChangeTo].CrossFadeAlpha(0.0f, 2.0f, true);
>>>>>>> Mette_Line
    }
}