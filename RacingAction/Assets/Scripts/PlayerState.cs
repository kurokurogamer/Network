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
public class PlayerState : MonoBehaviour
{
    public Vector3 _pos = Vector3.zero;
    public float _speed = 0.0f;
    public bool _gool = false;
}
