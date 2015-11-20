using UnityEngine;
using System.Collections;
using System;

public class Logging : MonoBehaviour
{
    public string[] LabelsA;
    string print;
    string filename = "text1.txt";
    var documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        using(	System.IO.StreamWriter file = new System.IO.StreamWriter(documents + @"/" + filename,true))
        	{

        		for(int i =0; i < LabelsA.Length; i++)
        		{
        		print = LabelsA[i];
        		file.WriteLine(print);
        		}
        	}

    }
}