using UnityEngine;
using System.Collections;

public class PointItem : MonoBehaviour {

    public float moveSpeed = 0.2f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate (moveSpeed, 0, 0);
	}

    void OnTriggerEnter2D(Collider2D col){
        Destroy (gameObject);
        FindObjectOfType<Score> ().addPoint (10);
    }
}
