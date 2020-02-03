using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
[DataContract]
[Serializable]
public class JsonNetwork : MonoBehaviour
{
    // プレイヤーのステータス
    private List<CarState> _playerList = new List<CarState>();

    // シングルトン化するべき？
    //public static JsonNetwork instance;

    //private void Awake()
    //{
    //    if(instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(this);
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    private void Start()
    {

    }

    public void AddPlayer(CarState carState)
    {
        // Playerを登録
        _playerList.Add(carState);
        Debug.Log(_playerList[_playerList.Count - 1] + "プレイヤー" + (_playerList.Count - 1));
        // ここをNetworkの処理にする。
        var json = JsonUtility.ToJson(carState);
        Debug.Log(json);
        JsonChange();
    }

    // 車のステータス
    public CarState GetPlayerState(int id)
    {
        // プレイヤーのステータスを返す
        return _playerList[id];
    }

    public void JsonChange()
    {
        string json = "";
        for (int i = 0; i < _playerList.Count; i++)
        {
            // json形式に変換
            json = JsonUtility.ToJson(_playerList[i]);
            Debug.Log(json);
        }
    }

    public CarState GetNetworkState(int id)
    {
        // ここをNetworkの処理にする。
        var json = JsonUtility.ToJson(_playerList[id]);
        // json形式からクラスに変換
        var state = JsonUtility.FromJson<CarState>(json);
        return state;
    }

    void Update()
    {

    }
}
