using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangePath : MonoBehaviour {
    private int typeOfPath = 0;//0== lens, 1==offset finger, 2== lamp finger, 3==offset widget, 4 == lamp widget
    public GameObject lamp, offsetLamp, mouse;
    GetMouseOfset otherOffSetLamp;
    GradiantLamp otherSkammekrog;

    void Start()
    {
        lamp = GameObject.Find("CylinderLamp");
        offsetLamp = GameObject.Find("CylinderMouseOffset");
        mouse = GameObject.Find("CylinderMouse");
        otherOffSetLamp = offsetLamp.GetComponent<GetMouseOfset>();
        otherSkammekrog = mouse.GetComponent<GradiantLamp>();
    }


    public void changePathWithTeststate(int ButtonNr) {
        switch (StartMenu.testState) {
            case 1:
                Debug.Log("Case 1");
                switch (ButtonNr) {
                    case 1:
                        Debug.Log("Button 1");
                        //Button 1
                        typeOfPath = 0;
                        pathPattern();
                        break;
                    case 2:
                        //Button 2
                        typeOfPath = 1;
                        pathPattern();
                        break;
                    case 3:
                        //Button 3
                        typeOfPath = 2;
                        pathPattern();
                        break;
                    case 4:
                        //Button 4
                        typeOfPath = 2;
                        pathPattern();
                        break;
                    case 5:
                        //Button 5
                        typeOfPath = 1;
                        pathPattern();
                        break;
                }
                break;
            case 2:
                switch (ButtonNr)
                {
                    case 1:
                        //Button 1
                        break;
                    case 2:
                        //Button 2
                        break;
                    case 3:
                        //Button 3
                        break;
                    case 4:
                        //Button 4
                        break;
                    case 5:
                        //Button 5
                        break;
                }
                break;
        }
    
    }

    public void pathPattern(){
        if (typeOfPath == 0)
        {
            Debug.Log("Widget");
            lamp.SetActive(false);
            offsetLamp.SetActive(false);
            GradiantLamp.skammekrog = false;
            MirrorLamps.isOn = false;
            GradiantLamp.lampIsOn = false;
        }
        else if (typeOfPath == 1) {
            Debug.Log("Finger offset");
            lamp.SetActive(false);
            offsetLamp.SetActive(true);
            
            GetMouseOfset.offsetOn = true;
            otherOffSetLamp.toggleOffset();
           // otherSkammekrog.skammekrog = true;
            MirrorLamps.isOn = true;

            GradiantLamp.lampIsOn = true;
        }
        else if (typeOfPath == 2){
            Debug.Log("finger lamp");

            lamp.SetActive(true);
            offsetLamp.SetActive(false);
            
            GradiantLamp.lampIsOn = true;
            MirrorLamps.isOn = true;

            GradiantLamp.skammekrog = true;
        }
        else if (typeOfPath == 3)
        {
            Debug.Log("widget offset");
            lamp.SetActive(false);
            offsetLamp.SetActive(true);

            GetMouseOfset.offsetOn = true;
            otherOffSetLamp.toggleOffset();
            // otherSkammekrog.skammekrog = true;
            MirrorLamps.isOn = true;

            GradiantLamp.lampIsOn = true;
        }
        else if (typeOfPath == 4)
        {
            Debug.Log("Widget lamp");

            lamp.SetActive(true);
            offsetLamp.SetActive(false);

            GradiantLamp.lampIsOn = true;
            MirrorLamps.isOn = true;

            GradiantLamp.skammekrog = true;
        }

    }
    // Use this for initialization

    // Update is called once per frame

}
