using UnityEngine;
using System.Collections;

/**
 * 
 */
public class FloorManager : MonoBehaviour {
    //  生成するオブジェクト
    public GameObject prefab;
    //  落とし穴
    public GameObject hall;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 10; i++) {
            Instantiate (prefab, new Vector3(-10 + 2 * i, -5, 0), Quaternion.identity);
        }
    }

    public void createFloor(){
        //  毎フレーム違う乱数を生成
        System.Random r = new System.Random();
        Debug.Log ("" + r.Next(100));

        int randomValue = r.Next (100);
        /* if (r.Next (100) >= 97) {
            Debug.Log ("HALL!");
            Instantiate (hall, new Vector3 (-10.4f, -5, 0), Quaternion.identity);

        } else {*/
        if (randomValue >= 10) {
            Instantiate (prefab, new Vector3 (-10, -5, 0), Quaternion.identity);
        } else {
            Instantiate (hall, new Vector3 (-10, -5, 0), Quaternion.identity);
        }

    }
}
