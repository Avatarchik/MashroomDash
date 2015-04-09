using UnityEngine;
using System.Collections;

//	static変数を管理するためのクラス
//	setter/getterを用意

public class GameManager : MonoBehaviour {

	public int _score = 0;
	public int _highScore = 0;

	//	スコアを更新
	public void setScore(int score){
		_score = score;
	}

	//	スコアを取得
	public int getScore(){
		return _score;
	}

	//	ハイスコアを更新
	public void setHighScore(int highScore){
		_highScore = highScore;
	}

	//	ハイスコアを取得
	public int getHighScore(){
		return _highScore;
	}

	void Awake(){
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
