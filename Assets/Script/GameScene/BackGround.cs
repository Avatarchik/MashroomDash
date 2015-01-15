using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {

    public float speed = 0.1f;

    void Start(){
        AudioManager.Instance.playBgm ("gameBgm");
    }

	// Update is called once per frame
	void Update () {
        //  時間によってyの値が変化
        float x = Mathf.Repeat (Time.time * speed, 1);

        //  Xßの値がずれていくオフセットを作成
        Vector2 offset = new Vector2 (x, 0);

        //  マテリアルにオフセットを設定
        renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}
