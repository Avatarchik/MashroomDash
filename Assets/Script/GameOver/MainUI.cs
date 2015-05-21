using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainUI : MonoBehaviour {
    //  スコア
    private Text _score;
    //  ハイスコア更新メッセージ
    private Text _highScoreMessage;

    public GameObject credit;

    int _resultScore;

	// Use this for initialization
	void Start () {
        //  SEを再生
        AudioManager.Instance.playSe ("GameOver");

        //  Textオブジェクトを取得
        _score = GameObject.Find ("ResultScore").gameObject.GetComponent<Text> ();
        _highScoreMessage = GameObject.Find ("HighScoreMessage").gameObject.GetComponent<Text> ();

        //  スコアを表示
        _resultScore = GameManager.Instance.getIntData ("Score");
        string score = "スコア::" + _resultScore.ToString();
        _score.text = score;

        //  ハイスコアが更新された場合のみ表示
        int currentHighScore = PlayerPrefs.GetInt ("highScore");
        Debug.Log (currentHighScore);
        if (currentHighScore < _resultScore) {
            PlayerPrefs.SetInt ("highScore", _resultScore);
            _highScoreMessage.text = "ハイスコア更新!!";
        } else {
            _highScoreMessage.text = "";
        }
	}

    public void OnTapCreditButton(){
        AudioManager.Instance.playSe ("ButtonSe");
        Instantiate (credit, new Vector3 (1262, 256.5f, 0), Quaternion.identity);
    }

    public void OnTapRetryButton(){
        AudioManager.Instance.playSe ("ButtonSe");
        SceneManager.Instance.loadLevel ("GameScene", 0.5f);
    }

    public void OnTapTwitterButton(){
        string text = "きのこたくさんとれたゾ！\nすこあ：" + _resultScore.ToString () + "\n";
        string url = "https://play.google.com/store/apps/details?id=com.konvalo";
        Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(text + url + "\n#きのこの!"));
    }

	public void OnTapTitleButton(){
        SceneManager.Instance.loadLevel ("TitleScene", 0.5f);
	}
}
