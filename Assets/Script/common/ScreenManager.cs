using UnityEngine;
using System.Collections;

public class ScreenManager : MonoBehaviour {

    void Awake () {
        //  端末の画面解像度に合わせる
        Screen.SetResolution (Screen.width, Screen.height, true);
    }
}
    