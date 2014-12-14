using UnityEngine;
using System.Collections;
using System;

public class DataFileManager : MonoBehaviour {
    /**
     * テキストファイルからテキストを取得する
     */
    public string loadText(string fileName){
        string filePath = "text/" + fileName;

        //  一旦TextAssetとして取得
        TextAsset textAsset = Resources.Load (filePath) as TextAsset;

        return textAsset.text;
    }
}
