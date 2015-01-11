using UnityEngine;
using System.Collections;

public class PoisonItem : MonoBehaviour {

    public float moveSpeed = 0.2f;

    void Start(){

    }

    void Update(){
        transform.Translate (moveSpeed, 0, 0);
    }
}
