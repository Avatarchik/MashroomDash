using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//	ゲーム内の一時データを管理するクラス
//  ゲーム終了時に破棄される

public class GameManager : SingletonMonoBehaviour<GameManager> {


    private Dictionary<string, int> intData;

    new public void Awake(){
        if (this != Instance) {
            Destroy (this);
            return;
        }
        DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
        intData = new Dictionary<string, int> () {
        };
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //  int型のデータを保存
    public void setIntData(string key, int data){
        if (!intData.ContainsKey (key)) {
            Debug.Log ("存在しないKEYです。作成します。");
            intData.Add (key, data);
            return;
        }

        intData [key] = data;
    }

    //  int型のデータを取得
    public int getIntData(string key){
        if (!intData.ContainsKey (key)) {
            Debug.LogError (key + "は存在しません。");

            return 0;
        }

        return intData [key];
    }
}
