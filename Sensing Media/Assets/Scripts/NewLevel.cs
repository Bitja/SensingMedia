using UnityEngine;
using System.Collections;

public class NewLevel : MonoBehaviour {
	public Texture[] myTextures = new Texture[2];
	private Renderer rend;

	void Start ()
	{
		rend = GetComponent<Renderer>();
	}
	
	
	public void ChangeToScene(int sceneToChangeTo){
		rend.material.mainTexture = myTextures[sceneToChangeTo];
	
	}
		
}