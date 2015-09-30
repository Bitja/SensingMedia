using UnityEngine;
using System.Collections;
using System;

public class GetTime : MonoBehaviour
{
    public long time = 0;
    // Use this for initialization
    void Start()
    {

    }
    private static readonly DateTime UnixEpoch =
    new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static long GetCurrentUnixTimestampSeconds()
    {
        return (long)(DateTime.UtcNow - UnixEpoch).TotalSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter("c:/Users/Kronborg/Documents/TESTEST.txt", true))
        {
            long newTime = GetTime.GetCurrentUnixTimestampSeconds();
            if (Input.GetKey("w")  && time == 0 || time != newTime)
            {
                
              //  if (time == 0 || time != newTime)
               // {
                    time = newTime;
                    file.WriteLine(GetCurrentUnixTimestampSeconds());
               // }
            }
        }
    }
}
