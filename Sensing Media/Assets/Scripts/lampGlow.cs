using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lampGlow : MonoBehaviour {

	public Color colorStart = Color.white;
	public Color colorEnd = Color.black;
	public float duration = 1.0F;
	public Renderer rend;
	public float intencity;

	void Start () {

		rend = GetComponent<Renderer>();

	}
	public void LightIntencity(float newIntencity) {
		intencity = newIntencity;
		Debug.Log (intencity);


	
	}

	void Update () {
		//float intencity = Mathf.PingPong(Time.time, duration) / duration;
		rend.material.color = Color.Lerp(colorStart, colorEnd, intencity);
	//	Debug.Log (intencity);


	}
}
