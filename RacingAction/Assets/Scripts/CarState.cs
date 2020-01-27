using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization;

[DataContract]
public struct CarState
{
    // 車の速さ
    [DataMember(Name = "velocity")]
    public float velocity;
    // 車の位置
    [DataMember(Name = "pos")]
    public float[] pos;
    // 
    public float angle;
    // ゴール判定
    [DataMember(Name = "goalCar")]
    public bool goalCar;
    //(名前仮)(車がゴールしているのか)
    //public CarState()
    //{
    //    // 初期加速度リセット
    //    velocity = 0;
    //    // 配列初期化
    //    pos = new float[3];
    //    for (int i = 0; i < pos.Length; i++)
    //    {
    //        pos[i] = 0;
    //    }
    //}
    //// 車のゴールステータスを変更する
    //public void ChengGoalStats(bool stats)
    //{
    //    goalCar = stats;
    //}
}
