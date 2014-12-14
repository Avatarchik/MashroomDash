using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

    void Start () {
        CameraFade.StartAlphaFade (Color.white, true, 2.0f);
    }

    void OnPressed(){
        //  フェード付きでゲームシーンへ遷移
        CameraFade.StartAlphaFade(Color.black, false, 1.0f, 0.1f, () => {Application.LoadLevel("GameScene");});
    }
}
