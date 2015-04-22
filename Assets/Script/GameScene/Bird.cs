using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

    public float moveSpeed = 0.2f;
    public int point = 10;
    public bool isPointItem;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (0 < Time.timeScale) {
            transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D col){

    }
}
