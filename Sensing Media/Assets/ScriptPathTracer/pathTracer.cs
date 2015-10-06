using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pathTracer : MonoBehaviour {

    public float moveSpeed = 1.0f;
    public Texture2D texture;

    private Texture2D clone;
    private float preX = -1;
    private float preY = -1;
    List<Vector2> points;

    void Start() {
        clone = Instantiate(texture);
        GetComponent<Renderer>().material.mainTexture = clone;
    }

    void Update() {
        if(Input.GetMouseButton(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Send a ray to collide with the plane
            RaycastHit hit;

            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) {
                Vector2 uv;
                uv.x = (hit.point.x - hit.collider.bounds.min.x) / hit.collider.bounds.size.x;
                uv.y = (hit.point.y - hit.collider.bounds.min.y) / hit.collider.bounds.size.y;
                Texture2D tex = (Texture2D)hit.transform.gameObject.GetComponent<Renderer>().sharedMaterial.mainTexture;
                float x = uv.x * tex.width;
                float y = uv.y * tex.height;
                Vector2 point = new Vector2(x, y);
                tex.SetPixel((int)(uv.x * tex.width), (int)(uv.y * tex.height), Color.red);

                if (preX >= 0) { 
                    Vector2 prePoint = new Vector2(preX, preY);
                    Vector2[] points = new Vector2[2];
                    points[0] = prePoint;
                    points[1] = point;
                    points = MakeSmoothCurve(points,100.0f);
                    int xi = (int)x;
                    int yj = (int)y;

                    /*
                    for (int i = xi - 1; i < xi + 1; i++) // look-up matrix colomns
                        for (int j = yj - 1; j < yj + 1; j++) {  // look-up matrix  rows
                            tex.SetPixel((int)(points[i].x), (int)(points[i].y), Color.blue);
                            tex.SetPixel((int)(points[j].x), (int)(points[j].y), Color.blue);
                        }
                    */

                    for (int p = 0; p < points.Length; p++) 
                        tex.SetPixel((int)(points[p].x), (int)(points[p].y), Color.blue);
                }
                preX = x;
                preY = y;
                tex.Apply();
            } 
        }
        else if (!Input.GetMouseButton(0) && preX >= 0) {
            preX = -1;  // purely change of condition
        }
    }

    //arrayToCurve is original Vector3 array, smoothness is the number of interpolations. 
    public static Vector2[] MakeSmoothCurve(Vector2[] arrayToCurve, float smoothness) {
        List<Vector2> points;
        List<Vector2> curvedPoints;
        int pointsLength = 0;
        int curvedLength = 0;

        if (smoothness < 1.0f) smoothness = 1.0f;

        pointsLength = arrayToCurve.Length;
        curvedLength = (pointsLength * Mathf.RoundToInt(smoothness)) - 1;
        curvedPoints = new List<Vector2>(curvedLength);
        float t = 0.0f;

        for (int pointInTimeOnCurve = 0; pointInTimeOnCurve < curvedLength + 1; pointInTimeOnCurve++) {
            t = Mathf.InverseLerp(0, curvedLength, pointInTimeOnCurve);
            points = new List<Vector2>(arrayToCurve);
            
            for (int j = pointsLength - 1; j > 0; j--) {
                for (int i = 0; i < j; i++) {
                    points[i] = (1 - t) * points[i] + t * points[i + 1];
                }
            }
            curvedPoints.Add(points[0]);
        }
        return (curvedPoints.ToArray());
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
