using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameArea : MonoBehaviour {

    //  ゲーム終了フラグ
    public bool isGameEnd = false;
    //  確率の配列
    public float[] itemProbs;

    private const int BIRD_INDEX = 4;

    public List<GameObject> itemList;

    void Awake(){
        const float delayTime = 2.0f;
        InvokeRepeating ("createItem", delayTime, delayTime);
    }

    void Start(){
        AudioManager.Instance.playBgm ("Stage");
    }
   
    void Update(){

    }

    void OnTriggerExit2D(Collider2D collider){ 
        Destroy (collider.gameObject);
    }

    void createItem(){
        GameObject item;
        float arrayIndex = chooseItem (itemProbs);

        Vector3 itemPosition;
        if (BIRD_INDEX == arrayIndex) {
            itemPosition = new Vector3 (-8.1f, -1.5f, 0);
        } else {
            itemPosition = new Vector3 (-8.1f, -4f, 0);
        }
        item = (GameObject)Instantiate (itemList [(int)arrayIndex], itemPosition, Quaternion.identity);
        item.transform.SetParent (transform);
    }

    float chooseItem(float[] values){
        float total = 0;

        foreach (float elem in values) {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < values.Length; i++) {
            if (randomPoint < values [i]) {
                return i;
            } else {
                randomPoint -= values [i];
            }
        }

        return values.Length - 1;
    }

    public void switchGameOver(){
        isGameEnd = true;
        FindObjectOfType<Score> ().saveScore ();
        Application.LoadLevel ("GameOverScene");
    }
}
