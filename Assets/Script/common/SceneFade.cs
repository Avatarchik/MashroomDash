﻿using UnityEngine;
using System.Collections;

public class SceneFade : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CameraFade.StartAlphaFade (Color.black, true, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
