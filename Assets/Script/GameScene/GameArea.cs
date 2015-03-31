using UnityEngine;
using System.Collections;

public class GameArea : MonoBehaviour {

    //  ゲーム終了フラグ
    public bool isGameEnd = false;

    public GameObject _pointItem;
    public GameObject _poisonItem;
    public GameObject _bird;

    private Vector3 _itemPosition;

    void Awake(){
        const float delayTime = 2.0f;
        InvokeRepeating ("createItem", delayTime, delayTime);
    }

    void Start(){
        _itemPosition = new Vector3 (-8.1f, -4.2f, 0);
    }
   
    void Update(){
        if (Input.GetMouseButtonUp (0)) {
            if (isGameEnd) {
                isGameEnd = false;
                PlayerPrefs.Save ();
                SceneManager.Instance.moveScene ("GameScene", 0.5f);
            } else {
                GetComponentInChildren<Player> ().JumpPlayer ();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider){ 
        Destroy (collider.gameObject);
    }

    void createItem(){
        GameObject item;
        if (0 == Random.Range (0, 100) % 3) {
            item = (GameObject)Instantiate (_pointItem, _itemPosition, Quaternion.identity);
        } else if (1 == Random.Range (0, 100) % 3) {
            item = (GameObject)Instantiate (_poisonItem, _itemPosition, Quaternion.identity);
        } else {
            Vector3 birdPos = new Vector3 (-8.1f, -0.31f, 0);
            item = (GameObject)Instantiate (_bird, birdPos, Quaternion.identity);
        }
        item.transform.SetParent (transform);
    }

    public void switchGameOver(){
        isGameEnd = true;
		this.GetComponentInChildren<GameOver> ().FadeLayer ();
    }
}
