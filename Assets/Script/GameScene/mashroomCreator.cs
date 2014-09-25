using UnityEngine;
using System.Collections;

public class mashroomCreator : MonoBehaviour {

    public GameObject cube;

    void OnGUI(){
        if (GUI.Button (new Rect (10, 10, 100, 50), "GENERTE")) {
            float x = Random.Range(-2.0f, 2.0f);
            float y = Random.Range(-2.0f, 2.0f);

            Instantiate(cube, new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}
