using UnityEngine;
using System.Collections;

public class GameArea : MonoBehaviour {

    public bool isGameEnd = false;

    //  画面外判定
    void OnTriggerExit2D(Collider2D collider){ 
        Destroy (collider.gameObject);
    }

    void Update(){
        //  ゲーム終了時に時間経過を停止
        if (isGameEnd) {
            AudioManager.Instance.stopBgm ();
            SceneManager.Instance.moveScene ("TitleScene", 1.0f);
        }
    }



}
