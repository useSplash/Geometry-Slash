using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramerateHandler : MonoBehaviour
{
    void Awake(){
        Application.targetFrameRate = 60;
        // Switch to 640 x 480 full-screen
        Screen.SetResolution(1600, 900, false);
    }
}
