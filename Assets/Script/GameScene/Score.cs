using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
    //  スコア文字
    public Text scoreText;
    //  ハイスコア文字
    public Text highScoreText;

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
            PlayerPrefs.SetInt (highScoreKey, highScore);
        }

        scoreText.text = score.ToString ();
        scoreText.color = Color.black;
        highScoreText.text = highScore.ToString ();
	}

    public void addPoint (int point){
        score += point;
    }
}
