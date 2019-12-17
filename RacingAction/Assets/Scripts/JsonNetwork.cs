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
    CarState[] player;

    private void Start()
    {
        player = new CarState[2];
        player[0] = new CarState()
        {
        };
        player[1] = new CarState()
        {
        };
        List<CarState> pList = new List<CarState>();
        pList.Add(player[0]);
        pList.Add(player[1]);
        string json = "{ \"velocity\": 1, \"point\": [1, 0, 3]}";
        var state = JsonUtility.FromJson<CarState>(json);
        Debug.Log(player[0].velocity + "プレイヤー1");
        Debug.Log(player[1].velocity + "プレイヤー2");
        Debug.Log(state.velocity + "JSONから");
        Debug.Log(state.point[0] + "JSONから");
        Debug.Log(state.point[1] + "JSONから");
        Debug.Log(state.point[2] + "JSONから");
    }
    void Update()
    {
    }
}
