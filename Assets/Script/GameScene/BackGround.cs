using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {

    public float speed = 0.1f;

    void Start(){
        AudioManager.Instance.playBgm ("Game");
    }
        
	void Update () {
        float x = Mathf.Repeat (Time.time * speed, 1);
        Vector2 offset = new Vector2 (x, 0);
        renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}
