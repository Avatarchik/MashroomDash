using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainUI : MonoBehaviour {
    //  スコア
    private Text _score;
    //  ハイスコア更新メッセージ
    private Text _highScoreMessage;

    public GameObject credit;

	// Use this for initialization
	void Start () {
        //  SEを再生
        AudioManager.Instance.playSe ("GameOver");

        //  Textオブジェクトを取得
        _score = GameObject.Find ("ResultScore").gameObject.GetComponent<Text> ();
        _highScoreMessage = GameObject.Find ("HighScoreMessage").gameObject.GetComponent<Text> ();

        //  スコアを表示
        int resultScore = GameManager.Instance.getIntData ("Score");
        string score = "スコア::" + resultScore.ToString();
        _score.text = score;

        //  ハイスコアが更新された場合のみ表示
        int currentHighScore = PlayerPrefs.GetInt ("highScore");
        Debug.Log (currentHighScore);
        if (currentHighScore < resultScore) {
            PlayerPrefs.SetInt ("highScore", resultScore);
            _highScoreMessage.text = "ハイスコア更新!!";
        } else {
            _highScoreMessage.text = "";
        }
	}

    public void OnTapCreditButton(){
        Instantiate (credit, new Vector3 (1262, 256.5f, 0), Quaternion.identity);
    }

    public void OnTapRetryButton(){
        SceneManager.Instance.loadLevel ("GameScene", 0.5f);
    }
}
