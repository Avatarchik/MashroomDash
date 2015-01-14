using UnityEngine;
using System.Collections;

public class GameArea : MonoBehaviour {

    public bool isGameEnd = false;

    public GameObject gameOverLayer;

    //  画面外判定
    void OnTriggerExit2D(Collider2D collider){ 
        Destroy (collider.gameObject);
    }

    void Update(){
        //  ゲーム終了時に時間経過を停止
        if (isGameEnd) {
            AudioManager.Instance.stopBgm ();
            Time.timeScale = 0.0f;
            isGameEnd = false;
            Instantiate (gameOverLayer, new Vector3 (0, 0, -1), Quaternion.identity);
        }
    }

    void onReleaseButton(){
        SceneManager.Instance.moveScene ("TitleScene", 0.5f);
    }

}
