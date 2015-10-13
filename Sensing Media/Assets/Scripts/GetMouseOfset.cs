using UnityEngine;
using System.Collections;

public class GetMouseOfset : MonoBehaviour {

    private Vector3 mousePosition;
    public float moveSpeed = 1.0f;
    public Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f);

    void Update() {
        if (Input.GetMouseButton(0)) {
            mousePosition = Input.mousePosition  + offset;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
    }
}
