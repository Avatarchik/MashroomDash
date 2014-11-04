using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
    public float moveSpeed = 0.5f;
	
	// Update is called once per frame
	void Update () {
        transform.Translate (moveSpeed, 0, 0);
	}
}
