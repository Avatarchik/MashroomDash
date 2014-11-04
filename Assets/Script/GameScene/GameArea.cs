using UnityEngine;
using System.Collections;

public class GameArea : MonoBehaviour {

    public FloorManager manager;

    //  画面外判定
    void OnTriggerExit2D(Collider2D collider){
        Destroy (collider.gameObject);

        manager.createFloor ();
    }
}
