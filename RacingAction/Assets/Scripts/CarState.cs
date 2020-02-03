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
    // ゴール判定
    [DataMember(Name = "goalCar")]
    public bool goalCar;
    public byte[] ToByte()
    {
        byte[] x = BitConverter.GetBytes(pos[0]);
        byte[] y = BitConverter.GetBytes(pos[1]);
        byte[] z = BitConverter.GetBytes(pos[2]);
        return MargeByte(MargeByte(x, y), z);
    }
    public static byte[] MargeByte(byte[] baseByte, byte[] addByte)
    {
        byte[] b = new byte[baseByte.Length + addByte.Length];
        for (int i = 0; i < b.Length; i++)
        {
            if (i < baseByte.Length) b[i] = baseByte[i];
            else b[i] = addByte[i - baseByte.Length];
        }
        return b;
    }
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
