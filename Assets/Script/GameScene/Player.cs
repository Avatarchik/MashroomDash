using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private int jumpCount = 0;
    private const int JUMP_LIMIT = 1;
    public bool isGround = false;
    public LayerMask floorLayer;

    public bool isDestroyPlayer;

    void Awake(){
        isDestroyPlayer = false;
    }

    void Start(){

    }

	void Update () {
        isGround = Physics2D.Linecast (transform.position, transform.position - transform.up * 0.8f, floorLayer);
        if (isGround) {
            jumpCount = 0;
        }
	}

    void OnTriggerEnter2D(Collider2D col){
        if ("poisonItem" == col.tag) {
            isDestroyPlayer = true;
            AudioManager.Instance.playSe ("gameOverSe");
            Destroy (gameObject);
            Destroy (col.gameObject);

            GameObject gameArea = GameObject.Find ("GameArea");
            gameArea.GetComponent<GameArea> ().switchGameOver ();
        }
    }

    /**
     * ジャンプ処理
     */
    public void JumpPlayer(){
        if (JUMP_LIMIT > jumpCount) {
            jumpCount++;
            rigidbody2D.AddForce (Vector2.up * 600);
            Debug.Log ("Jump"+jumpCount);
        }
    }
}
