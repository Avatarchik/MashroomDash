using UnityEngine;
using System.Collections;

public class LogoManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CameraFade.StartAlphaFade (Color.white, true, 2.0f);
        Invoke ("moveTitleScene", 2.1f);
	}

    void moveTitleScene(){
		CameraFade.StartAlphaFade (Color.white, false, 2.0f, 1.0f, ()=>{Application.LoadLevel("TitleScene");});
    }
}
