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
        CurrentTex = myTextures[sceneToChangeTo]; 
        rend.material.mainTexture = CurrentTex; 
        clone = Instantiate(CurrentTex);
        GetComponent<Renderer>().material.mainTexture = clone;
        PathTracer.toggle(false);
        Handler.reset();
        PathTracer.guiTime.enabled = false; 
        PathTracer.guiScore.enabled = false; 
    }
}