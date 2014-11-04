using UnityEngine;
using System.Collections;

public class ItemCreater : MonoBehaviour {

    //  ポイント加算アイテム
    public GameObject addpointItem;
    //  アイテムを生成するインターバルの時間
    private float delayTime = 2.0f;

    void Awake(){
        InvokeRepeating ("createItem", delayTime, delayTime);
    }

    void createItem(){
        //  ポイント加算アイテムを生成
        Instantiate (addpointItem, new Vector3 (-12, -3.8f, 0), Quaternion.identity);
    }
}
