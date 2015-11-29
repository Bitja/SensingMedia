using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	public static int testState;
	public void ChangeToState(int sceneToStateNr){
        if (sceneToStateNr == 0)
        {
           // Application.LoadLevel("Scene1");
            testState = 1;
        }
        else if (sceneToStateNr == 1)
        {
            //Application.LoadLevel("Scene2");
            testState = 2;

        }
        else if (sceneToStateNr == 2)
        {
            //Application.LoadLevel("Scene3");
            testState = 3;

        }
        else if (sceneToStateNr == 3)
        {
            //Application.LoadLevel("Scene4");
            testState = 4;

        }
        else if (sceneToStateNr == 4)
        {
            //Application.LoadLevel("Scene5");
            testState = 5;

        }
        else if (sceneToStateNr == 5)
        {
            //Application.LoadLevel("Scene6");
            testState = 6;

        }
        else if (sceneToStateNr == 6)
        {
            //Application.LoadLevel("Scene6");
            testState = 7;
        }
        else if (sceneToStateNr == 7)
        {
            //Application.LoadLevel("Scene6");
            testState = 8;

        }
        Application.LoadLevel("Scene1");
    }	
}
	
