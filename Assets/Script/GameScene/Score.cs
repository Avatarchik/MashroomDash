using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
    public Text scoreText;
    public Text highScoreText;
    private int score;
    private int highScore;
    private const string KEY_HIGHSCORE = "highScrore";
   
	void Start () {
        highScore = PlayerPrefs.GetInt(KEY_HIGHSCORE);
	}
	
	void Update () {
        if (highScore < score) {
            highScore = score;
            PlayerPrefs.SetInt (KEY_HIGHSCORE, highScore);
        }

        scoreText.text = score.ToString ();
        scoreText.color = Color.black;
        highScoreText.text = highScore.ToString ();
	}

    public void addPoint (int point){
        score += point;
    }
}
