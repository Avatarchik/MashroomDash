using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int jumpCount = 0;
    //  ジャンプ上限回数
    private const int JUMP_LIMIT = 2;
    //  接地フラグ
    public bool isGround = false;
    //  床レイヤー
    public LayerMask floorLayer;

	void Update () {
        //  接地判定
        isGround = Physics2D.Linecast (transform.position,
            transform.position - transform.up * 0.8f, floorLayer);

        if (isGround == true) {
            jumpCount = 0;
        }

        //  ジャンプ処理b
        if (Input.GetMouseButtonDown(0) && JUMP_LIMIT > jumpCount) {
            jumpCount++;
            rigidbody2D.AddForce (Vector2.up * 600);
        }
	}
}
