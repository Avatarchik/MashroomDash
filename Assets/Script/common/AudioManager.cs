using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : SingletonMonoBehaviour<AudioManager> {

    //  BGMリスト
    public List<AudioClip> bgmList;
    //  SEリスト
    public List<AudioClip> seList;
    //  SE最大ボリューム
    public int seSourceCount = 10;

    //  BGMソース
    private AudioSource bgmSource = null;
    //  SEソースリスト
    private List<AudioSource> seSource = null;
    //  BGMファイルリスト
    private Dictionary<string, AudioClip> bgmDictionary = null;
    //  SEファイルリスト
    private Dictionary<string, AudioClip> seDictionary = null;

    public void Awake(){
        if(this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

        //  AudioListenerを作成
        if(FindObjectsOfType(typeof(AudioListener)).All(o => !((AudioListener)o).enabled)){
            this.gameObject.AddComponent<AudioListener>();
        }
        //  AudioSourceを作成
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
        seSource = new List<AudioSource>();

        //  ファイルリストを作成
        bgmDictionary = new Dictionary<string, AudioClip>();
        seDictionary = new Dictionary<string, AudioClip>();

        //  Dictionaryにファイル名を追加
        Action<Dictionary<string, AudioClip>, AudioClip> addClipDictionary = (dictionary, file) => {
            if (!dictionary.ContainsKey (file.name)) {
                dictionary.Add (file.name, file);
            }
        };
        bgmList.ForEach(bgm => addClipDictionary(bgmDictionary,bgm));
        seList.ForEach(se => addClipDictionary(seDictionary,se));
    }

    /**
     * SE再生
     */
    public void playSe(string seFileName){
        //  ファイルが見つからない場合はエラーを表示する
        if (!seDictionary.ContainsKey (seFileName)) {
            throw new ArgumentException (seFileName + "is not found!", "seFile");
        }

        //  再生されていないSEを取得
        AudioSource source = seSource.FirstOrDefault(s => !s.isPlaying);
        if(source == null){
            if(seSource.Count >= seSourceCount){
                Debug.Log("Se AudioSource is full");
                return;
            }
        }

        source = gameObject.AddComponent<AudioSource>();
        seSource.Add(source);
    }

    /**
     * SE停止
     */
    public void stopSe(){
        seSource.ForEach (sources => sources.Stop ());
    }

    /**
     * BGM再生
     */
    public void playBgm(string bgmFileName){
        //  ファイルが見つからない場合はエラーを表示する
        if (!bgmDictionary.ContainsKey (bgmFileName)) {
            throw new ArgumentException (bgmFileName + "is not found!", "bgmFile");
        }
        //  ファイル名が同じ場合は処理を行わない
        if (bgmSource.clip == bgmDictionary [bgmFileName]) {
            return;
        }
        bgmSource.Stop ();
        bgmSource.clip = bgmDictionary [bgmFileName];
        bgmSource.Play ();
        bgmSource.volume = 0.2f;
    }

    /**
     * BGMを停止
     */
    public void stopBgm(){
        bgmSource.Stop ();
        bgmSource.clip = null;
    }
}
