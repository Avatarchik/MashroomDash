using UnityEngine;
using System.Collections;

public class TitleBg : MonoBehaviour {

    void Awake(){
       
    }

	// Use this for initialization
	void Start () {
        AudioManager.Instance.playBgm ("TitleBgm");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			SceneManager.Instance.loadLevel ("GameScene", 0.5f);
		}
	}
}
