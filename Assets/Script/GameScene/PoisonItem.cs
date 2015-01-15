using UnityEngine;
using System.Collections;

public class PoisonItem : MonoBehaviour {

    public float moveSpeed = 0.2f;

    void Start(){

    }

    void Update(){
        if (0 < Time.timeScale) {
            transform.Translate (moveSpeed, 0, 0);
        }
    }
}
