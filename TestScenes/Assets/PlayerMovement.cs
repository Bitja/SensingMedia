using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public long time = 0;
	// Use this for initialization
	void Start () {	
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("w")) { 
        transform.Translate(Vector3.forward);
            long newTime = GetTime.GetCurrentUnixTimestampSeconds();
            if (time == 0 || time != newTime)            {
                time = newTime;
                Debug.Log(time);
            }
    }
        if (Input.GetKey("s")){
            transform.Translate(Vector3.back);
            Debug.Log("Pressing S key");
        }
        if (Input.GetKey("a")){
            transform.Translate(Vector3.left);
            Debug.Log("Pressing A key");
        }
        if (Input.GetKey("d")){
            transform.Translate(Vector3.right);
            Debug.Log("Pressing D key");
        }
    }
}
