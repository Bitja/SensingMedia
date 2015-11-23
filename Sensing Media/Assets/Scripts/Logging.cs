using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;

public class Logging : MonoBehaviour {

    public static void log(string dir, string content)
    {
        dir = Application.persistentDataPath + "/" + dir;
        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(dir, true))
        {
            sw.WriteLine(content);
        }
    }

}