using UnityEngine;
using System.Collections;
/*
public class BresenhamLines : MonoBehaviour {
    
    private Texture2D texture;
    public int texture_width = 256;
    public int texture_height = 256;
    private bool point1 = false;
    private bool point2 = false;
    private Vector2 startpoint;
    private Vector2 endpoint;
    private Vector2 pixelUV;

    void Start() {
        texture = new Texture2D(texture_width, texture_height);
        GetComponent<Renderer>().material.mainTexture = texture;
    }
    
    void Update() {
        // draw lines with mouse
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, hit, 100)) {
                if (!point1) {
                    pixelUV = hit.textureCoord;
                    pixelUV.x *= texture.width;
                    pixelUV.y *= texture.height;
                    startpoint = Vector2(pixelUV.x, pixelUV.y);
                    point1 = true;

                    print(startpoint);
                }
                else {
                    pixelUV = hit.textureCoord;
                    pixelUV.x *= texture.width;
                    pixelUV.y *= texture.height;
                    endpoint = Vector2(pixelUV.x, pixelUV.y);
                    point1 = false;
                    drawLine(startpoint.x, startpoint.y, endpoint.x, endpoint.y);
                    print(endpoint);
                }
            }
        }
    }



    // from wikipedia
    void drawLine(int x0, int y0, int x1, int y1) {
        int dx = Mathf.Abs(x1 - x0);
        int dy = Mathf.Abs(y1 - y0);
        if (x0 < x1) { sx = 1; } else { sx = -1; }
        if (y0 < y1) { sy = 1; } else { sy = -1; }
        int err = dx - dy;

        bool loop = true;
        while (loop) {
            texture.SetPixel(x0, y0, Color(1, 1, 1, 1));
            if ((x0 == x1) && (y0 == y1)) loop = false;
            e2 = 2 * err;
            if (e2 > -dy) {
                err = err - dy;
                x0 = x0 + sx;
            }
            if (e2 < dx) {
                err = err + dx;
                y0 = y0 + sy;
            }
        }
        texture.Apply();
    }
    
}*/