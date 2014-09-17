using UnityEngine;
using System.Collections;

public class ScreenManager : MonoBehaviour {

    void Awake () {
        Screen.SetResolution (Screen.width, Screen.height, true);
    }
}
    