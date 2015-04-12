using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
    public Text scoreText;
    public Text highScoreText;
    private int score;
    private int highScore;
    private const string KEY_HIGHSCORE = "highScore";
   
	void Start () {
        highScore = PlayerPrefs.GetInt(KEY_HIGHSCORE);
        highScoreText.text = highScore.ToString ();
	}
	
	void Update () {
        scoreText.text = score.ToString ();
        scoreText.color = Color.black;
        if (highScore < score) {
            highScoreText.text = score.ToString ();
        }
	}

    public void addPoint (int point){
        score += point;
    }

    public void saveScore(){
        GameManager.Instance.setIntData ("Score", score);
    }
}
