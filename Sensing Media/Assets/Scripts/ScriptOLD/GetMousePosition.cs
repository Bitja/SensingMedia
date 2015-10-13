using UnityEngine;
using System.Collections;

public class GetMousePosition : MonoBehaviour {

    private Vector3 mousePosition;
    public float moveSpeed = 1.0f;

    void Update() {

        if (Input.GetMouseButton(0)) {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }

        
    }
}
