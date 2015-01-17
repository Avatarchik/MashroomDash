using UnityEngine;
using System.Collections;

public class PointItem : MonoBehaviour {

    public float moveSpeed = 0.2f;
    public int point = 10;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (0 < Time.timeScale) {
            transform.Translate (moveSpeed, 0, 0);
        }
	}

    /**
     *  アイテムの当たり判定
     */
    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player") {
            Destroy (gameObject);
            FindObjectOfType<Score>().addPoint(point);
        }
    }
}
