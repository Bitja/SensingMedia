using UnityEngine;
using System.Collections;



public class WhitePixelCount : MonoBehaviour {
    public Texture2D OriTex;
    public Texture2D EndTex;
    private Color white = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    private int matches = 0;
    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material.mainTexture = OriTex;
        GetComponent<Renderer>().material.
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("t"))
        {
            CountPixels(OriTex, white);
            Debug.Log(matches);
        }
        if (Input.GetKey("y"))
        {
            CountPixels(EndTex, white);
            Debug.Log(matches);        
        }
        
    }
    // Return the number of matching pixels.
    private int CountPixels(Texture2D bm, Color target_color)
    {
        // Loop through the pixels.
       
        for (int y = 0; y < bm.height; y++)
        {
            for (int x = 0; x < bm.width; x++)
            {
                if (bm.GetPixel(x, y) == target_color) matches++;
            }
        }
        return matches;
    }
}
