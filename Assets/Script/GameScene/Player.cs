using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    //  ジャンプ回数
    private int jumpCount = 0;
    //  ジャンプ制限回数
    private const int JUMP_LIMIT = 1;
    private Animator anim;

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
        anim = gameObject.GetComponent<Animator> ();
    }

	void Update () {
        isGround = Physics2D.Linecast (transform.position, transform.position - transform.up * 0.8f, floorLayer);
        anim.SetBool ("isGround", isGround);
        if (isGround) {
            jumpCount = 0;
        }
	}

    void OnTriggerEnter2D(Collider2D col){
        if ("poisonItem" == col.tag) {
            isDestroyPlayer = true;
            Destroy (gameObject);
            Destroy (col.gameObject);
			this.GetComponentInParent<GameArea>().switchGameOver();
        }
    }

    /**
     * ジャンプ処理
     */
    public void JumpPlayer(){
        if (JUMP_LIMIT > jumpCount) {
            jumpCount++;
            GetComponent<Rigidbody2D>().AddForce (Vector2.up * 600);
        }
    }
}
