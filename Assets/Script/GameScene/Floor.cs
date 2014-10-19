using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
    //  生成するオブジェクト
    public GameObject prefab;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 20; i++) {
            Instantiate (prefab, Vector3.right * i, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
