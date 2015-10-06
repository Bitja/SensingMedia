﻿using UnityEngine;
using System;

public class Handler : MonoBehaviour {

    private static int stage = 0;
    private static int state = 0;
    private static long timestampBeg = 0;
    private static long timestampEnd = 0;
    private static int countStart = 1;
    private static int countEnd = 0;
    private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private static data[] dataList = new data[5];

    public struct data
    {
        public long millis;
        public float accuracy;
        public int count;
    }

    public static void prepare()
    {
        if (state == 0)
        {
            state++;
            Debug.Log("Preparing for Start");
        }
    }

    public static void start()
    {
        if (state == 1)
        {
            state++;
            timestampBeg = getMillis();
            PathTracer.toggle(true);
            countStart = PathTracer.countPixels(Color.white);
            Debug.Log("Starting");
        }
    }

    public static void end()
    {
        if (state == 2)
        {
            state++;
            timestampEnd = getMillis();
            countEnd = PathTracer.countPixels(Color.white);

            dataList[stage] = new data();
            dataList[stage].millis = timestampEnd - timestampBeg;
            dataList[stage].accuracy = (countStart - countEnd) * 100.0f / countStart ;
            dataList[stage].count = countEnd;

            Debug.Log("Ending");
            Debug.Log("Time: " + (dataList[stage].millis / 1000.0f));
            Debug.Log("Accuracy: " + dataList[stage].accuracy);
        }
    }

    public static long getSeconds()
    {
        return (long)(DateTime.UtcNow - UnixEpoch).TotalSeconds;
    }

    public static long getMillis()
    {
        return (long)(DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
    }
}
