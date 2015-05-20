using UnityEngine;
using System.Collections;

public class ItemMashroom : MonoBehaviour {
    //  アイテムの移動スピード
    public float moveSpeed;
    //  獲得ポイント
    public int point = 10;
    //  加点アイテムかどうか
    public bool isPointItem;

    //  スコアコンポーネント
    private Score _score;

	// Use this for initialization
	void Start () {
        _score = FindObjectOfType<Score> ();

        //  カットインの再生回数に合わせてスピードを調整
        CutInManager manager = GetComponentInParent<CutInManager> ();
        for (int i = 0; i < manager.getCutInFase () - 1; i++) {
            moveSpeed *= manager.getSpeedRate();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (0 < Time.timeScale) {
            transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
        }
	}

    void OnTriggerEnter2D(Collider2D col){
        if (isPointItem) {
            if (col.tag == "Player") {
                AudioManager.Instance.playSe ("ItemGet");
                Destroy (gameObject);
                _score.addPoint(point);
            }
        }
    }
}
