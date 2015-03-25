using UnityEngine;
using System.Collections;

public class SceneManager : SingletonMonoBehaviour<SceneManager> {

    //  暗転用テクスチャー
    private Texture2D blackTexture;
    //  フェード中の透明度
    private float alpha = 0;
    //  フェード実行フラグ
    private bool isFade = false;

   /* public void Awake(){
        if (this != Instance) {
            Destroy (this);
            return;
        }

        DontDestroyOnLoad (this.gameObject);

        //  暗転用テクスチャーを作成
        blackTexture = new Texture2D (32, 32, TextureFormat.RGB24, false);
        blackTexture.ReadPixels (new Rect (0, 0, 32, 32), 0, 0, false);
        blackTexture.SetPixel (0, 0, Color.white);
        blackTexture.Apply ();
    }*/

    public void OnGUI ()
    {
       /* if (!isFade) {
            return;
        }

        //透明度を更新して黒テクスチャを描画
        GUI.color = new Color (0, 0, 0, alpha);
        GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), blackTexture);*/
    }

    //  シーンを切り替え
    public void moveScene(string scene, float fadeTime){
        StartCoroutine (TransScene (scene, fadeTime));
    }

    //  シーン繊維用コルーチン
    private IEnumerator TransScene(string scene, float fadeTime){
        //  暗くする
        isFade = true;
        float time = 0;
        while (time <= fadeTime) {
            alpha = Mathf.Lerp (0, 1, time / fadeTime);
            time += Time.deltaTime;
            yield return 0;
        }

        Application.LoadLevel (scene);

        //  明るくする
        time = 0;
        while (time <= fadeTime) {
            alpha = Mathf.Lerp (1, 0, time / fadeTime);
            time += Time.deltaTime;
            yield return 0;
        }
        isFade = false;
    }
}
