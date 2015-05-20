using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    //  ジャンプ回数
    private int jumpCount = 0;
    //  ジャンプ制限回数
    private const int JUMP_LIMIT = 2;

    //  接地フラグ
    public bool isGround = false;
    //  床レイヤー
    public LayerMask floorLayer;
    //  プレイヤー破棄フラグ
    public bool isDestroyPlayer;

    void Awake(){
        isDestroyPlayer = false;
    }

    void Start(){

    }

	void Update () {
        if (Input.GetMouseButtonUp (0)) {
            if (JUMP_LIMIT > jumpCount) {
                jumpCount++;
                GetComponent<Rigidbody2D>().AddForce (Vector2.up * 700);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D col){
        if ("poisonItem" == col.tag) {
            isDestroyPlayer = true;
            Destroy (gameObject);
            Destroy (col.gameObject);
            this.GetComponentInParent<GameArea> ().switchGameOver ();
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if ("Floor" == col.gameObject.tag) {
            jumpCount = 0;
        }
    }
}
