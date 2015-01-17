using UnityEngine;
using System.Collections;

public class ItemCreater : MonoBehaviour {

    //  ポイント加算アイテム
    public GameObject addPointItem;
    //  障害物
    public GameObject obstacleItem;
    //  アイテム初期位置
    private Vector3 itemStart = new Vector3 (-12, -3.8f, 0);
    //  アイテムを生成するインターバルの時間
    private float delayTime = 2.0f;

    void Awake(){
        InvokeRepeating ("createItem", delayTime, delayTime);
    }

    /**
     *  アイテムを生成 
     */
    void createItem(){
        if (0 == Random.Range (0, 100) % 2) {
            Instantiate (addPointItem, itemStart, Quaternion.identity);
        } else {
            Instantiate (obstacleItem, itemStart, Quaternion.identity);
        }
        // Debug.Log (Random.Range (0.1f, 1.0f));
    }
}
