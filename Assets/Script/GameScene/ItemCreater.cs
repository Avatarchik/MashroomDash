using UnityEngine;
using System.Collections;

public class ItemCreater : MonoBehaviour {

    public GameObject addPointItem;
    public GameObject obstacleItem;
    private Vector3 itemStart;
    private float delayTime;

    void Awake(){
        itemStart = GameObject.Find ("ItemCreater").transform.position;
        delayTime = 2.0f;
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
    }
}
