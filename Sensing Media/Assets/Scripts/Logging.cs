using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;

public class Logging : MonoBehaviour {

    private static string URL = "http://www.Drakkashi.com/files/p7/_conn.php";
    private static string KEY = "t9XJs206xd";
    private static string DIR = Application.persistentDataPath + "/data.txt";

    private static Logging current;

    private WWW www;

    public Logging()
    {
        current = this;
        www = new WWW(URL);
        if (File.Exists(DIR))
            File.Delete(DIR);
    }

    public static void log(string data)
    {
        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(DIR, true))
        {
            sw.WriteLine(data);
        }
    }

    public IEnumerator SaveToMySQL(string id, int session, int countStart, int countEnd, long beg, long end, long timeOffPath)
    {
        string dataStr = File.ReadAllText(DIR);
        WWWForm form = new WWWForm();

        form.AddField("key", KEY);
        form.AddField("subject", id);
        form.AddField("session", session);
        form.AddField("hit", countEnd - countStart);
        form.AddField("total", countStart);
        form.AddField("elapsedTime", (end - beg) + "");
        form.AddField("timeOffPath", timeOffPath + "");
        form.AddField("data", dataStr);

        www = new WWW(URL, form);

        yield return www;
        string response = www.text;

        Debug.Log(response);
    }

    public static Logging getCurrent() {
        return current;
    }
}