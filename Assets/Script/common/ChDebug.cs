using UnityEngine;
using System.Collections;

/**
 * 実機でデバッグ機能を表示するための機能
 * 
 */
public class ChDebug : MonoBehaviour {
    //  ログ格納用のキュー
    static private Queue logQueue;
    //  格納するログの数
    static private uint iNumLog = 20;

    /**
     * 初期化関数
     * ほかの機能を使う前に1度だけ呼び出す
     */
    static public void init(){
        logQueue = new Queue();
        iNumLog = 20;
    }

    /**
     * ログのプッシュ
     * @param str ログメッセージ
     * @param console コンソールに表示するかどうか
     */
    static public void PushLog(string str, bool console = false){
        if (logQueue.Count >= iNumLog) {
            logQueue.Dequeue ();
        }

        logQueue.Enqueue (str);
        if (console) {
            Debug.Log (str);
        }
    }

    /**
     * ログを描画
     */
    static public void RenderLog(Rect rect, Color color){
        Rect currentRect = rect;
        currentRect.y += rect.height * (logQueue.Count - 1);

        Color prevColor = GUI.color;
        GUI.color = color;

        System.Collections.IEnumerator ienum = logQueue.GetEnumerator ();
        while (ienum.MoveNext ()) {
            GUI.Label (currentRect, (string)ienum.Current);
            currentRect.y -= rect.height;
        }

        GUI.color = prevColor;
    }

}
