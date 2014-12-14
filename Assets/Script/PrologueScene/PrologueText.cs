using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrologueText : MonoBehaviour {

    private DataFileManager manager;

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<DataFileManager> ();

        manager = GetComponent<DataFileManager> ();
        Text prologue = GetComponent<Text> ();

        prologue.text = manager.loadText ("sampleText");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3 (transform.position.x, transform.position.y + Time.deltaTime * 20, 0);
	}
}
