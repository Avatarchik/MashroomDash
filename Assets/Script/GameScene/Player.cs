using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //  ジャンプ回数
    private int jumpCount = 0;
    //  ジャンプ上限回数
    private const int JUMP_LIMIT = 1;

    //  接地フラグ
    public bool isGround = false;
    //  床レイヤー
    public LayerMask floorLayer;

    public bool isDestroyPlayer;

    void Awake(){
        isDestroyPlayer = false;
    }

    void Start(){

    }

	void Update () {
        //  接地判定
        isGround = Physics2D.Linecast (transform.position, transform.position - transform.up * 0.8f, floorLayer);
        if (isGround) {
            jumpCount = 0;
        }
	}

    /**
     * ジャンプ処理
     */
    public void JumpPlayer(){
        if (JUMP_LIMIT > jumpCount) {
            jumpCount++;
            rigidbody2D.AddForce (Vector2.up * 600);
        }
    }

    /*
     *  当たり判定 
     */
    void OnTriggerEnter2D(Collider2D col){
        if ("poisonItem" == col.tag) {
            isDestroyPlayer = true;
//            AudioManager.Instance.playSe ("gameOverSe");
//            Destroy (gameObject);
//            Destroy (col.gameObject);
//            FindObjectOfType<GameArea> ().switchGameOver();
        }
    }
}
