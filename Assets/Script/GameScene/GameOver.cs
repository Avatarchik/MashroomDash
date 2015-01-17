using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOver : MonoBehaviour {

    private SpriteRenderer sprite;

    void Start(){
        //  画像を透明にする
        sprite = gameObject.GetComponent<SpriteRenderer> ();
        var color = sprite.color;
        color.a = 0.0f;
        sprite.color = color;
        //  徐々に画像を表示させる
        iTween.ValueTo (gameObject, iTween.Hash ("from", 0, "To", 0.5f, "time", 1.5f, "onupdate", "UpdateHandler"));
    }

    void UpdateHandler(float value){
        var color = sprite.color;
        color.a = value;
        sprite.color = color;
    }
}
