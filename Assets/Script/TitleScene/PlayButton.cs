using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnPressed(){
        //  フェード付きでゲームシーンへ遷移
        CameraFade.StartAlphaFade(Color.black, false, 1.0f, 0.1f, () => {Application.LoadLevel("GameScene");});
    }
}
