using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CameraFade.StartAlphaFade (Color.white, true, 2.0f);
	}
}
