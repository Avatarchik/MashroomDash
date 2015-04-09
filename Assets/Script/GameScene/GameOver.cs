using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameOver : MonoBehaviour {
    void Start(){
        gameObject.SetActive (false);
    }

    void Update(){

    }

    public void setGameOver(){
        gameObject.SetActive (true);
    }
}
