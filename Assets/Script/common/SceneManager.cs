using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneManager : SingletonMonoBehaviour<SceneManager> {
	//	黒テクスチャ
	private Texture2D _blackTexture;
	//	フェード中のアルファ値
	private float _fadeAlpha = 0.0f;
	//	フェード中かどうか
	private bool _isFade = false;

	new public void Awake(){
		if (this != Instance) {
			Destroy (this);
			return;
		}

		DontDestroyOnLoad (gameObject);

		//	黒テクスチャを作成
		_blackTexture = new Texture2D (32, 32, TextureFormat.RGB24, false);
		_blackTexture.ReadPixels (new Rect (0, 0, 32, 32), 0, 0, false);
		_blackTexture.SetPixel (0, 0, Color.white);
		_blackTexture.Apply ();
	}

	public void OnGUI(){
		if (!_isFade) {
			return;
		}

		//	透明度を更新
		GUI.color = new Color (0, 0, 0, _fadeAlpha);
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), _blackTexture);
	}

	public void loadLevel(string scene, float interval){
		StartCoroutine (transScene (scene, interval));
	}

	private IEnumerator transScene(string scene, float interval){
		//	フェード開始
		_isFade = true;

		//	経過時間
		float time = 0.0f;

		//	だんだん暗くする
		while (time <= interval) {
			this._fadeAlpha = Mathf.Lerp (0.0f, 1.0f, time / interval);
			time += Time.deltaTime;
			yield return 0;
		}

		//	シーン遷移
		Application.LoadLevel (scene);

		//	経過時間を初期化
		time = 0.0f;

		//	だんだん明るくする
		while (time <= interval) {
			this._fadeAlpha = Mathf.Lerp (1.0f, 0.0f, time / interval);
			time += Time.deltaTime;
			yield return 0;
		}

		//	フェード終了
		_isFade = false;
	}
}
