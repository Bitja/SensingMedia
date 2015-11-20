using UnityEngine;
using System.Collections;

public class GetMouseOfset : MonoBehaviour {

    private Vector3 mousePosition;
    public float moveSpeed = 1.0f;
    private Vector3 mouseOffset = new Vector3(40.0f, 0.0f, 0.0f);
	public bool offsetOn = false;

	public void toggleOffset(bool offset){
		if (offset == false)
			offsetOn = false;
		else
			offsetOn = true;
	}
    void Update() {
		//Debug.Log (offsetOn);
		if (offsetOn == true) {
			if (Input.GetMouseButton (0)) {
				mousePosition = Input.mousePosition + mouseOffset;
				//Debug.Log (mousePosition + " : " + Input.mousePosition);
				mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
				transform.position = Vector2.Lerp (transform.position, mousePosition, moveSpeed);
			}
		} 
		else {
			if (Input.GetMouseButton (0)){
				mousePosition = Input.mousePosition;
				mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
				transform.position = Vector2.Lerp (transform.position, mousePosition, moveSpeed);
			}
		}

	}
}
