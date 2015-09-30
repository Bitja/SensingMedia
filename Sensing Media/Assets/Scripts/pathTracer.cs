using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class pathTracer : MonoBehaviour {

    public float moveSpeed = 1.0f;

    private float mapX = 100.0f, mapY = 100.0f;
    private float minX, maxX, minY, maxY;
    public Texture2D texture;
    private Texture2D clone;

    void Start() {
        clone = Instantiate(texture);
        GetComponent<Renderer>().material.mainTexture = clone;
        //clone.SetPixel(0, 0, Color.red);
        //clone.Apply();
    }
     /*
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        // Calculations assume map is position at the origin
        minX = horzExtent - mapX / 2.0f;
        maxX = mapX / 2.0f - horzExtent;
        minY = vertExtent - mapY / 2.0f;
        maxY = mapY / 2.0f - vertExtent;
    }

    void LateUpdate() {
        Vector3 v3 = transform.position;
        v3.x = Mathf.Clamp(v3.x, minX, maxX);
        v3.y = Mathf.Clamp(v3.y, minY, maxY);
        transform.position = v3;
    } */

    void Update() {
        if (Input.GetMouseButton(0)) {
            // Send a ray to collide with the plane
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) {
                // Find the u,v coordinate of the Texture
                Vector2 uv;
                uv.x = (hit.point.x - hit.collider.bounds.min.x) / hit.collider.bounds.size.x;
                uv.y = (hit.point.y - hit.collider.bounds.min.y) / hit.collider.bounds.size.y;
                // Paint it red
                Texture2D tex = (Texture2D)hit.transform.gameObject.GetComponent<Renderer>().sharedMaterial.mainTexture;
                tex.SetPixel((int)(uv.x * tex.width), (int)(uv.y * tex.height), Color.red);
                tex.Apply();
            }
        }
        /*
        if (Input.GetMouseButton(0)) {
            Vector3 mousePosition = Input.mousePosition;
            //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            //mousePosition = Camera.main.WorldToScreenPoint(mousePosition); // coord in pixels

            
            int mouseX = (int)mousePosition.x; // make correlation between mouseclick and color change
            int mouseY = (int)mousePosition.y;        

        //Debug.Log("1" + texture.GetPixel(mouseX, mouseY)); // reads black pixel color
        //Debug.Log(mouseX + ", " + mouseY);

        //  for (int y = mouseX - 1; y < mouseX + 1; y++) {
        //      for (int x = mouseY - 1; x < mouseY + 1; x++) {  } }
        if (clone.GetPixel(mouseX, mouseY) != Color.green) {
                Debug.Log("2" + texture.GetPixel(mouseX, mouseY)); // reads new pixel color
                clone.SetPixel(mouseX, mouseY, Color.blue);
                GetComponent<Renderer>().material.mainTexture = clone;
                clone.Apply();
                
            }
        } */
    }



    /*
    void DrawLine(Texture2D tex, int x0, int y0, int x1, int y1, Color col) {
        int dy = (int)(y1 - y0);
        int dx = (int)(x1 - x0);
        int stepx, stepy;

        if (dy < 0) { dy = -dy; stepy = -1; }
        else { stepy = 1; }
        if (dx < 0) { dx = -dx; stepx = -1; }
        else { stepx = 1; }
        dy <<= 1;
        dx <<= 1;

        float fraction = 0;

        tex.SetPixel(x0, y0, col);
        if (dx > dy) {
            fraction = dy - (dx >> 1);
            while (Mathf.Abs(x0 - x1) > 1) {
                if (fraction >= 0) {
                    y0 += stepy;
                    fraction -= dx;
                }
                x0 += stepx;
                fraction += dy;
                tex.SetPixel(x0, y0, col);
            }
        }
        else {
            fraction = dx - (dy >> 1);
            while (Mathf.Abs(y0 - y1) > 1) {
                if (fraction >= 0) {
                    x0 += stepx;
                    fraction -= dy;
                }
                y0 += stepy;
                fraction += dx;
                tex.SetPixel(x0, y0, col);
            }
        }
    } */
}
