﻿using UnityEngine;
using System.Collections;

public class wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody2D.AddForce (Vector2.right * 2);
	}
}