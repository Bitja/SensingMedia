using UnityEngine;
using System.Collections;


public class pathTracer : MonoBehaviour {

    public float moveSpeed = 1.0f;

    private float mapX = 100.0f, mapY = 100.0f;
    private float minX, maxX, minY, maxY;
    public Texture2D texture; // don't change!
    //public Sprite mySprites;

    void Start() {
        GetComponent<Renderer>().material.mainTexture = texture;
        //GetComponent<UnityEngine.UI.Image>().sprite = mySprites;
        //texture = Instantiate(texture) as Texture2D;

        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        // Calculations assume map is position at the origin
        minX = horzExtent - mapX / 2.0f;
        maxX = mapX / 2.0f - horzExtent;
        minY = vertExtent - mapY / 2.0f;
        maxY = mapY / 2.0f - vertExtent;

        //Debug.Log("sprite bounds: " + mySprites.bounds); rectransform height...
        
    }

    void LateUpdate() {
        Vector3 v3 = transform.position;
        v3.x = Mathf.Clamp(v3.x, minX, maxX);
        v3.y = Mathf.Clamp(v3.y, minY, maxY);
        transform.position = v3;
        //Debug.Log(v3);
    }

    void Update() {
        if (Input.GetMouseButton(0)) {
            Vector3 mousePosition = Input.mousePosition;
            //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            //mousePosition = Camera.main.WorldToScreenPoint(mousePosition); // coord in pixels



            int mouseX = (int)mousePosition.x; // make correlation between mouseclick and color change
            int mouseY = (int)mousePosition.y;
            
            //Debug.Log("1" + texture.GetPixel(mouseX, mouseY)); // reads black pixel color
            //Debug.Log(mouseX + ", " + mouseY);
            
            //for (int y = mouseX - 1; y < mouseX + 1; y++) {
            //    for (int x = mouseY - 1; x < mouseY + 1; x++) { 
            if (texture.GetPixel(mouseX, mouseY) != Color.white) {
                texture.SetPixel(mouseX, mouseY, Color.white);
                //Debug.Log(mouseX + ", " + mouseY);
                //Debug.Log("2" + texture.GetPixel(mouseX, mouseY)); // reads new pixel color
                //Debug.Log("minX: " + minX + ", maxX: " + maxX + "minY: " + minY + ", maxY: " + maxY);
                //Debug.Log("texture width: " + texture.width + ", texture.height: " + texture.height);
            }
            // }
            //  }
            texture.Apply();
            //Debug.Log("virker");

        }
        
    } 
}
