using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
    //  スコア文字
    public GUIText scoreText;
    //  ハイスコア文字
    public GUIText highScoreText;

    //  スコア
    private int score;
    //  ハイスコア
    private int highScore;

    //  PlayerPrefs保存用のキー
    private string highScoreKey = "highScrore";

	// Use this for initialization
	void Start () {
        highScore = PlayerPrefs.GetInt(highScoreKey);
	}
	
	// Update is called once per frame
	void Update () {

        if (highScore < score) {
            highScore = score;
        }

        scoreText.text = "Score:" + score.ToString ();
        scoreText.color = Color.black;
        highScoreText.text = "HighScore:" + highScore.ToString ();
	}

    public void addPoint (int point){
        score += point;
    }

    //  ハイスコアの保存
    public void SaveHighScore(){
        PlayerPrefs.SetInt (highScoreKey, highScore);
        PlayerPrefs.Save ();
    }
}
