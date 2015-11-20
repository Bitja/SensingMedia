using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text counterText;
	private float mytimer= 60;
	private int seconds; 
	private int minutes = 2;
	private bool isOn = false;
	public static bool timerFrozen = false;
	public GameObject timer;


	public void hideTimer(){
		timer.SetActive(false);
		isOn = false;
	}

	public void resetTimer(){
		timer.SetActive(true);		
		isOn = true;
		mytimer = 60;
		minutes = 2;
	}
	void Start () {
        counterText = GetComponent<Text>() as Text;
	}
	
	void Update () {
		if(timerFrozen ==false)
			mytimer -= Time.deltaTime;
		else if(timerFrozen == true)
			mytimer = mytimer;

		seconds = (int)mytimer;
		//Debug.Log (seconds);
       	if (mytimer < 0) {
			mytimer = 60;
			minutes--;
		}
		counterText.text = minutes + ":" + seconds.ToString("00");
		if (minutes <= 0 && mytimer <= 1) {
			Handler.end ();

		}
     }
}

