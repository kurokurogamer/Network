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
    public void Main()
    {
        player = new CarState[2];
        player[0] = new CarState()
        {
            velocity = 0,
            point = new Vector3(0, 0, 0)
        };
        player[1] = new CarState()
        {
            velocity = 0,
            point = new Vector3(0, 0, 0)
        };
        List<CarState> pList = new List<CarState>();
        pList.Add(player[0]);
        pList.Add(player[1]);
        string json = "{ \"velocity\": 1, \"point\": \"[1,0,2]\"}";
        var state = JsonUtility.FromJson<CarState>(json);
        Debug.Log(player[0].velocity + "プレイヤー1");
        Debug.Log(player[1].velocity + "プレイヤー2");
        Debug.Log(state.velocity + "JSONから");
    }
    void Update()
    {
    }
}
