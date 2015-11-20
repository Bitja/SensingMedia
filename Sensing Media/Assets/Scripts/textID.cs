using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class textID : MonoBehaviour {

    private static Text txtID;
    private static GameObject txtIDobj;

    public static void getTextID() {
        txtIDobj = GameObject.Find("TextID");
        txtID = txtIDobj.GetComponent<Text>();
        txtID.text = "";
        //Debug.Log(txtID.text);
    }
}
