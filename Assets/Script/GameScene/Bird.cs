using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

    public float moveSpeed = 0.2f;
    public int point = 10;
    public bool isPointItem;

    // Use this for initialization
    void Start () {
        //  カットインの再生回数に合わせてスピードを調整
        CutInManager manager = GetComponentInParent<CutInManager> ();
        for (int i = 0; i < manager.getCutInFase () - 1; i++) {
            moveSpeed *= manager.getSpeedRate();
        }
    }

    // Update is called once per frame
    void Update () {
        if (0 < Time.timeScale) {
            transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
        }
    }
}
