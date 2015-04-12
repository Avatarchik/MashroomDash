using UnityEngine;
using System.Collections;

public class ItemMashroom : MonoBehaviour {

    public float moveSpeed = 0.2f;
    public int point = 10;
    public bool isPointItem;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (0 < Time.timeScale) {
            transform.Translate (moveSpeed, 0, 0);
        }
	}

    void OnTriggerEnter2D(Collider2D col){
        if (isPointItem) {
            if (col.tag == "Player") {
                AudioManager.Instance.playSe ("ItemGet");
                Destroy (gameObject);
                FindObjectOfType<Score>().addPoint(point);
            }
        }
    }
}
