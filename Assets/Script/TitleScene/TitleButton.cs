
using UnityEngine;
using System.Collections;

public class TitleButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onTapStartButton(){
        SceneManager.Instance.moveScene ("GameScene", 0.5f);
    }
}
