using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;

public class Logging : MonoBehaviour {
	public GameObject MyText;
	private Text VisibleText;

	void Start(){

		VisibleText = MyText.GetComponent<Text> ();
	}
	void Update(){
		string fileName = "text1.txt";
		string path = Application.persistentDataPath + "/" + fileName;
		VisibleText.text = path;
		using (System.IO.StreamWriter sw = new System.IO.StreamWriter (path, true)) {
			sw.WriteLine ("Hello World");
		}
		Debug.Log (VisibleText.text);
	}

}
