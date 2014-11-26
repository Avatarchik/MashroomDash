using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

    void OnPressed(){
        //  フェード付きでゲームシーンへ遷移
        CameraFade.StartAlphaFade(Color.black, false, 1.0f, 0.1f, () => {Application.LoadLevel("GameScene");});
    }
}
