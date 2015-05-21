using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameArea : MonoBehaviour {

    //  ゲーム終了フラグ
    public bool _isGameEnd = false;
    //  確率の配列
    public float[] _itemProbs;
    //  鳥の配列要素番号
    private const int BIRD_INDEX = 4;

    //  生成するアイテム
    public List<GameObject> _itemList;

    //  プレイヤーオブジェクト
    private Player _player;

    //  一時停止メニュー
    private GameObject _pauseMenu;

    void Awake(){
        // 2秒毎にアイテム生成 
        const float delayTime = 2.0f;
        InvokeRepeating ("createItem", delayTime, delayTime);
        _pauseMenu = GameObject.Find ("PauseMenu");
        _pauseMenu.SetActive (false);
    }

    void Start(){
        AudioManager.Instance.playBgm ("Stage");
        _player = GetComponentInChildren<Player> ();
    }

    void Update () {
        if (Input.GetMouseButtonUp (0) && Time.timeScale > 0) {
            //  タッチ座標がGameAreaのCollider内だったらジャンプする
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = Physics2D.OverlapPoint(touchPos);
            if (collider) {
                _player.jumpPlayer ();
            }
        }
    }
        
    //  画面外判定
    void OnTriggerExit2D(Collider2D collider){ 
        Destroy (collider.gameObject);
    }

    //  アイテムを生成
    void createItem(){
        GameObject item;
        float arrayIndex = chooseItem (_itemProbs);

        Vector3 itemPosition;
        if (BIRD_INDEX == arrayIndex) {
            itemPosition = new Vector3 (-8.1f, -1.5f, 0);
        } else {
            itemPosition = new Vector3 (-8.1f, -3.9f, 0);
        }
        item = (GameObject)Instantiate (_itemList [(int)arrayIndex], itemPosition, Quaternion.identity);
        item.transform.SetParent (transform);
    }

    //  生成するアイテムを抽選
    float chooseItem(float[] values){
        float total = 0;

        //  配列の要素の黄経を求める
        foreach (float elem in values) {
            total += elem;
        }
            
        float randomPoint = Random.value * total;

        for (int i = 0; i < values.Length; i++) {
            if (randomPoint < values [i]) {
                return i;
            } else {
                randomPoint -= values [i];
            }
        }
        return values.Length - 1;
    }

    //  ゲームオーバー画面へ
    public void switchGameOver(){
        _isGameEnd = true;
        FindObjectOfType<Score> ().saveScore ();
        Application.LoadLevel ("GameOverScene");
    }

    public void onTapPauseButton(){
        Time.timeScale = 0;
        _pauseMenu.SetActive (true);
    }

    public void onTapResumeButton(){
        Time.timeScale = 1;
        _pauseMenu.SetActive (false);
    }

    public void onTapTitleButton(){
        //  一時停止を解除してからタイトル画面へ
        Time.timeScale = 1;
        Application.LoadLevel ("TitleScene");
    }
}
