using UnityEngine;
using System.Collections;

public class lampGlow : MonoBehaviour {

	int intensity = 1; //0-255
	int t = 0;
	public Shader lerpedColor;
	public Color color0;


	void Start () {


	}
	
	void Update () {
		t = 1 / intensity; //0-1
		color0 = Color.Lerp(Color.white, Color.black, t);
		gameObject.GetComponent<Renderer>().material.color = Color(0.777, 08, 0.604);

	}
	public void glowSlider(int newIntensity){
		intensity = newIntensity;
		Debug.Log (newIntensity);
	}
}
