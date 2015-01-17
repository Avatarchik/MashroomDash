using UnityEngine;
using System.Collections;

public class GameArea : MonoBehaviour {

    public bool isGameEnd = false;

    public GameObject GameOverLayer;

    //  画面外判定
    void OnTriggerExit2D(Collider2D collider){ 
        Destroy (collider.gameObject);
    }

    void Update(){
        if (Input.GetMouseButtonUp (0)) {
            if (isGameEnd) {
                isGameEnd = false;
                PlayerPrefs.Save ();
                SceneManager.Instance.moveScene ("GameScene", 0.5f);
            } else {
                FindObjectOfType<Player> ().JumpPlayer ();
            }
        }
    }

    public void switchGameOver(){
        isGameEnd = true;
        AudioManager.Instance.stopBgm ();
        Instantiate (GameOverLayer, new Vector3 (0, 0, 0), Quaternion.identity);
    }
}
