using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text counterText;
	private float mytimer= 60;
	private int seconds; 
	private int minutes = 2;
       
	public void resetTimer(){
		mytimer = 10;
		minutes = 0;
	}
	void Start () {
        counterText = GetComponent<Text>() as Text;
	}
	
	void Update () {
		mytimer -= Time.deltaTime;
		seconds = (int)mytimer;
		//Debug.Log (seconds);
       	if (mytimer < 0) {
			mytimer = 60;
			minutes--;
		}
		counterText.text = minutes + ":" + seconds;
		if (minutes <= 0 && mytimer <= 1) {
			Debug.Log("HIII");
			Handler.end ();

		}
     }
}

