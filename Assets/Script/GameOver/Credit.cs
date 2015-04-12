using UnityEngine;
using System.Collections;

public class Credit : MonoBehaviour {
    private bool _isOpenCredit = true;
    private GameObject _mainUI;
	// Use this for initialization
    void Start () {
        _mainUI = GameObject.Find ("MainUI").gameObject;
        iTween.ValueTo (gameObject, iTween.Hash ("from", 825, "to", 0, "time", 0.5f,
            "onupdate", "UpdateHandler", "oncomplete", "CompleteHandler"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
        
    void UpdateHandler(float value){
        Debug.Log (value);
        gameObject.GetComponent<RectTransform> ().position = new Vector3 (value, 0, 0);
    }

    void CompleteHandler(){
        Debug.Log ("Complete");
        if (_isOpenCredit) {
            _mainUI.SetActive (false);
        } else {
            Destroy (gameObject);
        }
    }

    public void OnTapBackButton(){
        _isOpenCredit = false;
        _mainUI.SetActive (true);
        iTween.ValueTo (gameObject, iTween.Hash ("from", 0, "to", 825, "time", 0.5f,
                        "onupdate", "UpdateHandler", "oncomplete", "CompleteHandler"));
    }
}
