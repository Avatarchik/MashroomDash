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
            if (isGameEnd) {
                isGameEnd = false;
                PlayerPrefs.Save ();
                SceneManager.Instance.moveScene ("GameScene", 0.5f);
            } else {
                player.GetComponent<Player> ().JumpPlayer ();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider){ 
        Destroy (collider.gameObject);
    }

    /**
     * ゲームオーバーに切り替え
     */
    public void switchGameOver(){
        isGameEnd = true;
        GameObject gameOver = GameObject.Find ("GameOver");
        gameOver.GetComponent<GameOver> ().FadeLayer ();
    }
}
