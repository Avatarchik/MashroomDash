using UnityEngine;
using System.Collections;

public class CutInManager : MonoBehaviour {

    //  カット位のブジェクト
    public GameObject _cutIn;
    //  カットイン再生段階
    private int _cutInFase;

    private const int CUTIN_LIMIT = 3;

    //  スピードアップ倍率
    private const float _speedUpRate = 1.2f;

    BackGround[] _bgComponents;
    ItemMashroom[] _itemComponents;

	// Use this for initialization
	void Start () {
        _bgComponents = FindObjectsOfType<BackGround> ();
        _cutInFase = 1;
	}
	
    public void playCutIn(){
        //  カットインは3回まで再生
        if (_cutInFase <= CUTIN_LIMIT) {
            GameObject cutIn = (GameObject)Instantiate (_cutIn, new Vector3 (0, 1.27f, 0), Quaternion.identity);
            cutIn.transform.SetParent (gameObject.transform);

            //  背景スクロールスピードアップ
            for (int i = 0; i < _bgComponents.Length; i++) {
                _bgComponents [i].speed *= _speedUpRate;
            }

            //  すでに表示されているアイテムのスピードをあげる
            _itemComponents = GetComponentsInChildren<ItemMashroom> ();
            for (int i = 0; i < _itemComponents.Length; i++) {
                _itemComponents [i].moveSpeed *= _speedUpRate;
            }

            _cutInFase++;
        }
    }

    //  カットイン再生状況を取得
    public int getCutInFase(){
        return _cutInFase;
    }

    //  スピードアップ倍率を取得
    public float getSpeedRate(){
        return _speedUpRate;
    }
}
