using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization;

[DataContract]
public class CarState : MonoBehaviour
{
    [DataMember(Name = "")]
    public float velocity;
    [DataMember(Name = "")]
    public float[] point;
    bool goalCar = false;//(名前仮)(車がゴールしているのか)
    public CarState()
    {
        // 初期加速度リセット
        velocity = 0;
        // 配列初期化
        point = new float[3];
        for (int i = 0; i < point.Length; i++)
        {
            point[i] = 0;
        }
    }
    // 車のゴールステータスを変更する
    public void ChengGoalStats(bool stats)
    {
        goalCar = stats;
    }
}
