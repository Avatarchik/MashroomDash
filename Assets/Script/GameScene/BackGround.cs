using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {

    public float speed = 0.1f;

    void Start(){
        AudioManager.Instance.playBgm ("gameBgm");
    }
        
	void Update () {
        //  背景をループ移動
        float x = Mathf.Repeat (Time.time * speed, 1);
        Vector2 offset = new Vector2 (x, 0);
        renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}
