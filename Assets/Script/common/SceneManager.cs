using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneManager : SingletonMonoBehaviour<SceneManager> {

	//	フェード用オブジェクト
	private GameObject _black;

	new public void Awake(){
        if (this != Instance) {
            Destroy (this);
            return;
        }

        DontDestroyOnLoad (this.gameObject);
    }
		
	public void moveScene(string scene, float time = 1.1f){
		StartCoroutine (TransScene (scene, time));
    }

	RawImage setFadeObject(){
		_black = new GameObject ();
		_black.name = "FadeObject";
		_black.transform.SetParent (GameObject.Find ("MainUI").transform);
		RectTransform rect = _black.AddComponent<RectTransform> ();
		rect.anchorMax = new Vector2 (1, 1);
		rect.anchorMin = new Vector2 (0, 0);
		rect.anchoredPosition = new Vector2 (0, 0);
		return _black.AddComponent<RawImage> ();
	}

	private IEnumerator TransScene(string scene, float interval){
		float time = 0;
		RawImage raw = setFadeObject ();

		while (time <= interval) {
			raw.color = new Color (0, 0, 0, Mathf.Lerp (0, 1, time / interval));
			time += Time.deltaTime;
			yield return 0;
		}

		Application.LoadLevel (scene);

		Destroy (_black);
    }
}
