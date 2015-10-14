using UnityEngine;
using System.Collections;

public class NewLevel : MonoBehaviour {
	public Texture2D[] myTextures = new Texture2D[3];
    public static Texture2D CurrentTex;
    private static Renderer rend;
    public static Texture2D clone;
    private MeshFilter plane;


    void Start (){
		rend = GetComponent<Renderer>();
        plane = GetComponent(typeof(MeshFilter)) as MeshFilter;
    }

    public void ChangeToScene(int sceneToChangeTo){
        CurrentTex = myTextures[sceneToChangeTo];
        rend.material.mainTexture = CurrentTex; //fejl
        clone = Instantiate(CurrentTex);
        GetComponent<Renderer>().material.mainTexture = clone;
        PathTracer.toggle(false);
        Handler.reset();
    }
}