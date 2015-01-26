using UnityEngine;
using System.Collections;

public class GameArea : MonoBehaviour {
    //  ゲーム終了フラグ
    public bool isGameEnd = false;

    private GameObject player;

    void Start(){
        player = GameObject.Find ("Player");
    }
   
    void Update(){
        if (Input.GetMouseButtonUp (0)) {
            //  ゲーム終了時はシーン遷移
            if (isGameEnd) {
                isGameEnd = false;
                PlayerPrefs.Save ();
                //  リザルトへ遷移
                SceneManager.Instance.moveScene ("GameScene", 0.5f);
            } else {
                //  プレイヤーをジャンプ
                player.GetComponent<Player> ().JumpPlayer ();
            }
        }

//        if()
    }

    /**
     * 画面外判定
     */
    void OnTriggerExit2D(Collider2D collider){ 
        Destroy (collider.gameObject);
    }

    /**
     * ゲームオーバーに切り替える
     */
    public void switchGameOver(){
        isGameEnd = true;
        AudioManager.Instance.stopBgm ();
        GameObject gameOver = GameObject.Find ("GameOver");
        gameOver.GetComponent<GameOver> ().FadeLayer ();
    }
}
