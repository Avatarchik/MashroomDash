using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //  ジャンプ回数
    private int jumpCount = 0;
    //  ジャンプ上限回数
    private const int JUMP_LIMIT = 2;
    //  設置判定オブジェクト
    private Transform groundCheck;

    //  接地フラグ
    public bool isGround = false;
    //  床レイヤー
    public LayerMask floorLayer;

    void Start(){
        //  設置判定オブジェクトを取得
        groundCheck = transform.Find ("groundCheck");
    }

	void Update () {
        //  接地判定
        isGround = Physics2D.Linecast (transform.position, groundCheck.position, floorLayer);

        if (isGround) {
            jumpCount = 0;
        }

        //  ジャンプ回数が二回未満の場合、ジャンプ
        if (Input.GetMouseButtonDown(0) && JUMP_LIMIT > jumpCount) {
            jumpCount++;
            rigidbody2D.AddForce (Vector2.up * 600);
        }
	}

    /*
     *  当たり判定 
     */
    void OnTriggerEnter2D(Collider2D col){
        //  毒キノコに当たったらプレイヤーを削除
        if ("poisonItem" == col.tag) {
            Destroy (gameObject);
            Destroy (col.gameObject);
        }
    }
}
