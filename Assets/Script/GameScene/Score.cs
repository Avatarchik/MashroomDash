using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
    //  スコアテキスト
    public Text _scoreText;
    //  ハイスコアテキスト
    public Text _highScoreText;
    //  スコア
    private int _score;
    //  ハイスコア
    private int _highScore;
    //  ハイスコア保存用のキー
    private const string KEY_HIGHSCORE = "highScore";

    //  スピードアップする基準のポイント
    private const int EXTEND_POINT = 200;

    private CutInManager _cutInManager;
   
	void Start () {
        _highScore = PlayerPrefs.GetInt(KEY_HIGHSCORE);
        _highScoreText.text = _highScore.ToString ();

        _cutInManager = FindObjectOfType<CutInManager> ();
	}
	
	void Update () {
        _scoreText.text = _score.ToString ();
        _scoreText.color = Color.black;
        if (_highScore < _score) {
            _highScoreText.text = _score.ToString ();
        }
	}

    public void addPoint (int point){
        _score += point;

        //  カットインを再生
        if (_score >= EXTEND_POINT * _cutInManager.getCutInFase()) {
            _cutInManager.playCutIn ();
        }
    }

    public void saveScore(){
        GameManager.Instance.setIntData ("Score", _score);
    }

    public int getScore(){
        return _score;
    }

    public int getExtendPoint(){
        return EXTEND_POINT;
    }
}
