using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CutIn : MonoBehaviour {

    //  フェード時間
    public float _fadeTime = 0.5f;
    //  フェードアウト実行までの時間
    public float _interval = 3.0f;
    private SpriteRenderer _render;
    //  フェードインかどうか
    private bool _isFadeIn;

    //  表示するイラストのリスト
    public List<GameObject> _illustList;
    //  生成するイラスト
    private GameObject _illust;
    private SpriteRenderer _illustRender;
    private const float _defaultPos = -14.5f;

    // Use this for initialization
    void Start () {
        _isFadeIn = true;
        // フェードイン開始
        _render = GetComponent<SpriteRenderer>();
        iTween.ValueTo (gameObject, iTween.Hash ("from", 0, "to", 1, "time", _fadeTime, "onUpdate", "onUpdate"));

        //  スコアコンポーネントを取得
        Score score = FindObjectOfType<Score> ();

        //  スライドするイラストを作成
        int index = score.getScore() / score.getExtendPoint() - 1;
        _illust = (GameObject)Instantiate (_illustList[index], new Vector3(_defaultPos, 0, 0), Quaternion.identity);
        _illust.transform.SetParent (gameObject.transform);
        _illustRender = _illust.GetComponent<SpriteRenderer> ();

        //  スライドを開始
        iTween.MoveTo (_illust.gameObject, new Vector3 (4.3f, 0, 0), _fadeTime * 1.5f);
    }
        
    void onUpdate(float value){
        //  背景部分のアルファ値を変更
        Color backColor = _render.color;
        backColor.a = value;
        _render.color = backColor;

        //  イラストのアルファチを変更
        Color illustColor = _illustRender.color;
        illustColor.a = value;
        _illustRender.color = illustColor;

        //  フェードイン完了
        if (value == 1.0f && _isFadeIn) {
            _isFadeIn = false;
            iTween.ValueTo (gameObject, iTween.Hash ("delay", _interval, "from", 1, "to", 0, "time", _fadeTime, "onUpdate", "onUpdate"));
            iTween.MoveTo (_illust.gameObject, iTween.Hash("x", _defaultPos * -1, "time", _fadeTime * 1.5f, "delay", _interval));
        }

        //  フェードアウト完了
        if (value == 0.0f && !_isFadeIn) {
            Destroy (gameObject);
        }
    }
}
