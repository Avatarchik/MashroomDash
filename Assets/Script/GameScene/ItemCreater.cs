using UnityEngine;
using System.Collections;

public class ItemCreater : MonoBehaviour {

    public GameObject addPointItem;
    public GameObject poisonItem;
    private Vector3 itemStart;
    private float delayTime;

    void Awake(){
		itemStart = transform.position;
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
			Instantiate (poisonItem, itemStart, Quaternion.identity);
        }
    }
}
