using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PathTracer : MonoBehaviour {

    public GameObject scoreObject, timeObject;
    public static bool isEnabled = false;
    public static Text guiScore, guiTime;

    //private static Texture2D tex; //Bianca added
    private float preX = -1;
    private float preY = -1;
    private RaycastHit hit;
    private List<Vector2> points;
    public static float nearestP;

    private int changeTex;
    public static int width;

    void Start() {
        guiScore = scoreObject.GetComponent<Text>();
        guiTime = timeObject.GetComponent<Text>();
    }

    void Update() {
        if (!isEnabled)
            return;
        
        if (Input.GetMouseButton(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Send a ray to collide with the plane

            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) { // change
                Vector2 uv;
                uv.x = (hit.point.x - hit.collider.bounds.min.x) / hit.collider.bounds.size.x;
                uv.y = (hit.point.y - hit.collider.bounds.min.y) / hit.collider.bounds.size.y;
                Texture2D tex = (Texture2D)hit.transform.gameObject.GetComponent<Renderer>().sharedMaterial.mainTexture;
                float x = uv.x * tex.width;
                float y = uv.y * tex.height;

                if (preX >= 0 && (preX != x || preY != y)) { 
					width = 30 ;
                    nearestP = width;

                    for (int i = -width / 2; i <= width / 2; i++)
                        for (int j = -width / 2; j <= width / 2; j++)
                        {
                            float pDistance = Mathf.Sqrt(Mathf.Pow(i, 2) + Mathf.Pow(j, 2));
                            if (pDistance <= width / 2.0)
                            {
                                Color pColor = tex.GetPixel((int)(x + i), (int)(y + j));
                                if (pColor != Color.black)
                                {
                                    if (pColor != Color.red)
                                        tex.SetPixel((int)(x + i), (int)(y + j), Color.red);
                                    if (nearestP > pDistance)
                                        nearestP = pDistance;
                                }
                            }
                        }
					nearestP /= width /= 2;

                    float length = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(preX - x), 2) + Mathf.Pow(Mathf.Abs(preY - y), 2));
                    Vector2 A, B;
                    A.x = preX;
                    A.y = preY;
                    B.x = x;
                    B.y = y;
                    float angle = Vector3.Angle(A, B);
                }
                preX = x;
                preY = y;
                //tex.Apply();
            }
        }
        else if (!Input.GetMouseButton(0) && preX >= 0) {
            preX = -1;
        }
        
    }

    public static void displayScore() {
        guiTime.enabled = true;
        guiScore.enabled = true;
        guiScore.text = "Score: " + Handler.getAccuracy() + "%";
        guiTime.text = "Time: " + Handler.timeDisplay + " seconds";
        toggle(false);
        //tex.Apply(); // Bianca added
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

    public static void toggle(bool b) {
        isEnabled = b;
    }

    public static int countPixels(Color target_color) { // slow function creates a delay! Easy solution DONE: calls function when mouse moves out of each inner circle (see Handler.cs). 
        int matches = 0;
        for (int y = 0; y < NewLevel.clone.height; y++) { 
            for (int x = 0; x < NewLevel.clone.width; x++){
                if (NewLevel.clone.GetPixel(x, y) == target_color) matches++;
            }
        }
        return matches;
    }
}
