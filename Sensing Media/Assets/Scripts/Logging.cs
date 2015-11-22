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
		string fileName = "text2.txt";
		string path = Application.persistentDataPath + "/" + fileName;
		VisibleText.text = path;
		using (System.IO.StreamWriter sw = new System.IO.StreamWriter (path, true)) {
			for(int i =0 ; i<=10; i++)
				sw.WriteLine (i);
		}

		using (System.IO.StreamReader sr = new System.IO.StreamReader (path, true)) {
			VisibleText.text = sr.ReadLine();
		Debug.Log (VisibleText.text);
	}

}
}